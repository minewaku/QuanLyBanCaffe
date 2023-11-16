using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanCaffe.DAO;
using QuanLyBanCaffe.DAO.impl;
using QuanLyBanCaffe.LIB.Error;
using System.Collections;
using System.Windows;

namespace QuanLyBanCaffe.BLL.impl
{
    public class ProductBLL : IProductBLL
    {
        IProductDAO productDao = new ProductDAO();
        ICatagoryDAO categoryDao = new CatagoryDAO();

        public List<ProductDTO> findAll()
        {
            try
            {
                return productDao.findAll();
            } 
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<ProductDTO> findByCatagoryId(long id)
        {
            try
            {
                return productDao.findByCatagoryId(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<ProductDTO> findByCatagoryName(string name)
        {
            try
            {
                return productDao.findByCatagoryName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public List<ProductDTO> findLikeName(string name)
        {
            try
            {
                return productDao.findLikeName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public ProductDTO findByName(string name)
        {
            try
            {
                return productDao.findByName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public ProductDTO findById(long id)
        {
            try
            {
                return productDao.findById(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public ProductDTO findOne()
        {
            try
            {
                return productDao.findOne();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }


        public int add(ProductDTO model)
        {
            if (model.catagoryId < 0)
            {
                throw new Exception("catagoryId khong hop le");
            }
            else if (categoryDao.findById(model.catagoryId) == null)
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
            else if (productDao.findByName(model.name) != null)
            {
                throw new Exception("Ten bi trung");
            }
            else if (model.price < 0)
            {
                throw new Exception("Gia tien khong hop le");
            }
            else if (model.quantity < 0)
            {
                throw new Exception("So luong khong hop le");
            }
            else if (model.sold < 0 || model.sold > 0)
            {
                throw new Exception("So luong da ban khong duoc phep nhap");
            }

            try
            {
                return productDao.add(model);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        public int update(ProductDTO model)
        {
            if (model.productId < 0)
            {
                throw new Exception("productId khong hop le");
            }
            else if (productDao.findById(model.productId) == null)
            {
                throw new Exception("productId khong ton tai");
            }
            else if (model.catagoryId < 0)
            {
                throw new Exception("catagoryId khong hop le");
            }
            else if (categoryDao.findById(model.catagoryId) == null)
            {
                throw new Exception("catagoryId không ton tai");
            }
            else if (model.name.Trim() == "")
            {
                throw new Exception("Ten khong duoc de trong");
            }
            else if (model.name.Length > 256)
            {
                throw new Exception("Ten vuot qua 256 ky tu");
            }
            else if (productDao.findByName(model.name) != null && productDao.findByName(model.name).productId != model.productId)
            {
                throw new Exception("Ten bi trung");
            }
            else if (model.price < 0)
            {
                throw new Exception("Gia tien khong hop le");
            }
            else if (model.quantity < 0)
            {
                throw new Exception("So luong khong hop le");
            }
            else if (model.sold < 0 || model.sold > 0)
            {
                throw new Exception("So luong da ban khong duoc phep nhap");
            }

            try
            {
                return productDao.update(model);
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