using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            var dtoCategories = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return dtoCategories;

        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var categorie = await _categoryRepository.GetCategoryByIdAsync(id);
            var dtoCategorie = _mapper.Map<CategoryDTO>(categorie);
            return dtoCategorie;
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var newCategory = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(newCategory);
        }

        public async Task Remove(int id)
        {
            var categoryToDelete = await _categoryRepository.GetCategoryByIdAsync(id);
            await _categoryRepository.DeleteAsync(categoryToDelete);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var updatedCategory = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(updatedCategory);
        }
    }
}
