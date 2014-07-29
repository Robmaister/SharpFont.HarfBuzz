using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SharpFont.HarfBuzz
{
	public class Buffer
	{
		#region Fields
		internal IntPtr reference;
		#endregion

		#region Constructors
		public Buffer()
		{
			reference = HB.hb_buffer_create();
		}
		#endregion

		#region Properties
		public Direction Direction { set { HB.hb_buffer_set_direction(reference, value); } }
		// Arabic
		public Script Script { set { HB.hb_buffer_set_script(reference, value); } }
		public int Length { get { return HB.hb_buffer_get_length(reference); } }
		internal IntPtr Reference { get { return reference; } }
		#endregion

		#region Methods
		public void AddText(string str)
		{
			byte[] text = System.Text.Encoding.UTF8.GetBytes(str);
			HB.hb_buffer_add_utf8(reference, text, text.Length, 0, text.Length);
		}

		public GlyphInfo[] GlyphInfo()
		{
			int length;
			IntPtr glyphInfoPtr = HB.hb_buffer_get_glyph_infos(reference, out length);
			var glyphInfos = new GlyphInfo[length];
			for (int i = 0; i < length; ++i)
			{
				glyphInfos[i] = new GlyphInfo();
				Marshal.PtrToStructure(glyphInfoPtr + 20 * i, glyphInfos[i]);
			}

			return glyphInfos;
		}
		public GlyphPosition[] GlyphPositions()
		{
			int length;
			IntPtr glyphPositionPtr = HB.hb_buffer_get_glyph_positions(reference, out length);
			var glyphPositions = new GlyphPosition[length];
			for (int i = 0; i < length; ++i)
			{
				glyphPositions[i] = new GlyphPosition();
				Marshal.PtrToStructure(glyphPositionPtr + 20 * i, glyphPositions[i]);
			}

			return glyphPositions;
		}
		#endregion
	}
}
