﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trrp4.Shared.DispatcherServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DispatcherServiceReference.IDispatcherService")]
    public interface IDispatcherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcherService/GetBestChatServers", ReplyAction="http://tempuri.org/IDispatcherService/GetBestChatServersResponse")]
        System.Net.IPEndPoint[] GetBestChatServers(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcherService/GetBestChatServers", ReplyAction="http://tempuri.org/IDispatcherService/GetBestChatServersResponse")]
        System.Threading.Tasks.Task<System.Net.IPEndPoint[]> GetBestChatServersAsync(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcherService/GetBestAuthServers", ReplyAction="http://tempuri.org/IDispatcherService/GetBestAuthServersResponse")]
        System.Net.IPEndPoint[] GetBestAuthServers(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcherService/GetBestAuthServers", ReplyAction="http://tempuri.org/IDispatcherService/GetBestAuthServersResponse")]
        System.Threading.Tasks.Task<System.Net.IPEndPoint[]> GetBestAuthServersAsync(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcherService/GetServerByClient", ReplyAction="http://tempuri.org/IDispatcherService/GetServerByClientResponse")]
        System.Net.IPEndPoint GetServerByClient(int clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcherService/GetServerByClient", ReplyAction="http://tempuri.org/IDispatcherService/GetServerByClientResponse")]
        System.Threading.Tasks.Task<System.Net.IPEndPoint> GetServerByClientAsync(int clientId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDispatcherServiceChannel : Trrp4.Shared.DispatcherServiceReference.IDispatcherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DispatcherServiceClient : System.ServiceModel.ClientBase<Trrp4.Shared.DispatcherServiceReference.IDispatcherService>, Trrp4.Shared.DispatcherServiceReference.IDispatcherService {
        
        public DispatcherServiceClient() {
        }
        
        public DispatcherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DispatcherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DispatcherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DispatcherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.IPEndPoint[] GetBestChatServers(int count) {
            return base.Channel.GetBestChatServers(count);
        }
        
        public System.Threading.Tasks.Task<System.Net.IPEndPoint[]> GetBestChatServersAsync(int count) {
            return base.Channel.GetBestChatServersAsync(count);
        }
        
        public System.Net.IPEndPoint[] GetBestAuthServers(int count) {
            return base.Channel.GetBestAuthServers(count);
        }
        
        public System.Threading.Tasks.Task<System.Net.IPEndPoint[]> GetBestAuthServersAsync(int count) {
            return base.Channel.GetBestAuthServersAsync(count);
        }
        
        public System.Net.IPEndPoint GetServerByClient(int clientId) {
            return base.Channel.GetServerByClient(clientId);
        }
        
        public System.Threading.Tasks.Task<System.Net.IPEndPoint> GetServerByClientAsync(int clientId) {
            return base.Channel.GetServerByClientAsync(clientId);
        }
    }
}
