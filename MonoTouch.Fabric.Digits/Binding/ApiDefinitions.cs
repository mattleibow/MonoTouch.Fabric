using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using MonoTouch.Fabric.TwitterCore;

namespace MonoTouch.Fabric.Digits
{
	// @interface DGTAPIClient : NSObject
	[BaseType (typeof(NSObject), Name = "DGTAPIClient")]
	public partial interface APIClient {
		// -(void)authenticateWithConfiguration:(DGTAuthenticationConfiguration *)configuration delegate:(id<DGTAPIAuthenticationDelegate>)authDelegate completion:(DGTAuthenticationCompletion)completionBlock;
		[Export ("authenticateWithConfiguration:delegate:completion:")]
		void Authenticate(AuthenticationConfiguration configuration, IAPIAuthenticationDelegate authDelegate, AuthenticationCompletion completionBlock);
	}

	public interface IAPIAuthenticationDelegate { }

	// @protocol DGTAPIAuthenticationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "DGTAPIAuthenticationDelegate")]
	public partial interface APIAuthenticationDelegate {
		// @required -(void)challengeViewController:(UIViewController<DGTAPIChallengeDelegate> *)challengeViewController error:(NSError *)error;
		[Abstract]
		[Export ("challengeViewController:error:")]
		void ChallengeViewController(UIViewController challengeViewController, NSError error);

		// @optional - (UIViewController<DGTAPIChallengeDelegate> *)signUpViewControllerWithDeviceRegisterResponse:(DGTDeviceRegisterResponse *)deviceRegisterResponse;
//		[Export ("signUpViewControllerWithDeviceRegisterResponse:")]
//		UIViewController SignUpViewControllerWithDeviceRegisterResponse(DGTDeviceRegisterResponse deviceRegisterResponse);

		// @optional - (UIViewController<DGTAPIChallengeDelegate> *)logInViewControllerWithLogInResponse:(DGTLogInAuthResponse *)logInResponse;
//		[Export ("logInViewControllerWithLogInResponse:")]
//		UIViewController LogInViewControllerWithLogInResponse(DGTLogInAuthResponse logInResponse);
	}

	// @interface DGTAppearance : NSObject <NSCopying>
	[BaseType (typeof(NSObject), Name = "DGTAppearance")]
	public partial interface Appearance : INSCopying {
		// @property (nonatomic, strong) UIColor * backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * accentColor;
		[Export ("accentColor", ArgumentSemantic.Strong)]
		UIColor AccentColor { get; set; }

		// @property (nonatomic, strong) UIFont * headerFont;
		[Export ("headerFont", ArgumentSemantic.Strong)]
		UIFont HeaderFont { get; set; }

		// @property (nonatomic, strong) UIFont * labelFont;
		[Export ("labelFont", ArgumentSemantic.Strong)]
		UIFont LabelFont { get; set; }

		// @property (nonatomic, strong) UIFont * bodyFont;
		[Export ("bodyFont", ArgumentSemantic.Strong)]
		UIFont BodyFont { get; set; }

		// @property (nonatomic, strong) UIImage * logoImage;
		[Export ("logoImage", ArgumentSemantic.Strong)]
		UIImage LogoImage { get; set; }
	}

	// @interface DGTAuthenticateButton : UIButton
	[BaseType (typeof(UIButton), Name = "DGTAuthenticateButton")]
	public partial interface AuthenticateButton {
		// + (instancetype)buttonWithAuthenticationCompletion:(DGTAuthenticationCompletion)completion;
		[Static]
		[Export ("buttonWithAuthenticationCompletion:")]
		AuthenticateButton Create(AuthenticationCompletion completion);

		// @property (nonatomic, copy) DGTAppearance *digitsAppearance;
		[Export ("digitsAppearance", ArgumentSemantic.Copy)]
		Appearance DigitsAppearance { get; set; }
	}
		
	// @interface DGTAuthenticationConfiguration : NSObject <NSCopying>
	[BaseType (typeof(NSObject), Name = "DGTAuthenticationConfiguration")]
	[DisableDefaultCtor]
	public partial interface AuthenticationConfiguration : INSCopying {
		// @property (nonatomic, strong) DGTAppearance *appearance;
		[Export ("appearance", ArgumentSemantic.Strong)]
		Appearance Appearance { get; set; }

