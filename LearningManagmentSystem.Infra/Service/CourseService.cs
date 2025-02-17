using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.DTO;
using LearningManagmentSystem.Core.Repo;
using LearningManagmentSystem.Core.Service;

namespace LearningManagmentSystem.Infra.Service
{
    public class CourseService : ICourseService
    {

        //you will handle the data here (Logic)
        //inject the previos layer Repo Layer #usually inject the interface
        private readonly ICourseRepo _courseRepo;

        public CourseService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        //1
        public List<Course> GetAllCourses()
        {
            return _courseRepo.GetAllCourses();
        }

        //2
        public void CreateNewCourse(Course course)
        {
            _courseRepo.CreateNewCourse(course);
        }

        //3
        public void UpdateCourse(Course course)
        {
            _courseRepo.UpdateCourse(course);
        }

        //4
        public void DeleteCourse(int id)
        {
            _courseRepo.DeleteCourse(id);
        }

        //5
        public Course GetCourseById(int id)
        {
            return _courseRepo.GetCourseById(id);
        }

        public List<CourseDTO> SearchCourseByName(string name)
        {
            return _courseRepo.SearchCourseByName(name);
        }
    }
}
