using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
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

        public async Task Create(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(category);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            return _mapper.Map<CategoryDTO>(await _categoryRepository.GetById(id));
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryRepository.GetCategories());
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(category);
        }

        public async Task Delete(int? id)
        {
            var category = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(category);
        }
    }
}
