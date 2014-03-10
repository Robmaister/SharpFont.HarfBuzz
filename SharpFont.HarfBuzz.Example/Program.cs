using System;

using SharpFont.HarfBuzz;

namespace SharpFont.HarfBuzz.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Version string: " + HB.VersionString);
			Version v = HB.Version;
			Console.WriteLine("Version: " + v.Major + "." + v.Minor + "." + v.Build);
			Console.WriteLine("VersionCheck: " + HB.VersionCheck(v));

			Console.ReadLine();
		}
	}
}
