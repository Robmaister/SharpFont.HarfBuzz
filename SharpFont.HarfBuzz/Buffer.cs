using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

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
        public int Script { set { HB.hb_buffer_set_script(reference, value); } }
        public int Length { get { return HB.hb_buffer_get_length(reference); } }
        internal IntPtr Reference { get { return reference; } }
        #endregion

        #region Methods
        public void AddText(string str)
        {
            byte[] text = System.Text.Encoding.UTF8.GetBytes(str);
            HB.hb_buffer_add_utf8(reference, text, text.Length, 0, text.Length);
        }
        #endregion
    }
}
