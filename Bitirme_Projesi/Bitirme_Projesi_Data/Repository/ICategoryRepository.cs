using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Data.Repository
{
    public interface ICategoryRepository
    {
       public  Task<IEnumerable<Category>> GetAll();
       public Task<Category> AddCategory(CategoryDto category);
       public Task<Category> UpdateCategory(Category category);
    }
}
