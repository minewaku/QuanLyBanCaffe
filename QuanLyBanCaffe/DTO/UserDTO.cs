using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class UserDTO : GenericDTO<UserDTO>
    {
        public long userId { get; set; }
        public string email { get; set; }
        public string username { get; set; } = "";
        public string password { get; set; } = "123";
        public string phone { get; set; } = "";
        public string address { get; set; } = "";
        public string role { get; set; } = "Staff";
        public bool active { get; set; } = true;

        public UserDTO() { 
        
        }

        public UserDTO(long userId, string email, string username, string password, string phone, string address, string role, bool active)
        {
            this.userId = userId;
            this.email = email;
            this.username = username;
            this.password = password;
            this.phone = phone;
            this.address = address;
            this.role = role;
            this.active = active;
        }

        public UserDTO(DataRow dataRow)
        {
            this.userId = (int)dataRow["userId"];
            this.email = (string)dataRow["email"];
            this.username = (string)dataRow["username"];
            this.password = (string)dataRow["password"];
            this.phone = (string)dataRow["phone"];
            this.address = (string)dataRow["address"];
            this.role = (string)dataRow["role"];
            this.active = (bool)dataRow["active"];
        }

        public UserDTO instance(DataRow dataRow) {
            UserDTO model = new UserDTO();

            model.userId = (int)dataRow["userId"];
            model.email = (string)dataRow["email"];
            model.username = (string)dataRow["username"];
            model.password = (string)dataRow["password"];
            model.phone = (string)dataRow["phone"];
            model.address = (string)dataRow["address"];
            model.role = (string)dataRow["role"];
            model.active = (bool)dataRow["active"];

            return model;
        }

        UserDTO GenericDTO<UserDTO>.instance(DataRow dataRow)
        {
            UserDTO model = new UserDTO();

            model.userId = (int)dataRow["userId"];
            model.email = (string)dataRow["email"];
            model.username = (string)dataRow["username"];
            model.password = (string)dataRow["password"];
            model.phone = (string)dataRow["phone"];
            model.address = (string)dataRow["address"];
            model.role = (string)dataRow["role"];
            model.active = (bool)dataRow["active"];

            return model;
        }
    }
}
