using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web1.DataAccess.Data;
using Web1.DataAccess.Repository.IRepository;
using Web1.Models;

namespace Web1.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IproductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
