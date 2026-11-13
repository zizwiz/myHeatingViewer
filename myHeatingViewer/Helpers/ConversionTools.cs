using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CenteredMessagebox;

namespace myHeatingViewer.Helpers
{
    class ConversionTools
    {
        // Converts a hex string (e.g., "313233") to a byte array {0x31, 0x32, 0x33}
        public static byte[] HexStringToByteArray(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                MsgBox.Show("Input string cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (hex.Length % 2 != 0)
                MsgBox.Show("Hex string length must be even.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                string byteValue = hex.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(byteValue, 16);
            }

            return bytes;
        }

    }
}
