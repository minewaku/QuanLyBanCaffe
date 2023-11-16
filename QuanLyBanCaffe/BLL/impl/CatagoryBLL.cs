using QuanLyBanCaffe.DAO.impl;
using QuanLyBanCaffe.DAO;
using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanCaffe.LIB.Error;

namespace QuanLyBanCaffe.BLL.impl
{
    public class CatagoryBLL : ICatagoryBLL
    {
        ICatagoryDAO catagoryDao = new CatagoryDAO();

        public List<CatagoryDTO> findAll()
        {
            try
            {
                return catagoryDao.findAll();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<CatagoryDTO> findLikeName(string name)
        {
            try
            {
                return catagoryDao.findLikeName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public CatagoryDTO findByName(string name)
        {
            try
            {
                return catagoryDao.findByName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public CatagoryDTO findById(long id)
        {
            try
            {
                return catagoryDao.findById(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public CatagoryDTO findOne()
        {
            try
            {
                return catagoryDao.findOne();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }


        public int add(CatagoryDTO model)
        {
            if (model.name.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.name.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (catagoryDao.findByName(model.name) != null)
            {
                throw new Exception("Ten bi trung");
            }

            try
            {
                return catagoryDao.add(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public int update(CatagoryDTO model)
        {
            if (model.catagoryId < 0)
            {
                throw new Exception("catagoryId khong hop le");
            }
            else if (catagoryDao.findById(model.catagoryId) == null)
            {
                throw new Exception("catagoryId khong ton tai");
            }
            else if (model.name.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.name.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (catagoryDao.findByName(model.name) != null && catagoryDao.findByName(model.name).catagoryId != model.catagoryId)
            {
                throw new Exception("Ten bi trung");
            }

            try
            {
                return catagoryDao.update(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public int count() 
        {
            throw new NotImplementedException();
        }
    }
}