		// @property (nonatomic, strong) NSString *phoneNumber;
		[ExportAttribute ("phoneNumber", ArgumentSemantic.Strong)]
		string PhoneNumber { get; set; }

		// @property (nonatomic, strong) NSString *title;
		[ExportAttribute ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// -(instancetype)initWithAccountFields:(DGTAccountFields)accountFields;
		[Export ("initWithAccountFields:")]
		IntPtr Constructor (AccountFields accountFields);
	}
		
	public interface ICompletionViewController { }

	// @protocol DGTCompletionViewController <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "DGTCompletionViewController")]
	public partial interface CompletionViewController {
		// -(void)digitsAuthenticationFinishedWithSession:(DGTSession *)session error:(NSError *)error;
		[Export ("digitsAuthenticationFinishedWithSession:error:")]
		void DigitsAuthenticationFinished(Session session, NSError error);
	}

	// typedef void (^DGTUploadContactsCompletion)(DGTContactsUploadResult *result, NSError *error);
	public delegate void UploadContactsCompletion(ContactsUploadResult result, NSError error);

	// typedef void (^DGTLookupContactsCompletion)(NSArray *matches, NSString *nextCursor, NSError *error);
	public delegate void LookupContactsCompletion(NSArray matches, string nextCursor, NSError error);

	// typedef void (^DGTDeleteAllUploadedContactsCompletion)(NSError *error);
	public delegate void DeleteAllUploadedContactsCompletion(NSError error);

	// @interface DGTContacts : NSObject
	[BaseType (typeof(NSObject), Name = "DGTContacts")]
	[DisableDefaultCtor]
	public partial interface Contacts {
		// + (DGTContactAccessAuthorizationStatus)contactsAccessAuthorizationStatus;
		[Static]
		[Export ("contactsAccessAuthorizationStatus")]
		ContactAccessAuthorizationStatus AccessAuthorizationStatus { get; }

		// - (instancetype)initWithUserSession:(DGTSession *)userSession;
		[Export ("initWithUserSession:")]
		IntPtr Constructor (Session userSession);

		// - (void)startContactsUploadWithCompletion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithCompletion:")]
		void StartContactsUpload(UploadContactsCompletion completion);

		// - (void)startContactsUploadWithTitle:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithTitle:completion:")]
		void StartContactsUpload(string title, UploadContactsCompletion completion);

		// - (void)startContactsUploadWithPresenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithPresenterViewController:title:completion:")]
		void StartContactsUpload(UIViewController presenterViewController, string title, UploadContactsCompletion completion);

		// - (void)startContactsUploadWithDigitsAppearance:(DGTAppearance *)appearance presenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithDigitsAppearance:presenterViewController:title:completion:")]
		void StartContactsUpload(Appearance appearance, UIViewController presenterViewController, string title, UploadContactsCompletion completion);

		// - (void)lookupContactMatchesWithCursor:(NSString *)cursor completion:(DGTLookupContactsCompletion)completion;
		[Export ("lookupContactMatchesWithCursor:completion:")]
		void LookupContactMatches(string cursor, LookupContactsCompletion completion);

		// - (void)deleteAllUploadedContactsWithCompletion:(DGTDeleteAllUploadedContactsCompletion)completion;
		[Export ("deleteAllUploadedContactsWithCompletion:")]
		void DeleteAllUploadedContacts(DeleteAllUploadedContactsCompletion completion);
	}

	// @interface DGTContactsUploadResult : NSObject
	[BaseType (typeof(NSObject), Name = "DGTContactsUploadResult")]
	[DisableDefaultCtor]
	public partial interface ContactsUploadResult {
		// @property (nonatomic, readonly) NSUInteger totalContacts;
		[Export ("totalContacts")]
		nuint TotalContacts { get; }

