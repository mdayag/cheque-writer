using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace common
{
    public class Utilities
    {
        public static void ValidateDecimal(TextBox txt)
        {
            int ss = txt.SelectionStart;
            Regex regex = new Regex("^[0-9.]");

            if (txt.TextLength > 0)
                if (!regex.IsMatch(txt.Text.ToLower().Substring(txt.TextLength - 1)))
                {
                    txt.Text = txt.Text.Remove(txt.TextLength - 1);
                }
            if (txt.TextLength == 0)
            {
                txt.Text = "0";
                txt.SelectAll();
            }

            txt.SelectionStart = ss;
        }
    }
}
