using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanCaffe.DTO
{
    public interface GenericDTO<T>
    {
        public T instance(DataRow dataRow);
    }
}
