﻿using QuanLyBanCaffe.DAO;
using QuanLyBanCaffe.DAO.impl;
using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.LIB.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL.impl
{
    public class BilBLL : IBillBLL
    {
        IBillDAO billDao = new BillDAO();
        IUserDAO userDao = new UserDAO();
        TableDAO tableDao = new TableDAO();

        List<BillDTO> IBillBLL.findAll()
        {
            try
            {
                return billDao.findAll();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        List<BillDTO> IBillBLL.findByRange(DateTime start, DateTime end)
        {
            if(start > end)
            {
                throw new Exception("Ngay bat dau lon hon ngay ket thuc");
            } 
            else if (start > DateTime.Now || end > DateTime.Now)
            {
                throw new Exception("Ngay bat dau hoac ngay ket thuc lon hon ngay hien tai");
            }

            try
            {
                return billDao.findByRange(start, end);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        List<BillDTO> IBillBLL.findByTotalASC(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new Exception("Ngay bat dau lon hon ngay ket thuc");
            }
            else if (start > DateTime.Now || end > DateTime.Now)
            {
                throw new Exception("Ngay bat dau hoac ngay ket thuc lon hon ngay hien tai");
            }

            try
            {
                return billDao.findByTotalASC(start, end);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        List<BillDTO> IBillBLL.findByTotalDESC(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new Exception("Ngay bat dau lon hon ngay ket thuc");
            }
            else if (start > DateTime.Now || end > DateTime.Now)
            {
                throw new Exception("Ngay bat dau hoac ngay ket thuc lon hon ngay hien tai");
            }

            try
            {
                return billDao.findByTotalDESC(start, end);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        List<BillDTO> IBillBLL.findByUserName(string name)
        {
            try
            {
                return billDao.findByUserName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        List<BillDTO> IBillBLL.findByTableName(string name)
        {
            try
            {
                return billDao.findByTableName(name);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        BillDTO IBillBLL.findById(long id)
        {
            try
            {
                return billDao.findById(id);
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }

        BillDTO IBillBLL.findOne()
        {
            try
            {
                return billDao.findOne();
            }
            catch (Exception ex)
            {
                throw new AppException(1, ex.Message);
            }
        }



        int IBillBLL.add(BillDTO model)
        {
            throw new NotImplementedException();
        }


        int IBillBLL.update(BillDTO model)
        {
            throw new NotImplementedException();
        }

        int IBillBLL.updateStatus(string status, long billId)
        {
            throw new NotImplementedException();
        }

        int IBillBLL.updateTable(long tableId, long billId)
        {
            throw new NotImplementedException();
        }



        public int count()
        {
            throw new NotImplementedException();
        }
    }
}
