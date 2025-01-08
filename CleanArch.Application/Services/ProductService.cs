using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var products = await _mediator.Send(productsQuery);

            var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return productsDto;
        }

        public async Task<ProductDTO> GetProductsByIdAsync(int id)
        {
            var productIdQuery = new GetProductByIdQuery(id);

            if (productIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var product = await _mediator.Send(productIdQuery);

            var dtoProduct = _mapper.Map<ProductDTO>(product);
            return dtoProduct;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Remove(int id)
        {
            var productDeleteCommand = new ProductDeleteCommand(id);

            if (productDeleteCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productDeleteCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
