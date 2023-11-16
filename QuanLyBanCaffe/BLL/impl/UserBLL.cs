using QuanLyBanCaffe.DAO;
using QuanLyBanCaffe.DAO.impl;
using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.LIB.Error;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL.impl
{
    public class UserBLL : IUserBLL
    {
        IUserDAO userDao = new UserDAO();

        public List<UserDTO> findAll()
        {
            try
            {
                return userDao.findAll();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<UserDTO> findLikeName(string name)
        {
            try
            {
                return userDao.findLikeName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<UserDTO> findByStaff()
        {
            try
            {
                return userDao.findByStaff();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<UserDTO> findByAdmin()
        {
            try
            {
                return userDao.findByAdmin();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public UserDTO findByName(string name)
        {
            try
            {
                return userDao.findByName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public UserDTO findByEmail(string email)
        {
            try
            {
                return userDao.findByEmail(email);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public UserDTO findById(long id)
        {
            try
            {
                return userDao.findById(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public UserDTO findOne()
        {
            try
            {
                return userDao.findOne();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public UserDTO login(string email, string password)
        {
            if (!emailValidation(email))
            {
                throw new Exception("email khong hop le");
            }

            try
            {
                return userDao.login(email, password);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public int add(UserDTO model)
        {
            if (!emailValidation(model.email))
            {
                throw new Exception("email khong hop le");
            }
            else if (model.email.Length > 256)
            {
                throw new Exception("email vuot qua 256 ky tu");
            }
            else if (model.username.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.username.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (userDao.findByName(model.username) != null)
            {
                throw new Exception("Ten bi trung");
            }
            else if (phoneValidation(model.phone))
            {
                throw new Exception("So dien thoai khong hop le");
            }
            else if (model.address.Trim() == "")
            {
                throw new Exception("Dia chi khong duoc de trong");
            }

            try
            {
                return userDao.add(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }
        public int update(UserDTO model)
        {
            if (!emailValidation(model.email))
            {
                throw new Exception("email khong hop le");
            }
            else if (model.email.Length > 256)
            {
                throw new Exception("email vuot qua 256 ky tu");
            }
            else if (model.username.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.username.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (userDao.findByName(model.username) != null && userDao.findByName(model.username).userId != model.userId)
            {
                throw new Exception("Ten bi trung");
            }
            else if (phoneValidation(model.phone))
            {
                throw new Exception("So dien thoai khong hop le");
            }
            else if (model.address.Trim() == "")
            {
                throw new Exception("Dia chi khong duoc de trong");
            }
            else if (model.role != "Staff" || model.role != "Admin")
            {
                throw new Exception("Chuc vu khong hop le");
            }

            try
            {
                return userDao.add(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public bool emailValidation(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public bool phoneValidation(string phone)
        {
            if (phone[0] != 0 || phone.Length != 10)
            {
                return false;
            }

            return true;
        }

        public int count()
        {
            throw new NotImplementedException();
        }
    }
}
