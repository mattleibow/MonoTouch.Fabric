using System;

using UIKit;
using MonoTouch.Fabric.Digits;
using Foundation;

namespace DigitsDemo
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var authButton = DGTAuthenticateButton.ButtonWithAuthenticationCompletion((DGTSession session, NSError error) =>
				{
					if (session != null && !string.IsNullOrEmpty(session.UserID))
					{
						// TODO: associate the session userID with your user model
						var msg = string.Format("Phone number: {0}", session.PhoneNumber);
						var alert = new UIAlertView("You are logged in!", msg, null, "OK", null);
						alert.Show();
					}
					else if (error != null)
						Console.WriteLine(string.Format("Authentication error: {0}", error.LocalizedDescription));
				});

			authButton.Center = View.Center;

			View.AddSubview(authButton);

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

