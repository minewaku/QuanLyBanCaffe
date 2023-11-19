using QuanLyBanCaffe.DAO.impl;
using QuanLyBanCaffe.DAO;
using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.LIB.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL.impl
{
    public class BillDetailsBLL : IBillDetailsBLL
    {
        IBillDetailsDAO billDetailsDAO = new BillDetailsDAO();
        IBillDAO billDAO = new BillDAO();
        IProductDAO productDAO = new ProductDAO();

        public List<BillDetailsDTO> findAll()
        {
            try
            {
                return billDetailsDAO.findAll();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<BillDetailsDTO> findByProductName(string name)
        {
            try
            {
                return billDetailsDAO.findByProductName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<BillDetailsDTO> findByBillId(long id)
        {
            try
            {
                return billDetailsDAO.findByBillId(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<BillDetailsDTO> findByProductId(long id)
        {
            try
            {
                return billDetailsDAO.findByProductId(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public BillDetailsDTO findById(long billId, long productId)
        {
            try
            {
                return billDetailsDAO.findById(billId, productId);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public BillDetailsDTO findOne()
        {
            try
            {
                return billDetailsDAO.findOne();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }



        public int add(BillDetailsDTO model)
        {
            if (model.quantity < 0)
            {
                throw new Exception("So luong khong hop le");
            }
            else if (model.billId < 0)
            {
                throw new Exception("billId khong hop le");
            }
            else if (billDAO.findById(model.billId) == null)
            {
                throw new Exception("billId khong ton tai");
            }
            else if(model.productId < 0)
            {
                throw new Exception("productId khong hop le");
            }
            else if(productDAO.findById(model.productId) == null) 
            {
                throw new Exception("productId khong ton tai");
            }

            try
            {
                model.total = model.quantity * productDAO.findById(model.productId).price;
                return billDetailsDAO.add(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public int update(BillDetailsDTO model)
        {
            if (model.quantity < 0)
            {
                throw new Exception("So luong khong hop le");
            }
            else if (model.billId < 0)
            {
                throw new Exception("billId khong hop le");
            }
            else if (billDAO.findById(model.billId) == null)
            {
                throw new Exception("billId khong ton tai");
            }
            else if (model.productId < 0)
            {
                throw new Exception("productId khong hop le");
            }
            else if (productDAO.findById(model.productId) == null)
            {
                throw new Exception("productId khong ton tai");
            }

            try
            {
                model.total = model.quantity * productDAO.findById(model.productId).price;
                return billDetailsDAO.update(model);
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
