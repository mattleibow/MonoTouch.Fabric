using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric.TwitterCore {
	[Static]
	partial interface Constants
	{
		// extern NSString *const TWTRErrorDomain;
		[Field ("TWTRErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// extern NSString *const TWTRAPIErrorDomain;
		[Field ("TWTRAPIErrorDomain", "__Internal")]
		NSString APIErrorDomain { get; }

		// extern NSString *const TWTRLogInErrorDomain;
		[Field ("TWTRLogInErrorDomain", "__Internal")]
		NSString LogInErrorDomain { get; }
	}

	// @interface TWTRAuthConfig : NSObject
	[BaseType (typeof(NSObject), Name = "TWTRAuthConfig")]
	[DisableDefaultCtor]
	public partial interface AuthConfig
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

	public interface IBaseSession { }

	// @protocol TWTRBaseSession <NSObject, NSCoding>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TWTRBaseSession")]
	public partial interface BaseSession : INSCoding
	{
	}

	public interface IAuthSession { }

	// @protocol TWTRAuthSession <TWTRBaseSession>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TWTRAuthSession")]
	public partial interface AuthSession : BaseSession
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

	public interface ICoreOAuthSigning { }

	// @protocol TWTRCoreOAuthSigning <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TWTRCoreOAuthSigning")]
	public partial interface CoreOAuthSigning
	{
		// extern NSString *const TWTROAuthEchoRequestURLStringKey;
		[Static]
		[Field ("TWTROAuthEchoRequestURLStringKey", "__Internal")]
		NSString URLStringKey { get; }

		// extern NSString *const TWTROAuthEchoAuthorizationHeaderKey;
		[Static]
		[Field ("TWTROAuthEchoAuthorizationHeaderKey", "__Internal")]
		NSString AuthorizationHeaderKey { get; }

		// @required -(NSDictionary *)OAuthEchoHeadersForRequestMethod:(NSString *)method URLString:(NSString *)URLString parameters:(NSDictionary *)parameters error:(NSError **)error __attribute__((nonnull(0, 1)));
		[Abstract]
		[Export ("OAuthEchoHeadersForRequestMethod:URLString:parameters:error:")]
		NSDictionary GetOAuthEchoHeaders (string method, string URLString, NSDictionary parameters, out NSError error);

		// @required -(NSDictionary *)OAuthEchoHeadersToVerifyCredentials;
		[Abstract]
		[Export ("OAuthEchoHeadersToVerifyCredentials")]
		NSDictionary GetOAuthEchoHeadersToVerifyCredentials ();
	}

	// typedef void (^TWTRGuestLogInCompletion)(TWTRGuestSession * _Nullable, NSError * _Nullable);
	public delegate void GuestLogInCompletion ([NullAllowed] GuestSession guestSession, [NullAllowed] NSError error);

	// @interface TWTRGuestSession : NSObject <TWTRBaseSession>
	[BaseType (typeof(NSObject), Name = "TWTRGuestSession")]
	[DisableDefaultCtor]
	public partial interface GuestSession : BaseSession
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
	public delegate void LogInCompletion ([NullAllowed] Session session, [NullAllowed] NSError error);

	// @interface TWTRSession : NSObject <TWTRAuthSession>
	[BaseType (typeof(NSObject), Name = "TWTRSession")]
	[DisableDefaultCtor]
	public partial interface Session : AuthSession
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
	public delegate void SessionStoreRefreshCompletion ([NullAllowed] NSObject refreshedSession, [NullAllowed] NSError error);

	public interface ISessionRefreshingStore { }

	// @protocol TWTRSessionRefreshingStore <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TWTRSessionRefreshingStore")]
	public partial interface SessionRefreshingStore
	{
		// @required -(void)refreshSessionClass:(Class _Nonnull)sessionClass sessionID:(NSString * _Nullable)sessionID completion:(TWTRSessionStoreRefreshCompletion _Nonnull)completion;
		[Abstract]
		[Export ("refreshSessionClass:sessionID:completion:")]
		void RefreshSessionClass (Class sessionClass, [NullAllowed] string sessionID, SessionStoreRefreshCompletion completion);

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
	public delegate void SessionStoreSaveCompletion ([NullAllowed] IAuthSession session, [NullAllowed] NSError error);

	// typedef void (^TWTRSessionStoreBatchFetchCompletion)(NSArray * _Nonnull);
	public delegate void SessionStoreBatchFetchCompletion (NSObject[] sessions);

	// typedef void (^TWTRSessionStoreDeleteCompletion)(id<TWTRAuthSession> _Nullable);
	public delegate void SessionStoreDeleteCompletion ([NullAllowed] IAuthSession session);

	public interface IUserSessionStore { }

	// @protocol TWTRUserSessionStore <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TWTRUserSessionStore")]
	public partial interface UserSessionStore
	{
		// @required -(void)saveSession:(id<TWTRAuthSession> _Nonnull)session completion:(TWTRSessionStoreSaveCompletion _Nonnull)completion;
		[Abstract]
		[Export ("saveSession:completion:")]
		void SaveSession (IAuthSession session, SessionStoreSaveCompletion completion);

		// @required -(void)saveSessionWithAuthToken:(NSString * _Nonnull)authToken authTokenSecret:(NSString * _Nonnull)authTokenSecret completion:(TWTRSessionStoreSaveCompletion _Nonnull)completion;
		[Abstract]
		[Export ("saveSessionWithAuthToken:authTokenSecret:completion:")]
		void SaveSession (string authToken, string authTokenSecret, SessionStoreSaveCompletion completion);

		// @required -(id<TWTRAuthSession> _Nullable)sessionForUserID:(NSString * _Nonnull)userID;
		[Abstract]
		[Export ("sessionForUserID:")]
		[return: NullAllowed]
		IAuthSession SessionForUserID (string userID);

		// @required -(NSArray * _Nonnull)existingUserSessions;
		[Abstract]
		[Export ("existingUserSessions")]
		NSObject[] ExistingUserSessions { get; }

		// @required -(id<TWTRAuthSession> _Nullable)session;
		[Abstract]
		[NullAllowed, Export ("session")]
		IAuthSession Session { get; }

		// @required -(void)logOutUserID:(NSString * _Nonnull)userID;
		[Abstract]
		[Export ("logOutUserID:")]
		void LogOutUserID (string userID);
	}

	// typedef void (^TWTRSessionGuestLogInCompletion)(TWTRGuestSession * _Nullable, NSError * _Nullable);
	public delegate void SessionGuestLogInCompletion ([NullAllowed] GuestSession guestSession, [NullAllowed] NSError error);

	public interface IGuestSessionStore { }

	// @protocol TWTRGuestSessionStore <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TWTRGuestSessionStore")]
	public partial interface GuestSessionStore
	{
		// @required -(void)fetchGuestSessionWithCompletion:(TWTRSessionGuestLogInCompletion _Nonnull)completion;
		[Abstract]
		[Export ("fetchGuestSessionWithCompletion:")]
		void FetchGuestSession (SessionGuestLogInCompletion completion);
	}

	public interface ISessionStore { }

	// @protocol TWTRSessionStore <TWTRUserSessionStore, TWTRGuestSessionStore, TWTRSessionRefreshingStore>
	[Protocol (Name = "TWTRSessionStore"), Model]
	public partial interface SessionStore : UserSessionStore, GuestSessionStore, SessionRefreshingStore
	{
		// @required @property (readonly, nonatomic) TWTRAuthConfig * _Nonnull authConfig;
		[Export ("authConfig")]
		AuthConfig AuthConfig { get; }
	}

	// @interface TWTRSessionStore : NSObject <TWTRSessionStore>
	[BaseType (typeof(NSObject), Name = "TWTRSessionStore")]
	[DisableDefaultCtor]
	public partial interface SessionStoreImpl : SessionStore
	{
		// -(void)reloadSessionStore;
		[Export ("reloadSessionStore")]
		void ReloadSessionStore ();
	}
}