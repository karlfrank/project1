using System;
using System.Net.Mail;

namespace ElibriumWPF.Util
{
    public static class EmailHelper
    {
        public static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
