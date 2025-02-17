using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Repo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagmentSystem.Infra.Repo
{
     public class CategoryRepo :ICategoryRepo
    {
        //inject the previos layer Domain Layer(DB)
        private readonly LmsdemoDbContext _lmsdemoDbContext;

        public CategoryRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }

        //1
        public List<Category> GetAllCategory()
        {
            return _lmsdemoDbContext.Categories.FromSqlRaw("exec GetAllCategory").ToList();
        }

        //2
        public void CreateNewCategory(Category category)
        {
            var para = new[]
            {
                new SqlParameter("@id",category.Categoryid),
                new SqlParameter("@categoryname",category.Categoryname)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec CreateNewCategory @id,@categoryname", para);
        }

        //3
        public void UpdateCategory(Category category)
        {
            var para = new[]
            {
                new SqlParameter("@id",category.Categoryid),
                new SqlParameter("@categoryname",category.Categoryname)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec UpdateCategory @id,@categoryname", para);
        }

        //4
        public void DeleteCategory(int id)
        {
            var para = new SqlParameter("@id", id);


            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec DeleteCategory @id", para);
        }

        //5
        public Category GetCategoryById(int id)
        {
            //if you have procedure
            var para = new SqlParameter("@id", id);

            return _lmsdemoDbContext.Categories.FromSqlRaw("Exec GetCategoryById @id", para).AsEnumerable().FirstOrDefault();


            //if you don't have

        }
    }
}
