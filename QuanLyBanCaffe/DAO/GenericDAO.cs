using QuanLyBanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace QuanLyBanCaffe.DAO
{
    public interface GenericDAO<T>
    {
        public List<T> query(ref string sql, GenericDTO<T> model, params Object[] parameters);
        public void delete(ref string sql, params Object[] paramater);
        public int insert(ref string sql, params Object[] paramater);
        public int count(ref string sql, params Object[] paramater);
    }
}
