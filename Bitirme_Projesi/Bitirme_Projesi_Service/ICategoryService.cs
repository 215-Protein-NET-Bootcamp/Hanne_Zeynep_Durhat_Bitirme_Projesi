using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> AddCategory(CategoryDto catDto);
        Task<Category> Update(CategoryDto catDto);

    }
}
