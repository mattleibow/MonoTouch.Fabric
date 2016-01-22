using System;
using ObjCRuntime;

namespace MonoTouch.Fabric.Digits
{
	[Native]
//	public enum DGTErrorCode : nint
	public enum ErrorCode : long
	{
		UnspecifiedError = 0,
		UserCanceledAuthentication = 1,
		UnableToAuthenticateNumber = 2,
		UnableToConfirmNumber = 3,
		UnableToAuthenticatePin = 4,
		UserCanceledFindContacts = 5,
		UserDeniedAddressBookAccess = 6,
		FailedToReadAddressBook = 7,
		UnableToUploadContacts = 8,
		UnableToDeleteContacts = 9,
		UnableToLookupContactMatches = 10,
		UnableToCreateEmailAddress = 11
	}

	[Native]
//	public enum DGTContactAccessAuthorizationStatus : nint
	public enum ContactAccessAuthorizationStatus : long
	{
		Pending = 0,
		Denied = 1,
		Accepted = 2
	}

	[Native]
	public enum AccountFields : long {
		None = 1,
		Email = 2
	}
}

