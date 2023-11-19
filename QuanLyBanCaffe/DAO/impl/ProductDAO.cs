using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DAO.impl
{
    public class ProductDAO : IProductDAO
    {
        GenericDAO<ProductDTO> abstractDAO = new AbstractDAO<ProductDTO>();


        List<ProductDTO> IProductDAO.findAll()
        {
            string sql = "SELECT * FROM Product";
            return abstractDAO.query(ref sql, new ProductDTO());
        }

        List<ProductDTO> IProductDAO.findByCatagoryId(long id)
        {
            string sql = "SELECT * FROM Product WHERE catagoryId = @0";
            return abstractDAO.query(ref sql, new ProductDTO(), id);
        }

        List<ProductDTO> IProductDAO.findByCatagoryName(string name)
        {
            string sql = "SELECT * FROM Product INNER JOIN Catagory ON Product.catagoryId = Catagory.catagoryId WHERE Catagory.name = @0";
            return abstractDAO.query(ref sql, new ProductDTO(), name);
        }

        ProductDTO IProductDAO.findById(long id)
        {
            String sql = "SELECT * FROM Product WHERE productId = @0";
            List<ProductDTO> list = abstractDAO.query(ref sql, new ProductDTO(), id);
            return list.Any() ? list[0] : null;
        }

        List<ProductDTO> IProductDAO.findLikeName(string name)
        {
            String sql = "SELECT * FROM Product WHERE name LIKE @0";
            return abstractDAO.query(ref sql, new ProductDTO(), "%" + name + "%");
        }

        ProductDTO IProductDAO.findByName(string name)
        {
            String sql = "SELECT * FROM Product WHERE name = @0";
            List<ProductDTO> list = abstractDAO.query(ref sql, new ProductDTO(), name);
            return list.Any() ? list[0] : null;
        }

        ProductDTO IProductDAO.findOne()
        {
            String sql = "SELECT * FROM Product";
            List<ProductDTO> list = abstractDAO.query(ref sql, new ProductDTO());
            return list.Any() ? list[0] : null;
        }



        int IProductDAO.add(ProductDTO model)
        {
            string sql = "INSERT INTO Product(catagoryId, name, price, quantity, active) VALUES(@0, @1, @2, @3, @4)";
            return abstractDAO.insert(ref sql, model.catagoryId, model.name, model.price, model.quantity, model.active);
        }

        int IProductDAO.update(ProductDTO model)
        {
            string sql = "UPDATE Product SET catagoryId = @0, name = @1, price = @2, quantity = @3, sold = @4, active = @5 where productId = @6";
            return abstractDAO.insert(ref sql, model.catagoryId, model.name, model.price, model.quantity, model.sold, model.active, model.productId);
        }



        int IProductDAO.count()
        {
            throw new NotImplementedException();
        }

    }
}
