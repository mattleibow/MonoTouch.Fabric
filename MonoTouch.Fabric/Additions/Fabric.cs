using System;
using System.Linq;

namespace MonoTouch.Fabric
{
	partial class Fabric
	{
		public static Fabric With (params Type[] kitClasses)
		{
			return With (kitClasses.Select (c => new ObjCRuntime.Class (c)).ToArray ());
		}
	}
}

