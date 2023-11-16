using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.BLL
{
    public interface IProductBLL
    {
        public List<ProductDTO> findAll();
        public List<ProductDTO> findByCatagoryId(long id);
        public List<ProductDTO> findByCatagoryName(string name);
        public List<ProductDTO> findLikeName(string name);
        public ProductDTO findByName(string name);
        public ProductDTO findById(long id);
        public ProductDTO findOne();


        public int add(ProductDTO model);
        public int update(ProductDTO model);

        public int count();
    }
}
