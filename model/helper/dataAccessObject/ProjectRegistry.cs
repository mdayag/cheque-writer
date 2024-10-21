using Microsoft.Win32;

namespace model
{
    public class ProjectRegistry
    {
        public static string validateStringKey(string subKey, string strKey)
        {
            RegistryKey regkey;
            regkey = Registry.LocalMachine.OpenSubKey(subKey, true);

            if (regkey == null)
            {
                regkey = Registry.LocalMachine.CreateSubKey(subKey);
                regkey.Flush();
            }

            if (regkey.GetValue(strKey) == null)
            {
                regkey.SetValue(strKey, "", RegistryValueKind.String);
                regkey.Flush();
            }

            string val = regkey.GetValue(strKey).ToString();
            regkey.Close();
            return val;
        }

        public static string SQLConn
        {
            get
            {
                RegistryKey regkey;
                string subkey = @"Software\SSCGI\BRMS";
                validateStringKey(subkey, "SQLConn");
                regkey = Registry.LocalMachine.OpenSubKey(subkey);
                return regkey.GetValue("SQLConn").ToString();
            }
            set
            {
                RegistryKey regkey;
                string subkey = @"Software\SSCGI\BRMS";
                validateStringKey(subkey, "SQLConn");
                regkey = Registry.LocalMachine.OpenSubKey(subkey, true);
                regkey.SetValue("SQLConn", value, RegistryValueKind.String);
                Registry.LocalMachine.Flush();
            }
        }
    }
}
