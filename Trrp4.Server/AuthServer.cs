using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Trrp4.Objects;
using Trrp4.Shared;
using Trrp4.Shared.ChatServiceReference;
using AccessKey = Trrp4.Objects.AccessKey;

namespace Trrp4.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AuthServer : IAuthService
    {
        public const int BasePort = 9000;
        public const int SaltLength = 10;

        public IPEndPoint NotifierEndPoint { get; set; }
        public IPEndPoint ServiceEndPoint { get; set; }
        public IPEndPoint DispatcherEndPoint { get; set; }

        public double DispatcherNotifyPeriodMilliseconds { get; set; }
        public Timer DispatcherNotifierTimer { get; set; }
        public UdpClient DispatcherNotifierUdpClient { get; set; }

        private int _clientsServed = 0;

        public AuthServer()
        {
            DispatcherEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
            NotifierEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort);
            ServiceEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BasePort + 1);
            
            DispatcherNotifyPeriodMilliseconds = 3000;
            DispatcherNotifierTimer = new Timer(DispatcherNotifyPeriodMilliseconds);
            DispatcherNotifierTimer.Elapsed += NotifyDispatcher;
        }

        public void AutoSetupPorts()
        {
            bool isInUse;
            var currentPort = BasePort;
            do
            {
                isInUse = false;
                for (var i = 0; i < 2; i++)
                {
                    try
                    {
                        var udpClient = new UdpClient(new IPEndPoint(NotifierEndPoint.Address, currentPort));
                        udpClient.Close();
                    }
                    catch (SocketException socketException)
                    {
                        isInUse = true;
                    }

                    if (NetworkTools.IsPortInUse(currentPort + i))
                        isInUse = true;
                }
                if (isInUse)
                    currentPort += 2;
            } while (isInUse);

            NotifierEndPoint.Port = currentPort;
            ServiceEndPoint.Port = currentPort + 1;
        }

        private void NotifyDispatcher(object sender, ElapsedEventArgs e)
        {
            DispatcherNotifierUdpClient.Send(new byte[] { 1, (byte)(_clientsServed / DispatcherNotifyPeriodMilliseconds * 1000) }, 2, DispatcherEndPoint);
            _clientsServed = 0;
        }

        public void Start()
        {
            DispatcherNotifierUdpClient = new UdpClient(NotifierEndPoint);
            DispatcherNotifierTimer.Start();
        }

        public void Stop()
        {
            DispatcherNotifierTimer.Stop();
        }

        public bool Register(UserInfo userInfo)
        {
            _clientsServed++;

            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var saltBytes = new byte[UnicodeEncoding.CharSize * SaltLength];
            rngCryptoServiceProvider.GetNonZeroBytes(saltBytes);
            var saltString = Encoding.Unicode.GetString(saltBytes);
            var saltedPasswordBytes = Encoding.Unicode.GetBytes(userInfo.Password + saltString);
            var sha256CryptoServiceProvider = new SHA256CryptoServiceProvider();
            sha256CryptoServiceProvider.Initialize();
            var passwordHashBytes = sha256CryptoServiceProvider.ComputeHash(saltedPasswordBytes);
            var passwordHashString = Encoding.Unicode.GetString(passwordHashBytes);

            var user = new User()
            {
                Login = userInfo.Login,
                Hash = passwordHashString,
                Salt = saltString
            };

            try
            {
                var chatContext = new ChatContext();
                chatContext.Users.Add(user);
                chatContext.SaveChanges();
                chatContext.Dispose();

                Console.WriteLine($"AuthServer: {user.Id} {user.Login} {user.Hash} {user.Salt}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }

            return true;
        }

        public AccessKey Auth(UserInfo userInfo, IPEndPoint chatServer)
        {
            _clientsServed++;

            try
            {
                User userFromDb;
                using (var chatContext = new ChatContext())
                {
                    userFromDb = chatContext.Users.First(u => u.Login == userInfo.Login);
                }

                var saltString = userFromDb.Salt;
                var saltedPasswordBytes = Encoding.Unicode.GetBytes(userInfo.Password + saltString);
                var sha256CryptoServiceProvider = new SHA256CryptoServiceProvider();
                sha256CryptoServiceProvider.Initialize();
                var passwordHashBytes = sha256CryptoServiceProvider.ComputeHash(saltedPasswordBytes);
                var passwordHashString = Encoding.Unicode.GetString(passwordHashBytes);

                if (userFromDb.Hash == passwordHashString)
                {
                    var accessKey = new AccessKey { Key = Guid.NewGuid(), UserId = userFromDb.Id, Expires = DateTime.Now.AddDays(1) };
                    var chatServiceClient = new ChatServiceClient(new BasicHttpBinding(BasicHttpSecurityMode.None),
                        new EndpointAddress($"http://{chatServer.Address}:{chatServer.Port}/chatserver"));
                    chatServiceClient.AddAccessKey(new Shared.ChatServiceReference.AccessKey() { Key = accessKey.Key, UserId = accessKey.UserId, Expires = accessKey.Expires });
                    Console.WriteLine($"AuthServer: {accessKey.UserId} {accessKey.Key} {accessKey.Expires}");
                    return accessKey;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return null;
        }

        public void Logout(AccessKey accessKey, IPEndPoint chatServer)
        {

        }
    }
}
