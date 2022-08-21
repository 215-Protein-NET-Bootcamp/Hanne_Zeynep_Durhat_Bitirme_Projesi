using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Data.Repository;
using Bitirme_Projesi_Dto.Dtos;
using Bitirme_Projesi_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitirme_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase

    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            try
            {
                var category = await _categoryService.GetAll();
                return Ok(category);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }




        [HttpPost]

        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            try
            {
                var addCategory = await _categoryService.AddCategory(category);
                return CreatedAtRoute("CompanyById", new { id = addCategory.CategoryId}, addCategory);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}")]
       
        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            try
            {
                var dbCategory = await _categoryService.GetAll();
                if (dbCategory == null)
                    return NotFound();

                await _categoryService.Update(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


       
    }
}
