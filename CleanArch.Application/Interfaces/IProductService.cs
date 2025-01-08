using CleanArch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetProductsByIdAsync(int id);
        Task Add(ProductDTO ProductDTO);
        Task Update(ProductDTO ProductDTO);
        Task Remove(int id);
    }
}
