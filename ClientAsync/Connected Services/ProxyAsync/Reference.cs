﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientAsync.ProxyAsync {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyAsync.IMessage", CallbackContract=typeof(ClientAsync.ProxyAsync.IMessageCallback))]
    public interface IMessage {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessage/Join")]
        void Join(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMessage/Join")]
        System.Threading.Tasks.Task JoinAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessage/AddMessage", ReplyAction="http://tempuri.org/IMessage/AddMessageResponse")]
        void AddMessage(byte[] message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessage/AddMessage", ReplyAction="http://tempuri.org/IMessage/AddMessageResponse")]
        System.Threading.Tasks.Task AddMessageAsync(byte[] message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessage/OnMessageAdded", ReplyAction="http://tempuri.org/IMessage/OnMessageAddedResponse")]
        void OnMessageAdded(byte[] msg, System.DateTime timestamp);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageChannel : ClientAsync.ProxyAsync.IMessage, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessageClient : System.ServiceModel.DuplexClientBase<ClientAsync.ProxyAsync.IMessage>, ClientAsync.ProxyAsync.IMessage {
        
        public MessageClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MessageClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Join(string username) {
            base.Channel.Join(username);
        }
        
        public System.Threading.Tasks.Task JoinAsync(string username) {
            return base.Channel.JoinAsync(username);
        }
        
        public void AddMessage(byte[] message) {
            base.Channel.AddMessage(message);
        }
        
        public System.Threading.Tasks.Task AddMessageAsync(byte[] message) {
            return base.Channel.AddMessageAsync(message);
        }
    }
}