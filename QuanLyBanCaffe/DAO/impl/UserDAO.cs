using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DAO.impl
{
    public class UserDAO : IUserDAO
    {
        GenericDAO<UserDTO> abstractDAO = new AbstractDAO<UserDTO>();

        public List<UserDTO> findAll()
        {
            string sql = "SELECT * FROM User";
            return abstractDAO.query(ref sql, new UserDTO());
        }

        public List<UserDTO> findLikeName(string username)
        {
            string sql = "SELECT * FROM User WHERE username LIKE @0";
            return abstractDAO.query(ref sql, new UserDTO(), "%" + username + "%");
        }

        public List<UserDTO> findByStaff()
        {
            string sql = "SELECT * FROM User WHERE role = 'Staff'";
            return abstractDAO.query(ref sql, new UserDTO());
        }

        public List<UserDTO> findByAdmin()
        {
            string sql = "SELECT * FROM User WHERE role = 'Admin'";
            return abstractDAO.query(ref sql, new UserDTO());
        }

        public UserDTO findByName(string username)
        {
            String sql = "SELECT * FROM User WHERE username = @0";
            List<UserDTO> list = abstractDAO.query(ref sql, new UserDTO(), username);
            return list.Any() ? list[0] : null;
        }

        public UserDTO findByEmail(string email)
        {
            String sql = "SELECT * FROM User WHERE email = @0";
            List<UserDTO> list = abstractDAO.query(ref sql, new UserDTO(), email);
            return list.Any() ? list[0] : null;
        }

        public UserDTO findById(long id)
        {
            String sql = "SELECT * FROM User WHERE userId = @0";
            List<UserDTO> list = abstractDAO.query(ref sql, new UserDTO(), id);
            return list.Any() ? list[0] : null;
        }

        public UserDTO findOne()
        {
            String sql = "SELECT * FROM User";
            List<UserDTO> list = abstractDAO.query(ref sql, new UserDTO());
            return list.Any() ? list[0] : null;
        }

        public UserDTO login(string email, string password)
        {
            String sql = "SELECT * FROM User WHERE email = @0 AND password = @1";
            List<UserDTO> list = abstractDAO.query(ref sql, new UserDTO(), email, password);
            return list.Any() ? list[0] : null;
        }



        public int add(UserDTO model)
        {
            string sql = "INSERT INTO User(username, email, password, phone, address, role, active) VALUES(@0, @1, @2, @3, @4, @5, @6)";
            return abstractDAO.insert(ref sql, model.username, model.email, model.password, model.phone, model.address, model.role,model.active);
        }

        public int update(UserDTO model)
        {
            string sql = "UPDATE User SET username = @0, email = @1, password = @2, phone = @3, address = @4, role = @5, active = @6 where userId = @7";
            return abstractDAO.insert(ref sql, model.username, model.email, model.password , model.phone, model.address, model.role ,model.active, model.userId);
        }



        public int count()
        {
            throw new NotImplementedException();
        }

    }
}
