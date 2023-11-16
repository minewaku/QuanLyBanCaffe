using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.LIB.Error
{
    public class AppException : Exception
    {
        public int errorCode { get; set; }
        public String message { get; set; }
        public String title { get; set; }
        public AppException(int errorCode, String message)
        {
            this.errorCode = errorCode;
            this.message = message;
            this.title = "Lỗi";
        }
        public String notice()
        {
            return String.Format("{0}\nMã lỗi:{1}", message, errorCode);
        }
    }
}
