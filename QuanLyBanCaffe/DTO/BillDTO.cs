using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class BillDTO : GenericDTO<BillDTO>
    {
        public long billId { get; set; }
        public long userId { get; set; }
        public long tableId { get; set; }
        public int quantity { get; set; } = 0;

        public decimal total { get; set; } = 0;
        public int discount { get; set; } = 0;
        public decimal receive { get; set; } = 0;
        public decimal change => (this.receive * ((decimal)discount / 100) - this.total);
        public DateTime createdDate { get; set; } = DateTime.Now;
        public string status { get; set; } = "PENDING"; //PENDING, PAID, CANCELLED;

        public BillDTO() { 
        
        }

        public BillDTO(long billId, long userId, long tableId, int quantity, decimal total, int discount, decimal receive, DateTime createdDate, string status)
        {
            this.billId = billId;
            this.userId = userId;
            this.tableId = tableId;
            this.quantity = quantity;
            this.total = total;
            this.discount = discount;
            this.receive = receive;
            this.createdDate = createdDate;
            this.status = status;
        }

        BillDTO GenericDTO<BillDTO>.instance(DataRow dataRow)
        {
            BillDTO model = new BillDTO();

            model.billId = (long)dataRow["billId"];
            model.userId = (long)dataRow["userId"];
            model.tableId = (long)dataRow["tableId"];
            model.quantity = (int)dataRow["quantity"];
            model.total = (decimal)dataRow["total"];
            model.discount = (int)dataRow["discount"];
            model.receive = (decimal)dataRow["receive"];
            model.createdDate = (DateTime)dataRow["createdDate"];
            model.status = (string)dataRow["status"];

            return model;
        }
    }
}