		// @property (nonatomic, readonly) NSUInteger numberOfUploadedContacts;
		[Export ("numberOfUploadedContacts")]
		nuint NumberOfUploadedContacts { get; }
	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const DGTErrorDomain;
		[Field ("DGTErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }
	}

	// @interface DGTOAuthSigning : NSObject <TWTRCoreOAuthSigning>
	[BaseType (typeof(NSObject), Name = "DGTOAuthSigning")]
	[DisableDefaultCtor]
	public partial interface OAuthSigning : ICoreOAuthSigning {
		// - (instancetype)initWithAuthConfig:(TWTRAuthConfig *)authConfig authSession:(DGTSession *)authSession NS_DESIGNATED_INITIALIZER;
		[Export ("initWithAuthConfig:authSession:")]
		IntPtr Constructor (AuthConfig authConfig, Session authSession);

		// - (NSDictionary *)OAuthEchoHeadersToVerifyCredentialsWithParams:(NSDictionary *)params;
		[Export ("OAuthEchoHeadersToVerifyCredentialsWithParams:")]
		NSDictionary GetHeadersToVerifyCredentials(NSDictionary parameters);
	}


	// @interface DGTSession : NSObject <TWTRAuthSession>
	[BaseType (typeof(NSObject), Name = "DGTSession")]
	[DisableDefaultCtor]
	public partial interface Session : IAuthSession, INSCoding {
		// @property (nonatomic, copy, readonly) NSString *authToken;
		[ExportAttribute ("authToken", ArgumentSemantic.Copy)]
		string AuthToken { get; }

		// @property (nonatomic, copy, readonly) NSString *authTokenSecret;
		[ExportAttribute ("authTokenSecret", ArgumentSemantic.Copy)]
		string AuthTokenSecret { get; }

		// @property (nonatomic, copy, readonly) NSString *userID;
		[ExportAttribute ("userID", ArgumentSemantic.Copy)]
		string UserID { get; }

		// @property (nonatomic, copy, readonly) NSString *phoneNumber;
		[ExportAttribute ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; }

		// @property (nonatomic, copy, readonly) NSString *emailAddress;
		[ExportAttribute ("emailAddress", ArgumentSemantic.Copy)]
		string EmailAddress { get; }

		// @property (nonatomic, readonly) BOOL emailAddressIsVerified;
		[ExportAttribute ("emailAddressIsVerified")]
		bool EmailAddressIsVerified { get; }

		// - (instancetype)initWithAuthToken:(NSString *)authToken authTokenSecret:(NSString *)authTokenSecret userID:(NSString *)userID phoneNumber:(NSString *)phoneNumber;
		[Export ("initWithAuthToken:authTokenSecret:userID:phoneNumber:")]
		IntPtr Constructor (string authToken, string authTokenSecret, string userID, string phoneNumber);

		// - (instancetype)initWithAuthToken:(NSString *)authToken authTokenSecret:(NSString *)authTokenSecret userID:(NSString *)userID phoneNumber:(NSString *)phoneNumber emailAddress:(NSString *)emailAddress emailAddressIsVerified:(BOOL)emailAddressIsVerified;
		[Export ("initWithAuthToken:authTokenSecret:userID:phoneNumber:emailAddress:emailAddressIsVerified:")]
		IntPtr Constructor (string authToken, string authTokenSecret, string userID, string phoneNumber, string emailAddress, bool emailAddressIsVerified);
	}

	// typedef void (^DGTAuthenticationCompletion)(DGTSession *, NSError *);
	public delegate void AuthenticationCompletion (Session session, NSError error);

	public interface ISessionUpdateDelegate { }

	// @protocol DGTSessionUpdateDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "DGTSessionUpdateDelegate")]
	public partial interface SessionUpdateDelegate {
		// -(void)digitsSessionHasChanged:(DGTSession *)newSession;
		[Abstract]
		[Export ("digitsSessionHasChanged:")]
		void DigitsSessionHasChanged(Session newSession);

		// -(void)digitsSessionExpiredForUserID:(NSString *)userID;
		[Abstract]
		[Export ("digitsSessionExpiredForUserID:")]
		void DigitsSessionExpiredForUserID(string userID);
	}

	// @interface DGTUser : NSObject
	[BaseType (typeof(NSObject), Name = "DGTUser")]
	public partial interface User {
		// @property (nonatomic, copy, readonly) NSString *userID;
		[Export ("userID", ArgumentSemantic.Copy)]
		string UserID { get; }
	}

	// @interface Digits : NSObject
	[BaseType (typeof(NSObject), Name = "Digits")]
	partial interface Digits
	{
		// +(Digits * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		Digits SharedInstance { get; }

		// -(void)startWithConsumerKey:(NSString * _Nonnull)consumerKey consumerSecret:(NSString * _Nonnull)consumerSecret;
		[Export ("startWithConsumerKey:consumerSecret:")]
		void StartWithConsumerKey (string consumerKey, string consumerSecret);

		// -(void)startWithConsumerKey:(NSString * _Nonnull)consumerKey consumerSecret:(NSString * _Nonnull)consumerSecret accessGroup:(id)accessGroup;
		[Export ("startWithConsumerKey:consumerSecret:accessGroup:")]
		void StartWithConsumerKey (string consumerKey, string consumerSecret, NSObject accessGroup);

		// -(id)session;
		[Export ("session")]
		Session Session { get; }

		// @property (readonly, nonatomic, strong) TWTRAuthConfig * _Nonnull authConfig;
		[Export ("authConfig", ArgumentSemantic.Strong)]
		AuthConfig AuthConfig { get; }

		// @property (nonatomic, weak) id<DGTSessionUpdateDelegate> _Nullable sessionUpdateDelegate;
		[NullAllowed, Export ("sessionUpdateDelegate", ArgumentSemantic.Weak)]
		ISessionUpdateDelegate SessionUpdateDelegate { get; set; }

		// -(void)authenticateWithCompletion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
		[Export ("authenticateWithCompletion:")]
		void Authenticate (AuthenticationCompletion completion);

		// -(void)authenticateWithTitle:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithTitle:completion:")]
		void Authenticate (NSObject title, AuthenticationCompletion completion);

		// -(void)authenticateWithViewController:(id)viewController title:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithViewController:title:completion:")]
		void Authenticate (NSObject viewController, NSObject title, AuthenticationCompletion completion);

		// -(void)authenticateWithDigitsAppearance:(id)appearance viewController:(id)viewController title:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithDigitsAppearance:viewController:title:completion:")]
		void Authenticate (NSObject appearance, NSObject viewController, NSObject title, AuthenticationCompletion completion);

		// -(void)authenticateWithPhoneNumber:(id)phoneNumber digitsAppearance:(id)appearance viewController:(id)viewController title:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithPhoneNumber:digitsAppearance:viewController:title:completion:")]
		void Authenticate (NSObject phoneNumber, NSObject appearance, NSObject viewController, NSObject title, AuthenticationCompletion completion);

		// -(void)authenticateWithNavigationViewController:(UINavigationController * _Nonnull)navigationController phoneNumber:(id)phoneNumber digitsAppearance:(id)appearance title:(id)title completionViewController:(UIViewController<DGTCompletionViewController> * _Nonnull)completionViewController __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithNavigationViewController:configuration:completionViewController: instead.")));
		[Export ("authenticateWithNavigationViewController:phoneNumber:digitsAppearance:title:completionViewController:")]
		void Authenticate (UINavigationController navigationController, NSObject phoneNumber, NSObject appearance, NSObject title, ICompletionViewController completionViewController);

		// -(void)authenticateWithViewController:(id)viewController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
		[Export ("authenticateWithViewController:configuration:completion:")]
		void Authenticate (NSObject viewController, AuthenticationConfiguration configuration, AuthenticationCompletion completion);

		// -(void)authenticateWithNavigationViewController:(UINavigationController * _Nonnull)navigationController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completionViewController:(UIViewController<DGTCompletionViewController> * _Nonnull)completionViewController __attribute__((availability(tvos, unavailable)));
		[Export ("authenticateWithNavigationViewController:configuration:completionViewController:")]
		void Authenticate (UINavigationController navigationController, AuthenticationConfiguration configuration, ICompletionViewController completionViewController);

		// -(void)logOut;
		[Export ("logOut")]
		void LogOut ();
	}
}