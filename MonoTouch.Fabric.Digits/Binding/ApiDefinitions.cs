using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using MonoTouch.Fabric.TwitterCore;

namespace MonoTouch.Fabric.Digits
{
	// @interface DGTAPIClient : NSObject
	[BaseType (typeof(NSObject))]
	public partial interface DGTAPIClient {
		// - (instancetype)init;
//		[Export ("init")]
//		IntPtr Constructor ();

		// -(void)authenticateWithConfiguration:(DGTAuthenticationConfiguration *)configuration delegate:(id<DGTAPIAuthenticationDelegate>)authDelegate completion:(DGTAuthenticationCompletion)completionBlock;
		[Export ("authenticateWithConfiguration:delegate:completion:")]
		void AuthenticateWithConfiguration(DGTAuthenticationConfiguration configuration, DGTAPIAuthenticationDelegate authDelegate, DGTAuthenticationCompletion completionBlock);
	}

	// @protocol DGTAPIAuthenticationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface DGTAPIAuthenticationDelegate {
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
	[BaseType (typeof(NSObject))]
	public partial interface DGTAppearance : INSCopying {
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
	[BaseType (typeof(UIButton))]
	public partial interface DGTAuthenticateButton {
		// + (instancetype)buttonWithAuthenticationCompletion:(DGTAuthenticationCompletion)completion;
		[Static]
		[Export ("buttonWithAuthenticationCompletion:")]
		DGTAuthenticateButton ButtonWithAuthenticationCompletion(DGTAuthenticationCompletion completion);

		// @property (nonatomic, copy) DGTAppearance *digitsAppearance;
		[Export ("digitsAppearance", ArgumentSemantic.Copy)]
		DGTAppearance DigitsAppearance { get; set; }
	}
		
	// @interface DGTAuthenticationConfiguration : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface DGTAuthenticationConfiguration : INSCopying {
		// @property (nonatomic, strong) DGTAppearance *appearance;
		[Export ("appearance", ArgumentSemantic.Strong)]
		DGTAppearance Appearance { get; set; }

		// @property (nonatomic, strong) NSString *phoneNumber;
		[ExportAttribute ("phoneNumber", ArgumentSemantic.Strong)]
		string PhoneNumber { get; set; }

		// @property (nonatomic, strong) NSString *title;
		[ExportAttribute ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// -(instancetype)initWithAccountFields:(DGTAccountFields)accountFields;
		[Export ("initWithAccountFields:")]
		IntPtr Constructor (DGTAccountFields accountFields);
	}
		
	// @protocol DGTCompletionViewController <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface DGTCompletionViewController {
		// -(void)digitsAuthenticationFinishedWithSession:(DGTSession *)session error:(NSError *)error;
		[Export ("digitsAuthenticationFinishedWithSession:error:")]
		void DigitsAuthenticationFinishedWithSession(DGTSession session, NSError error);
	}

	// typedef void (^DGTUploadContactsCompletion)(DGTContactsUploadResult *result, NSError *error);
	public delegate void DGTUploadContactsCompletion(DGTContactsUploadResult result, NSError error);

	// typedef void (^DGTLookupContactsCompletion)(NSArray *matches, NSString *nextCursor, NSError *error);
	public delegate void DGTLookupContactsCompletion(NSArray matches, string nextCursor, NSError error);

	// typedef void (^DGTDeleteAllUploadedContactsCompletion)(NSError *error);
	public delegate void DGTDeleteAllUploadedContactsCompletion(NSError error);

	// @interface DGTContacts : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface DGTContacts {
		// + (DGTContactAccessAuthorizationStatus)contactsAccessAuthorizationStatus;
		[Static]
		[Export ("contactsAccessAuthorizationStatus")]
		DGTContactAccessAuthorizationStatus ContactsAccessAuthorizationStatus { get; }

		// - (instancetype)initWithUserSession:(DGTSession *)userSession;
		[Export ("initWithUserSession:")]
		IntPtr Constructor (DGTSession userSession);

		// - (void)startContactsUploadWithCompletion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithCompletion:")]
		void StartContactsUploadWithCompletion(DGTUploadContactsCompletion completion);

		// - (void)startContactsUploadWithTitle:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithTitle:completion:")]
		void StartContactsUploadWithTitle(string title, DGTUploadContactsCompletion completion);

		// - (void)startContactsUploadWithPresenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithPresenterViewController:title:completion:")]
		void StartContactsUploadWithPresenterViewController(UIViewController presenterViewController, string title, DGTUploadContactsCompletion completion);

		// - (void)startContactsUploadWithDigitsAppearance:(DGTAppearance *)appearance presenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
		[Export ("startContactsUploadWithDigitsAppearance:presenterViewController:title:completion:")]
		void StartContactsUploadWithDigitsAppearance(DGTAppearance appearance, UIViewController presenterViewController, string title, DGTUploadContactsCompletion completion);

		// - (void)lookupContactMatchesWithCursor:(NSString *)cursor completion:(DGTLookupContactsCompletion)completion;
		[Export ("lookupContactMatchesWithCursor:completion:")]
		void LookupContactMatchesWithCursor(string cursor, DGTLookupContactsCompletion completion);

