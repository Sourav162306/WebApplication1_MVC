using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.Models;

namespace Web1.DataAccess.Repository.IRepository
{
    public interface IproductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
