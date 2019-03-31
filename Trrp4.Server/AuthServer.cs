using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using Trrp4.Objects;

namespace Trrp4.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AuthServer : IAuthService
    {
        public const int SaltLength = 10;

        public bool Register(UserInfo userInfo)
        {
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
                    var accessKey = new AccessKey { Key = Guid.NewGuid(), UserId = userFromDb.Id, Expires = DateTime.Now.AddDays(1)};
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
