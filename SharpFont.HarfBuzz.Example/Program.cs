using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

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
			face.SetCharSize(0, 50 << 6, 72, 72);

			var font = HarfBuzz.Font.FromFTFace(face);
			var buf = new HarfBuzz.Buffer();
			buf.Direction = Direction.HB_DIRECTION_RTL;
			buf.Script = 1098015074; // HB_SCRIPT_ARABIC
			buf.AddText("متن");
			font.Shape(buf);

			var glyphInfos = buf.GlyphInfo();
			var glyphPositions = buf.GlyphPositions();

			int height = (face.MaxAdvanceHeight - face.Descender) >> 6;
			int width = 0;
			for (int i = 0; i < glyphInfos.Length; ++i)
			{
				width += glyphPositions[i].xAdvance >> 6;
			}

			Bitmap bmp = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.Gray);

			int penX = 0, penY = face.MaxAdvanceHeight >> 6;
			//draw the string
			for (int i = 0; i < glyphInfos.Length; ++i)
			{
				face.LoadGlyph(glyphInfos[i].codepoint, LoadFlags.Default, LoadTarget.Normal);
				face.Glyph.RenderGlyph(RenderMode.Normal);

				Bitmap cBmp = face.Glyph.Bitmap.ToGdipBitmap(Color.Firebrick);
				g.DrawImageUnscaled(cBmp,
					penX + (glyphPositions[i].xOffset >> 6) + face.Glyph.BitmapLeft,
					penY - (glyphPositions[i].yOffset >> 6) - face.Glyph.BitmapTop);

				penX += glyphPositions[i].xAdvance >> 6;
				penY -= glyphPositions[i].yAdvance >> 6;
			}

			g.Dispose();

			bmp.Save("output.bmp");
		}
	}
}
