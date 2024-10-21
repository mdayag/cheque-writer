using System;
using System.Windows.Forms;

namespace view.helpers
{
    public class myForm : Form
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.SendWait("{TAB}");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { }

            base.OnKeyDown(e);
        }
    }
}
