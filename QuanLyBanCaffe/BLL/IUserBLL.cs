using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL
{
    public interface IUserBLL
    {
        public List<UserDTO> findAll();
        public List<UserDTO> findLikeName(string name);
        public List<UserDTO> findByStaff();
        public List<UserDTO> findByAdmin();
        public UserDTO findByName(string name);
        public UserDTO findByEmail(string email);
        public UserDTO findById(long id);
        public UserDTO findOne();
        public UserDTO login(string email, string password);

        public int add(UserDTO model);
        public int update(UserDTO model);

        public int count();
    }
}
