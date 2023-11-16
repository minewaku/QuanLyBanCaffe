using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL
{
    public interface IBillBLL
    {
        public List<BillDTO> findAll();
        public List<BillDTO> findByRange(DateTime start, DateTime end);
        public List<BillDTO> findByTotalASC(DateTime start, DateTime end);
        public List<BillDTO> findByTotalDESC(DateTime start, DateTime end);
        public List<BillDTO> findByUserName(string name);
        public List<BillDTO> findByTableName(string name);
        public BillDTO findById(long id);
        public BillDTO findOne();

        public int add(BillDTO model);
        public int update(BillDTO model);
        public int updateTable(long tableId, long billId);
        public int updateStatus(string status, long billId);

        public int count();
    }
}
