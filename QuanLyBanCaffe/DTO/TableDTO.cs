using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public class TableDTO : GenericDTO<TableDTO>
    {
        public long tableId;
        public string name { get; set; } = "";
        public bool status { get; set; } = true;
        public bool active { get; set; } = true;

        public TableDTO()
        {

        }

        public TableDTO(long tableId, string name, bool status, bool active)
        {
            this.tableId = tableId;
            this.name = name;
            this.status = status;
            this.active = active;
        }

        TableDTO GenericDTO<TableDTO>.instance(DataRow dataRow)
        {
            TableDTO model = new TableDTO();

            model.tableId = (long)dataRow["tableId"];
            model.name = (string)dataRow["name"];
            model.status = (bool)dataRow["status"];
            model.active = (bool)dataRow["active"];

            return model;
        }
    }
}
