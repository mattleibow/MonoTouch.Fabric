using System;

namespace MonoTouch.Fabric.TwitterCore
{
	public static class SessionRefreshingStoreExtensions
	{
		public static void RefreshSessionClass (this ISessionRefreshingStore store, Type sessionClass, string sessionID, SessionStoreRefreshCompletion completion)
		{
			store.RefreshSessionClass (new ObjCRuntime.Class (sessionClass), sessionID, completion);
		}
	}
}
