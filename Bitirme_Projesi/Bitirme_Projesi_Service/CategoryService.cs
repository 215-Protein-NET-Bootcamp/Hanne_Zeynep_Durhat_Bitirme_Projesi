using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Data.Repository;
using Bitirme_Projesi_Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Service
{
    public class CategoryService : ICategoryService
       
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategory(CategoryDto catDto )
        {

            try
            {
                var category = await _categoryRepository.AddCategory(catDto);
                return category;
            }
            catch (Exception ex)
            {
                //log error
                throw new Exception(ex.Message);
            }
        }

        public async  Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var category = await _categoryRepository.GetAll();
                return category;
            }
            catch (Exception ex)
            {
                //log error
                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> Update(CategoryDto catDto)
        {
            try
            {
                var cat = new Category();
                cat.CategoryId = catDto.CategoryId;
                cat.CategoryName = catDto.CategoryName;

                return await _categoryRepository.UpdateCategory(cat);

            }
            catch (Exception ex)
            {
                //log error
                throw new Exception(ex.Message);
            }
        }
    }
}
