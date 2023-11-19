using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DAO
{
    public interface IBillDetailsDAO
    {
        public List<BillDetailsDTO> findAll();
        public List<BillDetailsDTO> findByProductName(string name);
        public List<BillDetailsDTO> findByBillId(long id);
        public List<BillDetailsDTO> findByProductId(long id);
        public BillDetailsDTO findById(long billId, long productId);
        public BillDetailsDTO findOne();

        public int add(BillDetailsDTO model);
        public int update(BillDetailsDTO model);

        public int count();
    }
}
