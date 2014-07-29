using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpFont;

namespace SharpFont.HarfBuzz
{
	public class Font
	{
		#region Members
		private IntPtr reference;
		#endregion

		#region Constructors
		public static Font FromFTFace(Face face)
		{
			return new Font { reference = HB.hb_ft_font_create(face.Reference, IntPtr.Zero) };
		}
		#endregion

		#region Properties
		internal IntPtr Reference { get { return reference; } }
		#endregion

		#region Methods
		#endregion
	}
}
