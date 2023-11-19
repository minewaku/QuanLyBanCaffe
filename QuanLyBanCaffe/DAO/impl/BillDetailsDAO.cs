using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace QuanLyBanCaffe.DAO.impl
{
    public class BillDetailsDAO : IBillDetailsDAO
    {
        GenericDAO<BillDetailsDTO> abstractDAO = new AbstractDAO<BillDetailsDTO>();


        List<BillDetailsDTO> IBillDetailsDAO.findAll()
        {
            string sql = "SELECT * FROM BillDetails";
            return abstractDAO.query(ref sql, new BillDetailsDTO());
        }

        List<BillDetailsDTO> IBillDetailsDAO.findByProductName(string name)
        {
            string sql = "SELECT * FROM BillDetails INNER JOIN Product ON BillDetails.productId = Product.productId WHERE Product.name = @0";
            return abstractDAO.query(ref sql, new BillDetailsDTO(), name);
        }

        List<BillDetailsDTO> IBillDetailsDAO.findByBillId(long id)
        {
            string sql = "SELECT * FROM BillDetails WHERE billId = @0";
            List<BillDetailsDTO> list = abstractDAO.query(ref sql, new BillDetailsDTO(), id);
/*            foreach(BillDetailsDTO item in list)
            {
                System.Diagnostics.Debug.WriteLine(item.billId + ":" + item.productId + ":" + item.quantity + ":" + item.total);
            }*/
            return list;
        }

        List<BillDetailsDTO> IBillDetailsDAO.findByProductId(long id)
        {
            string sql = "SELECT * FROM BillDetails WHERE productId = @0";
            return abstractDAO.query(ref sql, new BillDetailsDTO(), id);
        }

        BillDetailsDTO IBillDetailsDAO.findById(long billId, long productId)
        {
            string sql = "SELECT * FROM BillDetails WHERE billId = @0 AND productId = @1";
            List<BillDetailsDTO> list = abstractDAO.query(ref sql, new BillDetailsDTO(), billId, productId);
            return list.Any() ? list[0] : null;
        }

        BillDetailsDTO IBillDetailsDAO.findOne()
        {
            string sql = "SELECT * FROM BillDetails";
            List<BillDetailsDTO> list = abstractDAO.query(ref sql, new BillDetailsDTO());
            return list.Any() ? list[0] : null;
        }



        int IBillDetailsDAO.add(BillDetailsDTO model)
        {
            string sql = "INSERT INTO BillDetails(billId, productId, quantity, total) VALUES(@0, @1, @2, @3)";
            return abstractDAO.insert(ref sql, model.billId, model.productId, model.quantity, model.total);
        }

        int IBillDetailsDAO.update(BillDetailsDTO model)
        {
            string sql = "UPDATE BillDetails SET quantity = @0, total = @1 WHERE billId = @2 AND productId = @3";
            return abstractDAO.insert(ref sql, model.quantity, model.total, model.billId, model.productId);
        }

        int IBillDetailsDAO.count()
        {
            throw new NotImplementedException();
        }
    }
}
