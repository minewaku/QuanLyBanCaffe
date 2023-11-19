using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace QuanLyBanCaffe.DAO.impl
{
    public class BillDAO : IBillDAO
    {
        GenericDAO<BillDTO> abstractDAO = new AbstractDAO<BillDTO>();

        public List<BillDTO> findAll()
        {
            string sql = "SELECT * FROM Bill";
            return abstractDAO.query(ref sql, new BillDTO());
        }

        public List<BillDTO> findByRange(DateTime start, DateTime end)
        {
            string sql = "SELECT * FROM Bill WHERE createdDate >= @0 AND createdDate <= @1";
            return abstractDAO.query(ref sql, new BillDTO(), start, end);
        }

        public List<BillDTO> findByTotalASC(DateTime start, DateTime end)
        {
            string sql = "SELECT * FROM Bill WHERE createdDate >= @0 AND createdDate <= @1 ORDER BY total ASC";
            return abstractDAO.query(ref sql, new BillDTO(), start, end);
        }

        public List<BillDTO> findByTotalDESC(DateTime start, DateTime end)
        {
            string sql = "SELECT * FROM Bill WHERE createdDate >= @0 AND createdDate <= @1 ORDER BY total DESC";
            return abstractDAO.query(ref sql, new BillDTO(), start, end);
        }

        public List<BillDTO> findLikeUserName(string name)
        {
            string sql = "SELECT * FROM Bill INNER JOIN [User] ON Bill.userId = [User].userId WHERE [User].username LIKE @0";
            return abstractDAO.query(ref sql, new BillDTO(), name);
        }
        public List<BillDTO> findLikeTableName(string name)
        {
            string sql = "SELECT * FROM Bill INNER JOIN Table ON Bill.tableId = Table.tableId WHERE Table.name = @0";
            return abstractDAO.query(ref sql, new BillDTO(), name);
        }

        public BillDTO findById(long id)
        {
            String sql = "SELECT * FROM Bill where billId = @0";
            List<BillDTO> list = abstractDAO.query(ref sql, new BillDTO(), id);
            return list.Any() ? list[0] : null;
        }

        public BillDTO findByCreatedDate(DateTime createdDate)
        {
            String sql = "SELECT * FROM Bill where createdDate = @0";
            List<BillDTO> list = abstractDAO.query(ref sql, new BillDTO(), createdDate);
            return list.Any() ? list[0] : null;
        }

        public BillDTO findOne()
        {
            String sql = "SELECT * FROM Bill";
            List<BillDTO> list = abstractDAO.query(ref sql, new BillDTO());
            return list.Any() ? list[0] : null;
        }



        public int add(BillDTO model)
        {
            string sql = "INSERT INTO Bill(billId, userId, tableId, quantity, total, discount, final, receive, change, createdDate, status) VALUES(@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)";
            return abstractDAO.insert(ref sql, model.billId, model.userId, model.tableId, model.quantity, model.total, model.discount, model.final,model.receive, model.change, model.createdDate, model.status);
        }

        public int update(BillDTO model)
        {
            string sql = "UPDATE Bill SET quantity = @1, total = @2, discount = @3, final = @4, receive = @5, change = @6, createdDate = @7 WHERE billId = @8";
            return abstractDAO.insert(ref sql, model.quantity, model.total, model.discount, model.final, model.receive, model.change, model.createdDate, model.billId);
        }

        public int updateTable(long tableId, long billId)
        {
            string sql = "UPDATE Bill SET tableId = @0 WHERE billId = @1";
            return abstractDAO.insert(ref sql, tableId, billId);
        }

        public int updateStatus(string status, long billId)
        {
            string sql = "UPDATE Bill SET status = @0 WHERE billId = @1";
            return abstractDAO.insert(ref sql, status, billId);
        }



        public int count()
        {
            throw new NotImplementedException();
        }
    }
}
