using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class ProductDTO : GenericDTO<ProductDTO>
    {
        public long productId {  get; set; }
        public long catagoryId { get; set; }
        public string name { get; set; } = "";
        public decimal price { get; set; } = 0;
        public int quantity { get; set; } = 0;
        public int sold { get; set; } = 0;
        public bool active { get; set; } = true;

        public ProductDTO() { 
        
        }

        public ProductDTO(long productId, long catagoryId, string name, decimal price, int quantity, int sold, bool active)
        {
            this.productId = productId;
            this.catagoryId = catagoryId;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.sold = sold;
            this.active = active;
        }

        ProductDTO GenericDTO<ProductDTO>.instance(DataRow dataRow)
        {
            ProductDTO model = new ProductDTO();

            model.productId = (long)dataRow["productId"];
            System.Diagnostics.Debug.WriteLine(dataRow["productId"]+ "\n");
            System.Diagnostics.Debug.WriteLine(productId + "\n");
            model.catagoryId = (long)dataRow["catagoryId"];
            model.name = (string)dataRow["name"];
            model.price = (decimal)dataRow["price"];
            model.quantity = (int)dataRow["quantity"];
            model.sold = (int)dataRow["sold"];
            model.active = (bool)dataRow["active"];

            return model;
        }
    }
}
