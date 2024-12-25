using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ICarImageRepository
    {
        public List<byte[]> GetImagesByCarId(int id);
    }
}
