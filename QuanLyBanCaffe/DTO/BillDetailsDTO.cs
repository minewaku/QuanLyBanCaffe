using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class BillDetailsDTO : GenericDTO<BillDetailsDTO>
    {
        public long billId {  get; set; }
        public long productId { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }

        public BillDetailsDTO() { 
        
        }

        public BillDetailsDTO(long billId, long productId, int quantity, decimal total)
        {
            this.billId = billId;
            this.productId = productId;
            this.quantity = quantity;
            this.total = total;
        }

        BillDetailsDTO GenericDTO<BillDetailsDTO>.instance(DataRow dataRow)
        {
            {
                BillDetailsDTO model = new BillDetailsDTO();

                model.billId = (long)dataRow["billId"];
                model.productId = (long)dataRow["productId"];
                model.quantity = (int)dataRow["quantity"];
                model.total = (decimal)dataRow["total"];

                System.Diagnostics.Debug.WriteLine(billId + ":" + productId + ":" + quantity + ":" + total);

                return model;
            }
        }
    }
}
