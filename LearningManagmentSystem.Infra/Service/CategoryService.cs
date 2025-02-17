using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Repo;
using LearningManagmentSystem.Core.Service;

namespace LearningManagmentSystem.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }


        public List<Category> GetAllCategory()
        {
            return _categoryRepo.GetAllCategory();
        }

        public void CreateNewCategory(Category category)
        {
            _categoryRepo.CreateNewCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepo.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepo.DeleteCategory(id);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepo.GetCategoryById(id);
        }

    }
}
