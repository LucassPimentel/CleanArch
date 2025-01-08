using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> CreateAsync(Product Product)
        {
            await _appDbContext.Products.AddAsync(Product);
            await _appDbContext.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> DeleteAsync(Product Product)
        {
            _appDbContext.Products.Remove(Product);
            await _appDbContext.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _appDbContext.Products.Include(c => c.Category).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product Product)
        {
            _appDbContext.Products.Update(Product);
            await _appDbContext.SaveChangesAsync();
            return Product;
        }
    }
}
