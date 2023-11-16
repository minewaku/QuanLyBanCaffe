using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DAO
{
    public interface ITableDAO
    {
        public List<TableDTO> findAll();
        public List<TableDTO> findLikeName(string name);
        public TableDTO findByName(string name);
        public TableDTO findById(long id);
        public TableDTO findOne();

        public int add(TableDTO model);
        public int update(TableDTO model);

        public int count();
    }
}
