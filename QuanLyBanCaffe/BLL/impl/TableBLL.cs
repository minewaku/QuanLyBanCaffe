using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanCaffe.DAO;
using QuanLyBanCaffe.DAO.impl;
using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.LIB.Error;

namespace QuanLyBanCaffe.BLL.impl
{
    public class TableBLL : ITableBLL
    {
        ITableDAO tableDao = new TableDAO();

        public List<TableDTO> findAll()
        {
            try
            {
                return tableDao.findAll();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<TableDTO> findLikeName(string name)
        {
            try
            {
                return tableDao.findLikeName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public TableDTO findByName(string name)
        {
            try
            {
                return tableDao.findByName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public TableDTO findById(long id)
        {
            try
            {
                return tableDao.findById(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public TableDTO findOne()
        {
            try
            {
                return tableDao.findOne();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }


        public int add(TableDTO model)
        {
            if (model.name.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.name.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (tableDao.findByName(model.name) != null)
            {
                throw new Exception("Ten bi trung");
            }

            try
            {
                return tableDao.add(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public int update(TableDTO model)
        {
            if (model.tableId < 0)
            {
                throw new Exception("tableId khong hop le");
            }
            else if (tableDao.findById(model.tableId) == null)
            {
                throw new Exception("tableId khong ton tai");
            }
            else if (model.name.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.name.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (tableDao.findByName(model.name) != null && tableDao.findByName(model.name).tableId != model.tableId)
            {
                throw new Exception("Ten bi trung");
            }

            try
            {
                return tableDao.update(model);
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
