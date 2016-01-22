using ObjCRuntime;

[assembly: LinkWith (
	"TwitterCore.a", 
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	SmartLink = true, 
	ForceLoad = true,
	Frameworks = "Accounts CoreData",
	WeakFrameworks = "Social SafariServices")]
