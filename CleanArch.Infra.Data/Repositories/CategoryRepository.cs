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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _appDbContext.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _appDbContext.Categories.Update(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }
    }
}
