﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PsssD.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _dbContext;

        public ProductService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public IList<Product> Get()
        {
            var results1 = (from c in this._dbContext.Products
                            group c by c.ProductName into g
                            select new Product()
                            {

                                ProductId = g.Count(),
                              ProductStock = g.Sum(ta => ta.ProductStock),
                                
                              //  ProductId = g.Discount(),
                                ProductPrice = g.Max(q => q.ProductPrice),
                                //ProductStock = g.Min(q => q.ProductStock)
                            });
            return results1.ToList();
        }

        //public IEnumerable<Product> Get()
        //{
        // //return (IEnumerable<Product>)_dbContext.Products.GroupBy(x => x.ProductName).Select(x => new {x.Key,total=x.Select(y=>y.ProductId).Count()});

        //}
    }
}

