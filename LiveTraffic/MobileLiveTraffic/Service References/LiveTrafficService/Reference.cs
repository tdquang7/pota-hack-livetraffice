﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace MobileLiveTraffic.LiveTrafficService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="LiveTrafficService.MobileService")]
    public interface MobileService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:MobileService/Login", ReplyAction="urn:MobileService/LoginResponse")]
        System.IAsyncResult BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState);
        
        bool EndLogin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:MobileService/UpdateStreetStatus", ReplyAction="urn:MobileService/UpdateStreetStatusResponse")]
        System.IAsyncResult BeginUpdateStreetStatus(string username, string country, string city, string district, string street, double latitude, double longitude, string status, System.AsyncCallback callback, object asyncState);
        
        bool EndUpdateStreetStatus(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:MobileService/GetStreetStatus", ReplyAction="urn:MobileService/GetStreetStatusResponse")]
        System.IAsyncResult BeginGetStreetStatus(string country, string city, string district, string street, double latitude, double longitude, string mode, System.AsyncCallback callback, object asyncState);
        
        string EndGetStreetStatus(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MobileServiceChannel : MobileLiveTraffic.LiveTrafficService.MobileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateStreetStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateStreetStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetStreetStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetStreetStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MobileServiceClient : System.ServiceModel.ClientBase<MobileLiveTraffic.LiveTrafficService.MobileService>, MobileLiveTraffic.LiveTrafficService.MobileService {
        
        private BeginOperationDelegate onBeginLoginDelegate;
        
        private EndOperationDelegate onEndLoginDelegate;
        
        private System.Threading.SendOrPostCallback onLoginCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateStreetStatusDelegate;
        
        private EndOperationDelegate onEndUpdateStreetStatusDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateStreetStatusCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetStreetStatusDelegate;
        
        private EndOperationDelegate onEndGetStreetStatusDelegate;
        
        private System.Threading.SendOrPostCallback onGetStreetStatusCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public MobileServiceClient() {
        }
        
        public MobileServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MobileServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<LoginCompletedEventArgs> LoginCompleted;
        
        public event System.EventHandler<UpdateStreetStatusCompletedEventArgs> UpdateStreetStatusCompleted;
        
        public event System.EventHandler<GetStreetStatusCompletedEventArgs> GetStreetStatusCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MobileLiveTraffic.LiveTrafficService.MobileService.BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLogin(username, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool MobileLiveTraffic.LiveTrafficService.MobileService.EndLogin(System.IAsyncResult result) {
            return base.Channel.EndLogin(result);
        }
        
        private System.IAsyncResult OnBeginLogin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((MobileLiveTraffic.LiveTrafficService.MobileService)(this)).BeginLogin(username, password, callback, asyncState);
        }
        
        private object[] OnEndLogin(System.IAsyncResult result) {
            bool retVal = ((MobileLiveTraffic.LiveTrafficService.MobileService)(this)).EndLogin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnLoginCompleted(object state) {
            if ((this.LoginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoginCompleted(this, new LoginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoginAsync(string username, string password) {
            this.LoginAsync(username, password, null);
        }
        
        public void LoginAsync(string username, string password, object userState) {
            if ((this.onBeginLoginDelegate == null)) {
                this.onBeginLoginDelegate = new BeginOperationDelegate(this.OnBeginLogin);
            }
            if ((this.onEndLoginDelegate == null)) {
                this.onEndLoginDelegate = new EndOperationDelegate(this.OnEndLogin);
            }
            if ((this.onLoginCompletedDelegate == null)) {
                this.onLoginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoginCompleted);
            }
            base.InvokeAsync(this.onBeginLoginDelegate, new object[] {
                        username,
                        password}, this.onEndLoginDelegate, this.onLoginCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MobileLiveTraffic.LiveTrafficService.MobileService.BeginUpdateStreetStatus(string username, string country, string city, string district, string street, double latitude, double longitude, string status, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateStreetStatus(username, country, city, district, street, latitude, longitude, status, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool MobileLiveTraffic.LiveTrafficService.MobileService.EndUpdateStreetStatus(System.IAsyncResult result) {
            return base.Channel.EndUpdateStreetStatus(result);
        }
        
        private System.IAsyncResult OnBeginUpdateStreetStatus(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string country = ((string)(inValues[1]));
            string city = ((string)(inValues[2]));
            string district = ((string)(inValues[3]));
            string street = ((string)(inValues[4]));
            double latitude = ((double)(inValues[5]));
            double longitude = ((double)(inValues[6]));
            string status = ((string)(inValues[7]));
            return ((MobileLiveTraffic.LiveTrafficService.MobileService)(this)).BeginUpdateStreetStatus(username, country, city, district, street, latitude, longitude, status, callback, asyncState);
        }
        
        private object[] OnEndUpdateStreetStatus(System.IAsyncResult result) {
            bool retVal = ((MobileLiveTraffic.LiveTrafficService.MobileService)(this)).EndUpdateStreetStatus(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateStreetStatusCompleted(object state) {
            if ((this.UpdateStreetStatusCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateStreetStatusCompleted(this, new UpdateStreetStatusCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateStreetStatusAsync(string username, string country, string city, string district, string street, double latitude, double longitude, string status) {
            this.UpdateStreetStatusAsync(username, country, city, district, street, latitude, longitude, status, null);
        }
        
        public void UpdateStreetStatusAsync(string username, string country, string city, string district, string street, double latitude, double longitude, string status, object userState) {
            if ((this.onBeginUpdateStreetStatusDelegate == null)) {
                this.onBeginUpdateStreetStatusDelegate = new BeginOperationDelegate(this.OnBeginUpdateStreetStatus);
            }
            if ((this.onEndUpdateStreetStatusDelegate == null)) {
                this.onEndUpdateStreetStatusDelegate = new EndOperationDelegate(this.OnEndUpdateStreetStatus);
            }
            if ((this.onUpdateStreetStatusCompletedDelegate == null)) {
                this.onUpdateStreetStatusCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateStreetStatusCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateStreetStatusDelegate, new object[] {
                        username,
                        country,
                        city,
                        district,
                        street,
                        latitude,
                        longitude,
                        status}, this.onEndUpdateStreetStatusDelegate, this.onUpdateStreetStatusCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MobileLiveTraffic.LiveTrafficService.MobileService.BeginGetStreetStatus(string country, string city, string district, string street, double latitude, double longitude, string mode, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetStreetStatus(country, city, district, street, latitude, longitude, mode, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string MobileLiveTraffic.LiveTrafficService.MobileService.EndGetStreetStatus(System.IAsyncResult result) {
            return base.Channel.EndGetStreetStatus(result);
        }
        
        private System.IAsyncResult OnBeginGetStreetStatus(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string country = ((string)(inValues[0]));
            string city = ((string)(inValues[1]));
            string district = ((string)(inValues[2]));
            string street = ((string)(inValues[3]));
            double latitude = ((double)(inValues[4]));
            double longitude = ((double)(inValues[5]));
            string mode = ((string)(inValues[6]));
            return ((MobileLiveTraffic.LiveTrafficService.MobileService)(this)).BeginGetStreetStatus(country, city, district, street, latitude, longitude, mode, callback, asyncState);
        }
        
        private object[] OnEndGetStreetStatus(System.IAsyncResult result) {
            string retVal = ((MobileLiveTraffic.LiveTrafficService.MobileService)(this)).EndGetStreetStatus(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetStreetStatusCompleted(object state) {
            if ((this.GetStreetStatusCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetStreetStatusCompleted(this, new GetStreetStatusCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetStreetStatusAsync(string country, string city, string district, string street, double latitude, double longitude, string mode) {
            this.GetStreetStatusAsync(country, city, district, street, latitude, longitude, mode, null);
        }
        
        public void GetStreetStatusAsync(string country, string city, string district, string street, double latitude, double longitude, string mode, object userState) {
            if ((this.onBeginGetStreetStatusDelegate == null)) {
                this.onBeginGetStreetStatusDelegate = new BeginOperationDelegate(this.OnBeginGetStreetStatus);
            }
            if ((this.onEndGetStreetStatusDelegate == null)) {
                this.onEndGetStreetStatusDelegate = new EndOperationDelegate(this.OnEndGetStreetStatus);
            }
            if ((this.onGetStreetStatusCompletedDelegate == null)) {
                this.onGetStreetStatusCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetStreetStatusCompleted);
            }
            base.InvokeAsync(this.onBeginGetStreetStatusDelegate, new object[] {
                        country,
                        city,
                        district,
                        street,
                        latitude,
                        longitude,
                        mode}, this.onEndGetStreetStatusDelegate, this.onGetStreetStatusCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override MobileLiveTraffic.LiveTrafficService.MobileService CreateChannel() {
            return new MobileServiceClientChannel(this);
        }
        
        private class MobileServiceClientChannel : ChannelBase<MobileLiveTraffic.LiveTrafficService.MobileService>, MobileLiveTraffic.LiveTrafficService.MobileService {
            
            public MobileServiceClientChannel(System.ServiceModel.ClientBase<MobileLiveTraffic.LiveTrafficService.MobileService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = username;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("Login", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndLogin(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("Login", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUpdateStreetStatus(string username, string country, string city, string district, string street, double latitude, double longitude, string status, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[8];
                _args[0] = username;
                _args[1] = country;
                _args[2] = city;
                _args[3] = district;
                _args[4] = street;
                _args[5] = latitude;
                _args[6] = longitude;
                _args[7] = status;
                System.IAsyncResult _result = base.BeginInvoke("UpdateStreetStatus", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndUpdateStreetStatus(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("UpdateStreetStatus", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetStreetStatus(string country, string city, string district, string street, double latitude, double longitude, string mode, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[7];
                _args[0] = country;
                _args[1] = city;
                _args[2] = district;
                _args[3] = street;
                _args[4] = latitude;
                _args[5] = longitude;
                _args[6] = mode;
                System.IAsyncResult _result = base.BeginInvoke("GetStreetStatus", _args, callback, asyncState);
                return _result;
            }
            
            public string EndGetStreetStatus(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("GetStreetStatus", _args, result)));
                return _result;
            }
        }
    }
}
