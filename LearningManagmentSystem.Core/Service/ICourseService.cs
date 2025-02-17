using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.DTO;

namespace LearningManagmentSystem.Core.Service
{
    public interface ICourseService
    {
        //1. GetAllCourses
        List<Course> GetAllCourses();


        //2. CreateNewCourse
        void CreateNewCourse(Course course);


        //3. UpdateCourse
        void UpdateCourse(Course course);


        //4. DeleteCourse
        void DeleteCourse(int id);


        //5. GetCourseById
        Course GetCourseById(int id);

        //for filteration Data after create the procedure for this process
        List<CourseDTO> SearchCourseByName(string name);
    }
}
