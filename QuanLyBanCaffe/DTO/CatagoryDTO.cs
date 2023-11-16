using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class CatagoryDTO : GenericDTO<CatagoryDTO>
    {
        public long catagoryId;
        public string name { get; set; } = "";
        public bool active { get; set; } = true;

        public CatagoryDTO() { 
        
        }

        public CatagoryDTO(long catagoryId, string name, bool active)
        {
            this.catagoryId = catagoryId;
            this.name = name;
            this.active = active;
        }

        public CatagoryDTO(DataRow dataRow)
        {
            this.catagoryId = (long)dataRow["catagoryId"];
            this.name = (string)dataRow["name"];
            this.active = (bool)dataRow["active"];
        }

        CatagoryDTO GenericDTO<CatagoryDTO>.instance(DataRow dataRow)
        {
            CatagoryDTO model = new CatagoryDTO();

            model.catagoryId = (long)dataRow["catagoryId"];
            model.name = (string)dataRow["name"];
            model.active = (bool)dataRow["active"];

            return model;
        }
    }
}
