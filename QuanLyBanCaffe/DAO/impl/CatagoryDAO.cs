using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyBanCaffe.DAO;

namespace QuanLyBanCaffe.DAO.impl
{
    public class CatagoryDAO : ICatagoryDAO
    {
        GenericDAO<CatagoryDTO> abstractDAO = new AbstractDAO<CatagoryDTO>();

        public List<CatagoryDTO> findAll()
        {
            string sql = "SELECT * FROM Catagory";
            return abstractDAO.query(ref sql, new CatagoryDTO());
        }

        public List<CatagoryDTO> findLikeName(string name)
        {
            string sql = "SELECT * FROM Catagory WHERE name LIKE @0";
            return abstractDAO.query(ref sql, new CatagoryDTO(), "%" + name + "%");
        }

        public CatagoryDTO findByName(string name)
        {
            String sql = "SELECT * FROM Catagory WHERE name = @0";
            List<CatagoryDTO> list = abstractDAO.query(ref sql, new CatagoryDTO(), name);
            return list.Any() ? list[0] : null;
        }

        public CatagoryDTO findById(long id)
        {
            String sql = "SELECT * FROM Catagory WHERE catagoryId = @0";
            List<CatagoryDTO> list = abstractDAO.query(ref sql, new CatagoryDTO(), id);
            return list.Any() ? list[0] : null;
        }

        public CatagoryDTO findOne()
        {
            String sql = "SELECT * FROM Catagory";
            List<CatagoryDTO> list = abstractDAO.query(ref sql, new CatagoryDTO());
            return list.Any() ? list[0] : null;
        }



        int ICatagoryDAO.add(CatagoryDTO model)
        {
            string sql = "INSERT INTO Catagory(name, active) VALUES(@0, @1)";
            return abstractDAO.insert(ref sql, model.name, model.active);
        }

        int ICatagoryDAO.update(CatagoryDTO model)
        {
            string sql = "UPDATE Catagory SET name = @0, active = @1 where catagoryId = @2";
            return abstractDAO.insert(ref sql, model.name, model.active, model.catagoryId);
        }



        int ICatagoryDAO.count()
        {
            throw new NotImplementedException();
        }
    }
}
