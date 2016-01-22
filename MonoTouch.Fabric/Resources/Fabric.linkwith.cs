using ObjCRuntime;

[assembly: LinkWith (
	"Fabric.a", 
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	SmartLink = true,
	ForceLoad = true)]
