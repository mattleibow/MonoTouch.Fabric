using ObjCRuntime;

[assembly: LinkWith (
	"DigitsKit.a", 
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true, 
	Frameworks = "AddressBook CoreData")]
