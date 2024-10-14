using BookStoreAppMVC.Repository.IRepository;
using System.Linq.Expressions;

namespace BookStoreAppMVC.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private AppDbContext _db;
        public CategoryRepository(AppDbContext db): base(db)
        {
            _db = db;
        }
 
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
