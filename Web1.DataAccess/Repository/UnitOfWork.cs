using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.DataAccess.Data;
using Web1.DataAccess.Repository.IRepository;
using Web1.Models;

namespace Web1.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IproductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
