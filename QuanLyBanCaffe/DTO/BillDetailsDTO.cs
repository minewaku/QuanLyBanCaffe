using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class BillDetailsDTO
    {
        public long billId {  get; set; }
        public long userId { get; set; }
        public long productId { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }

        public BillDetailsDTO() { 
        
        }

        public BillDetailsDTO(long billId, long userId, long productId, int quantity, double total)
        {
            this.billId = billId;
            this.userId = userId;
            this.productId = productId;
            this.quantity = quantity;
            this.total = total;
        }

        public BillDetailsDTO(DataRow dataRow)
        {
            this.billId = (long)dataRow["billId"];
            this.userId = (long)dataRow["userId"];
            this.productId = (long)dataRow["productId"];
            this.quantity = (int)dataRow["quantity"];
            this.total = (double)dataRow["total"];
        }
    }
}
