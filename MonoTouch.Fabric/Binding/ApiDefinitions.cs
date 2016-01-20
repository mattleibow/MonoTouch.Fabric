using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace MonoTouch.Fabric
{
	// Generated using Objective Sharpie
	// 1. Copy the (.a) library and headers from Fabric framework to project
	// 2. Use Objective Sharpie command 'sharpie bind -output {output_dir} -sdk {sdk} -scope Headers/ Headers/{umbrella_header_file} -c -I{headers_location} -arch {architecture}'
	// 3. Delete default ApiDefinition.cs and StructsAndEnums.cs files in root of project
	// 4. Set Build Action for new ApiDefinitions file to ObjcBindingApiDefinition
	// 5. Set Build Action for new StructsAndEnums.cs file to ObjcBindingCoreSource (skip this step if no file generated)
	// 6. Build project

	//	 @interface Fabric : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	public partial interface Fabric
	{
		// +(instancetype _Nonnull)with:(NSArray * _Nonnull)kitClasses;
		[Static]
		[Export ("with:")]
		//		[Verify (StronglyTypedNSArray)]
		Fabric With (NSObject[] kitClasses);

		// +(instancetype _Nonnull)sharedSDK;
		[Static]
		[Export ("sharedSDK")]
		Fabric SharedSDK ();

		// @property (assign, nonatomic) BOOL debug;
		[Export ("debug")]
		bool Debug { get; set; }
	}
}