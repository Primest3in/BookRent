using BookRent.DataAccess.Data;
using BookRent.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRent.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext dbContext;

        public UnitOfWork(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
            CategoryRepository = new CategoryRepository(dbContext);
        } 

        public ICategoryRepository CategoryRepository {  get; private set; }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
