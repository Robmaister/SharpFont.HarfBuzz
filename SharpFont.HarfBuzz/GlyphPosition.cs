using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont.HarfBuzz
{
	[StructLayout(LayoutKind.Sequential)]
	public class GlyphPosition
	{
		public int xAdvance;
		public int yAdvance;
		public int xOffset;
		public int yOffset;
	}
}
