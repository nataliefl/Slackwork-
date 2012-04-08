// Type: System.ServiceModel.Channels.ChannelWrapper`2
// Assembly: System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.ServiceModel.dll

using System;
using System.Runtime;

namespace System.ServiceModel.Channels
{
    internal abstract class ChannelWrapper<TChannel, TItem> : LayeredChannel<TChannel> where TChannel : class, IChannel where TItem : class, IDisposable
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ChannelWrapper(ChannelManagerBase channelManager, TChannel innerChannel, TItem firstItem);

        protected abstract void CloseFirstItem(TimeSpan timeout);
        protected TItem GetFirstItem();
        protected bool HaveFirstItem();
        protected override void OnAbort();
        protected override void OnClose(TimeSpan timeout);
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state);
        protected override void OnEndClose(IAsyncResult result);

        protected class ReceiveAsyncResult : AsyncResult
        {
            public ReceiveAsyncResult(TItem item, AsyncCallback callback, object state);
            public static TItem End(IAsyncResult result);
        }

        protected class WaitAsyncResult : AsyncResult
        {
            public WaitAsyncResult(AsyncCallback callback, object state);
            public static bool End(IAsyncResult result);
        }
    }
}
