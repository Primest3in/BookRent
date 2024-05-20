using BookRent.DataAccess.Data;
using BookRent.DataAccess.Repository.IRepository;
using BookRent.Models;
using BookRent.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRent.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDBContext _db;
        public ProductRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
