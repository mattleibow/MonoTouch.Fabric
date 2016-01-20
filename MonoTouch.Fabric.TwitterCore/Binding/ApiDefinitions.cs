using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric.TwitterCore {
	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRAPIErrorDomain;
		[Field ("TWTRAPIErrorDomain", "__Internal")]
		NSString TWTRAPIErrorDomain { get; }
	}

	// @interface TWTRAuthConfig : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface TWTRAuthConfig
	{
		// @property (readonly, copy, nonatomic) NSString * consumerKey;
		[Export ("consumerKey")]
		string ConsumerKey { get; }

		// @property (readonly, copy, nonatomic) NSString * consumerSecret;
		[Export ("consumerSecret")]
		string ConsumerSecret { get; }

		// -(instancetype)initWithConsumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret;
		[Export ("initWithConsumerKey:consumerSecret:")]
		IntPtr Constructor (string consumerKey, string consumerSecret);
	}

	// @protocol TWTRBaseSession <NSObject, NSCoding>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface TWTRBaseSession : INSCoding
	{
	}

	// @protocol TWTRAuthSession <TWTRBaseSession>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface TWTRAuthSession : TWTRBaseSession
	{
		// @required @property (readonly, copy, nonatomic) NSString * authToken;
		[Export ("authToken")]
		string AuthToken { get; }

		// @required @property (readonly, copy, nonatomic) NSString * authTokenSecret;
		[Export ("authTokenSecret")]
		string AuthTokenSecret { get; }

		// @required @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserID { get; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRErrorDomain;
		[Field ("TWTRErrorDomain", "__Internal")]
		NSString TWTRErrorDomain { get; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTRLogInErrorDomain;
		[Field ("TWTRLogInErrorDomain", "__Internal")]
		NSString TWTRLogInErrorDomain { get; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWTROAuthEchoRequestURLStringKey;
		[Field ("TWTROAuthEchoRequestURLStringKey", "__Internal")]
		NSString TWTROAuthEchoRequestURLStringKey { get; }

		// extern NSString *const TWTROAuthEchoAuthorizationHeaderKey;
		[Field ("TWTROAuthEchoAuthorizationHeaderKey", "__Internal")]
		NSString TWTROAuthEchoAuthorizationHeaderKey { get; }
	}

	// @protocol TWTRCoreOAuthSigning <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface TWTRCoreOAuthSigning
	{
		// @required -(NSDictionary *)OAuthEchoHeadersForRequestMethod:(NSString *)method URLString:(NSString *)URLString parameters:(NSDictionary *)parameters error:(NSError **)error __attribute__((nonnull(0, 1)));
		[Abstract]
		[Export ("OAuthEchoHeadersForRequestMethod:URLString:parameters:error:")]
		NSDictionary URLString (string method, string URLString, NSDictionary parameters, out NSError error);

		// @required -(NSDictionary *)OAuthEchoHeadersToVerifyCredentials;
		[Abstract]
		[Export ("OAuthEchoHeadersToVerifyCredentials")]
//		[Verify (MethodToProperty)]
		NSDictionary OAuthEchoHeadersToVerifyCredentials { get; }
	}

	// typedef void (^TWTRGuestLogInCompletion)(TWTRGuestSession * _Nullable, NSError * _Nullable);
	delegate void TWTRGuestLogInCompletion ([NullAllowed] TWTRGuestSession arg0, [NullAllowed] NSError arg1);

	// @interface TWTRGuestSession : NSObject <TWTRBaseSession>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface TWTRGuestSession : TWTRBaseSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull guestToken;
		[Export ("guestToken")]
		string GuestToken { get; }

		// -(instancetype _Nonnull)initWithSessionDictionary:(NSDictionary * _Nonnull)sessionDictionary;
		[Export ("initWithSessionDictionary:")]
		IntPtr Constructor (NSDictionary sessionDictionary);

		// -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nonnull)accessToken guestToken:(NSString * _Nullable)guestToken __attribute__((objc_designated_initializer));
		[Export ("initWithAccessToken:guestToken:")]
		[DesignatedInitializer]
		IntPtr Constructor (string accessToken, [NullAllowed] string guestToken);
	}

	// typedef void (^TWTRLogInCompletion)(TWTRSession * _Nullable, NSError * _Nullable);
	delegate void TWTRLogInCompletion ([NullAllowed] TWTRSession arg0, [NullAllowed] NSError arg1);

	// @interface TWTRSession : NSObject <TWTRAuthSession>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface TWTRSession : TWTRAuthSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull authToken;
		[Export ("authToken")]
		string AuthToken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull authTokenSecret;
		[Export ("authTokenSecret")]
		string AuthTokenSecret { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userName;
		[Export ("userName")]
		string UserName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
		[Export ("userID")]
		string UserID { get; }

		// -(instancetype _Nonnull)initWithSessionDictionary:(NSDictionary * _Nonnull)sessionDictionary;
		[Export ("initWithSessionDictionary:")]
		IntPtr Constructor (NSDictionary sessionDictionary);

		// -(instancetype _Nonnull)initWithAuthToken:(NSString * _Nonnull)authToken authTokenSecret:(NSString * _Nonnull)authTokenSecret userName:(NSString * _Nonnull)userName userID:(NSString * _Nonnull)userID __attribute__((objc_designated_initializer));
		[Export ("initWithAuthToken:authTokenSecret:userName:userID:")]
		[DesignatedInitializer]
		IntPtr Constructor (string authToken, string authTokenSecret, string userName, string userID);
	}

	// typedef void (^TWTRSessionStoreRefreshCompletion)(id _Nullable, NSError * _Nullable);
	public delegate void TWTRSessionStoreRefreshCompletion ([NullAllowed] NSObject arg0, [NullAllowed] NSError arg1);

	// @protocol TWTRSessionRefreshingStore <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface TWTRSessionRefreshingStore
	{
		// @required -(void)refreshSessionClass:(Class _Nonnull)sessionClass sessionID:(NSString * _Nullable)sessionID completion:(TWTRSessionStoreRefreshCompletion _Nonnull)completion;
		[Abstract]
		[Export ("refreshSessionClass:sessionID:completion:")]
		void RefreshSessionClass (Class sessionClass, [NullAllowed] string sessionID, TWTRSessionStoreRefreshCompletion completion);

		// @required -(BOOL)isExpiredSession:(id _Nonnull)session response:(NSHTTPURLResponse * _Nonnull)response;
		[Abstract]
		[Export ("isExpiredSession:response:")]
		bool IsExpiredSession (NSObject session, NSHttpUrlResponse response);

		// @required -(BOOL)isExpiredSession:(id _Nonnull)session error:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("isExpiredSession:error:")]
		bool IsExpiredSession (NSObject session, NSError error);
	}

	// typedef void (^TWTRSessionStoreSaveCompletion)(id<TWTRAuthSession> _Nullable, NSError * _Nullable);
	public delegate void TWTRSessionStoreSaveCompletion ([NullAllowed] TWTRAuthSession arg0, [NullAllowed] NSError arg1);

	// typedef void (^TWTRSessionStoreBatchFetchCompletion)(NSArray * _Nonnull);
	public delegate void TWTRSessionStoreBatchFetchCompletion (NSObject[] arg0);

	// typedef void (^TWTRSessionStoreDeleteCompletion)(id<TWTRAuthSession> _Nullable);
	public delegate void TWTRSessionStoreDeleteCompletion ([NullAllowed] TWTRAuthSession arg0);

	// @protocol TWTRUserSessionStore <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface TWTRUserSessionStore
	{
		// @required -(void)saveSession:(id<TWTRAuthSession> _Nonnull)session completion:(TWTRSessionStoreSaveCompletion _Nonnull)completion;
		[Abstract]
		[Export ("saveSession:completion:")]
		void SaveSession (TWTRAuthSession session, TWTRSessionStoreSaveCompletion completion);

		// @required -(void)saveSessionWithAuthToken:(NSString * _Nonnull)authToken authTokenSecret:(NSString * _Nonnull)authTokenSecret completion:(TWTRSessionStoreSaveCompletion _Nonnull)completion;
		[Abstract]
		[Export ("saveSessionWithAuthToken:authTokenSecret:completion:")]
		void SaveSessionWithAuthToken (string authToken, string authTokenSecret, TWTRSessionStoreSaveCompletion completion);

		// @required -(id<TWTRAuthSession> _Nullable)sessionForUserID:(NSString * _Nonnull)userID;
		[Abstract]
		[Export ("sessionForUserID:")]
		[return: NullAllowed]
		TWTRAuthSession SessionForUserID (string userID);

		// @required -(NSArray * _Nonnull)existingUserSessions;
		[Abstract]
		[Export ("existingUserSessions")]
//		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] ExistingUserSessions { get; }

		// @required -(id<TWTRAuthSession> _Nullable)session;
		[Abstract]
		[NullAllowed, Export ("session")]
//		[Verify (MethodToProperty)]
		TWTRAuthSession Session { get; }

		// @required -(void)logOutUserID:(NSString * _Nonnull)userID;
		[Abstract]
		[Export ("logOutUserID:")]
		void LogOutUserID (string userID);
	}

	// typedef void (^TWTRSessionGuestLogInCompletion)(TWTRGuestSession * _Nullable, NSError * _Nullable);
	public delegate void TWTRSessionGuestLogInCompletion ([NullAllowed] TWTRGuestSession arg0, [NullAllowed] NSError arg1);

	// @protocol TWTRGuestSessionStore <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface TWTRGuestSessionStore
	{
		// @required -(void)fetchGuestSessionWithCompletion:(TWTRSessionGuestLogInCompletion _Nonnull)completion;
		[Abstract]
		[Export ("fetchGuestSessionWithCompletion:")]
		void FetchGuestSessionWithCompletion (TWTRSessionGuestLogInCompletion completion);
	}

	// @protocol TWTRSessionStore <TWTRUserSessionStore, TWTRGuestSessionStore, TWTRSessionRefreshingStore>
	[Protocol, Model]
	public partial interface TWTRSessionStore : TWTRUserSessionStore, TWTRGuestSessionStore, TWTRSessionRefreshingStore
	{
		// @required @property (readonly, nonatomic) TWTRAuthConfig * _Nonnull authConfig;
		[Export ("authConfig")]
		TWTRAuthConfig AuthConfig { get; }
	}

	// @interface TWTRSessionStore : NSObject <TWTRSessionStore>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface TWTRSessionStoreImpl : TWTRSessionStore
	{
		// -(void)reloadSessionStore;
		[Export ("reloadSessionStore")]
		void ReloadSessionStore ();
	}
}