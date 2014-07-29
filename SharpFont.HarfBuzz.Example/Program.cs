using System;

using SharpFont;
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

			var lib = new Library();
			var face = new SharpFont.Face(lib, @"C:\Windows\Fonts\tahoma.ttf");
			face.SetCharSize(0, 50 * 64, 72, 72);

			var font = HarfBuzz.Font.FromFTFace(face);
			var buf = new HarfBuzz.Buffer();
			buf.Direction = Direction.HB_DIRECTION_RTL;
			buf.Script = 1098015074; // HB_SCRIPT_ARABIC
			buf.AddText("متن");
			font.Shape(buf);

			var glyphInfos = buf.GlyphInfo();
			var glyphPositions = buf.GlyphPositions();
		}
	}
}
