﻿using BookStoreAppMVC.Repository.IRepository;

namespace BookStoreAppMVC.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private AppDbContext _db;
        public ProductRepository(AppDbContext db): base(db)
        {
            _db = db;
        }
        public void Update(Product obj) 
        { 
            _db.Products.Update(obj);
        }
    }
}
