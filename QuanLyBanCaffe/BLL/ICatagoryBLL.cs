using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL
{
    public interface ICatagoryBLL
    {
        public List<CatagoryDTO> findAll();
        public List<CatagoryDTO> findLikeName(string name);
        public CatagoryDTO findByName(string name);
        public CatagoryDTO findById(long id);
        public CatagoryDTO findOne();

        public int add(CatagoryDTO model);
        public int update(CatagoryDTO model);

        public int count();
    }
}
