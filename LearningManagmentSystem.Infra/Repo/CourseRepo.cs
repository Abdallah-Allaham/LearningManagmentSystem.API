using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.DTO;
using LearningManagmentSystem.Core.Repo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagmentSystem.Infra.Repo
{
    public class CourseRepo : ICourseRepo
    {
        //inject the previos layer Domain Layer(DB)
        private readonly LmsdemoDbContext _lmsdemoDbContext;

        public CourseRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }

        //1
        public List<Course> GetAllCourses()
        {
            return _lmsdemoDbContext.Courses.FromSqlRaw("exec GetAllCourse").ToList();
        }

        //2
        public void CreateNewCourse(Course course)
        {
            var para = new[]
            {
                new SqlParameter("@id",course.Courseid),
                new SqlParameter("@CourseName",course.Coursename),
                new SqlParameter("@CategoryID",course.Categoryid),
                new SqlParameter("@ImageName",course.Imagename)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec CreateNewCourse @id,@CourseName,@CategoryID,@ImageName", para);
        }

        //3
        public void UpdateCourse(Course course)
        {
            var para = new[]
            {
                new SqlParameter("@id",course.Courseid),
                new SqlParameter("@CourseName",course.Coursename),
                new SqlParameter("@CategoryID",course.Categoryid),
                new SqlParameter("@ImageName",course.Imagename)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec UpdateCourse @id,@CourseName,@CategoryID,@ImageName", para);
        }

        //4
        public void DeleteCourse(int id)
        {
            //var para = new[]
            //{
            //    new SqlParameter("@id",id)
            //};

            //or

            var para = new SqlParameter("@id", id);


            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec DeleteCourse @id", para);
        }

        //5
        public Course GetCourseById(int id)
        {
            //if you have procedure
            var para = new SqlParameter("@id", id);

            return _lmsdemoDbContext.Courses.FromSqlRaw("Exec GetCourseById @id", para).AsEnumerable().FirstOrDefault();
            

            //if you don't have
            
        }

        // for filteration Data after create the procedure for this process
        // and after create CourseDTO 
        // i will create method to return some data throw (CourseDTO) 
        public List<CourseDTO> SearchCourseByName(string name)
        {
            var para = new SqlParameter("@CourseName",name);

            var courses=_lmsdemoDbContext.Courses.FromSqlRaw("Exec SearchCourseByName @CourseName",para).ToList();

            //Map
            //because i retrive data from course i need to convert data to CourseDTO throw Map
            var coursesDTO = courses.Select(c => new CourseDTO
            {
                Coursename=c.Coursename,
                Imagename=c.Imagename
            }).ToList();

            return coursesDTO;

        }
    }
}
