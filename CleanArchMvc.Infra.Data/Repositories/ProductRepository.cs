﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productDbContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productDbContext = context;
        }

        public async Task<Product> GetById(int? id)
        {
            return await _productDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productDbContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _productDbContext.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Create(Product product)
        {
            _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productDbContext.Products.Update(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }


    }
}