		// - (void)deleteAllUploadedContactsWithCompletion:(DGTDeleteAllUploadedContactsCompletion)completion;
		[Export ("deleteAllUploadedContactsWithCompletion:")]
		void DeleteAllUploadedContactsWithCompletion(DGTDeleteAllUploadedContactsCompletion completion);
	}

	// @interface DGTContactsUploadResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface DGTContactsUploadResult {
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
		NSString DGTErrorDomain { get; }
	}

	// @interface DGTOAuthSigning : NSObject <TWTRCoreOAuthSigning>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface DGTOAuthSigning : ITWTRCoreOAuthSigning {
		// - (instancetype)initWithAuthConfig:(TWTRAuthConfig *)authConfig authSession:(DGTSession *)authSession NS_DESIGNATED_INITIALIZER;
		[Export ("initWithAuthConfig:authSession:")]
		IntPtr Constructor (TWTRAuthConfig authConfig, DGTSession authSession);

		// - (NSDictionary *)OAuthEchoHeadersToVerifyCredentialsWithParams:(NSDictionary *)params;
		[Export ("OAuthEchoHeadersToVerifyCredentialsWithParams:")]
		NSDictionary OAuthEchoHeadersToVerifyCredentialsWithParams(NSDictionary parameters);
	}


	// @interface DGTSession : NSObject <TWTRAuthSession>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface DGTSession : ITWTRAuthSession, INSCoding {
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
	public delegate void DGTAuthenticationCompletion (DGTSession session, NSError error);

	// @protocol DGTSessionUpdateDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public partial interface DGTSessionUpdateDelegate {
		// -(void)digitsSessionHasChanged:(DGTSession *)newSession;
		[Abstract]
		[Export ("digitsSessionHasChanged:")]
		void DigitsSessionHasChanged(DGTSession newSession);

		// -(void)digitsSessionExpiredForUserID:(NSString *)userID;
		[Abstract]
		[Export ("digitsSessionExpiredForUserID:")]
		void DigitsSessionExpiredForUserID(string userID);
	}

	// @interface DGTUser : NSObject
	[BaseType (typeof(NSObject))]
	public partial interface DGTUser {
		// @property (nonatomic, copy, readonly) NSString *userID;
		[Export ("userID", ArgumentSemantic.Copy)]
		string UserID { get; }
	}

	// @interface Digits : NSObject
	[BaseType (typeof(NSObject))]
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
		DGTSession Session { get; }

		// @property (readonly, nonatomic, strong) TWTRAuthConfig * _Nonnull authConfig;
		[Export ("authConfig", ArgumentSemantic.Strong)]
		TWTRAuthConfig AuthConfig { get; }

		[Wrap ("WeakSessionUpdateDelegate")]
		[NullAllowed]
		DGTSessionUpdateDelegate SessionUpdateDelegate { get; set; }

		// @property (nonatomic, weak) id<DGTSessionUpdateDelegate> _Nullable sessionUpdateDelegate;
		[NullAllowed, Export ("sessionUpdateDelegate", ArgumentSemantic.Weak)]
		NSObject WeakSessionUpdateDelegate { get; set; }

		// -(void)authenticateWithCompletion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
		[Export ("authenticateWithCompletion:")]
		void AuthenticateWithCompletion (DGTAuthenticationCompletion completion);

		// -(void)authenticateWithTitle:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithTitle:completion:")]
		void AuthenticateWithTitle (NSObject title, DGTAuthenticationCompletion completion);

		// -(void)authenticateWithViewController:(id)viewController title:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithViewController:title:completion:")]
		void AuthenticateWithViewController (NSObject viewController, NSObject title, DGTAuthenticationCompletion completion);

		// -(void)authenticateWithDigitsAppearance:(id)appearance viewController:(id)viewController title:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithDigitsAppearance:viewController:title:completion:")]
		void AuthenticateWithDigitsAppearance (NSObject appearance, NSObject viewController, NSObject title, DGTAuthenticationCompletion completion);

		// -(void)authenticateWithPhoneNumber:(id)phoneNumber digitsAppearance:(id)appearance viewController:(id)viewController title:(id)title completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithViewController:configuration:completion: instead.")));
		[Export ("authenticateWithPhoneNumber:digitsAppearance:viewController:title:completion:")]
		void AuthenticateWithPhoneNumber (NSObject phoneNumber, NSObject appearance, NSObject viewController, NSObject title, DGTAuthenticationCompletion completion);

		// -(void)authenticateWithNavigationViewController:(UINavigationController * _Nonnull)navigationController phoneNumber:(id)phoneNumber digitsAppearance:(id)appearance title:(id)title completionViewController:(UIViewController<DGTCompletionViewController> * _Nonnull)completionViewController __attribute__((availability(tvos, unavailable))) __attribute__((deprecated("Use authenticateWithNavigationViewController:configuration:completionViewController: instead.")));
		[Export ("authenticateWithNavigationViewController:phoneNumber:digitsAppearance:title:completionViewController:")]
		void AuthenticateWithNavigationViewController (UINavigationController navigationController, NSObject phoneNumber, NSObject appearance, NSObject title, DGTCompletionViewController completionViewController);

		// -(void)authenticateWithViewController:(id)viewController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
		[Export ("authenticateWithViewController:configuration:completion:")]
		void AuthenticateWithViewController (NSObject viewController, DGTAuthenticationConfiguration configuration, DGTAuthenticationCompletion completion);

		// -(void)authenticateWithNavigationViewController:(UINavigationController * _Nonnull)navigationController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completionViewController:(UIViewController<DGTCompletionViewController> * _Nonnull)completionViewController __attribute__((availability(tvos, unavailable)));
		[Export ("authenticateWithNavigationViewController:configuration:completionViewController:")]
		void AuthenticateWithNavigationViewController (UINavigationController navigationController, DGTAuthenticationConfiguration configuration, DGTCompletionViewController completionViewController);

		// -(void)logOut;
		[Export ("logOut")]
		void LogOut ();
	}
}