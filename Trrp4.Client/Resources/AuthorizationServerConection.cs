using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.ServiceModel;
using Trrp4.Objects;
using Trrp4.Server;

namespace Trrp4.Client.Resources
{
    public class AuthorizationServerConection
    {
        public IPEndPoint[] Addresses { get; }
        private IAuthService authService;

        public AuthorizationServerConection(IPEndPoint[] addresses)
        {
            Addresses = addresses;
            foreach(var address in Addresses)
            {
                Uri tcpUri = new Uri(address.ToString());
                EndpointAddress adrs = new EndpointAddress(tcpUri);
                BasicHttpBinding binding = new BasicHttpBinding();
                ChannelFactory<IAuthService> factory = new ChannelFactory<IAuthService>(binding, adrs);
                authService = factory.CreateChannel();
            }
        }

        public AccessKey Authenticate(string login, string password, IPEndPoint chatServerAddress)
        {
            return authService.Auth(new UserInfo() { Login = login, Password = password }, chatServerAddress);
        }

        public bool Registrate(string login, string password)
        {
            return authService.Register(new UserInfo() { Login = login, Password = password });
        }

        public void Logout(AccessKey accessKey, IPEndPoint chatServer)
        {
            authService.Logout(accessKey, chatServer);
        }

        public User[] GetUsers()
        {
            return authService.GetUsers();
        }

        public List<Member> GetMemberList()
        {
            var usrs = GetUsers();
            var memberList = new List<Member>();
            foreach(var usr in usrs)
            {
                memberList.Add(new Member(usr.Id, usr.Login));
            }
            return memberList;
        }
    }
}
