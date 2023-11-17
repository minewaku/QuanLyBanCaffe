using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.LIB
{
    public class Validation
    {

        public static bool emailValidation(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public static bool phoneValidation(string phone)
        {
            if (phone.Length != 10)
            {
                return false;
            } else if(phone.Length == 10 && phone[0] != '0')
            {
                return false;
            }
 
            return true;
        }
    }
}
