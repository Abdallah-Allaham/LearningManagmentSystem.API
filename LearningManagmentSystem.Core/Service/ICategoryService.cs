using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;

namespace LearningManagmentSystem.Core.Service
{
    public interface ICategoryService
    {
        //1. GetAllCategory
        List<Category> GetAllCategory();


        //2. CreateNewCategory
        void CreateNewCategory(Category category);


        //3. UpdateCategory
        void UpdateCategory(Category category);


        //4. DeleteCategory
        void DeleteCategory(int id);


        //5. GetCategoryById
        Category GetCategoryById(int id);
    }
}
