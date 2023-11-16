using QuanLyBanCaffe.DTO;
using QuanLyBanCaffe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DAO.impl
{
    public class TableDAO : ITableDAO
    {
        GenericDAO<TableDTO> abstractDAO = new AbstractDAO<TableDTO>();


        public List<TableDTO> findAll()
        {
            string sql = "SELECT * FROM Table";
            return abstractDAO.query(ref sql, new TableDTO());
        }

        public List<TableDTO> findLikeName(string name)
        {
            string sql = "SELECT * FROM Table WHERE name LIKE @0";
            return abstractDAO.query(ref sql, new TableDTO(), "%" + name + "%");
        }

        public TableDTO findByName(string name)
        {
            String sql = "SELECT * FROM Table WHERE name = @0";
            List<TableDTO> list = abstractDAO.query(ref sql, new TableDTO(), name);
            return list.Any() ? list[0] : null;
        }

        public TableDTO findById(long id)
        {
            String sql = "SELECT * FROM Table WHERE tableId = @0";
            List<TableDTO> list = abstractDAO.query(ref sql, new TableDTO(), id);
            return list.Any() ? list[0] : null;
        }

        public TableDTO findOne()
        {
            String sql = "SELECT * FROM Table";
            List<TableDTO> list = abstractDAO.query(ref sql, new TableDTO());
            return list.Any() ? list[0] : null;
        }



        public int add(TableDTO model)
        {
            string sql = "INSERT INTO Table(name, status, active) VALUES(@0, @1, @2)";
            return abstractDAO.insert(ref sql, model.name, model.status,model.active);
        }

        public int update(TableDTO model)
        {
            string sql = "UPDATE Table SET name = @0, active = @1 where tableId = @2";
            return abstractDAO.insert(ref sql, model.name, model.active, model.tableId);
        }




        public int count()
        {
            throw new NotImplementedException();
        }
    }
}
