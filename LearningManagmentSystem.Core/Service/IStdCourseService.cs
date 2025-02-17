using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;

namespace LearningManagmentSystem.Core.Service
{
    public interface IStdCourseService
    {
        List<Stdcourse> GetAllStdCourse();

        void CreateNewStdCourse(Stdcourse stdCourse);

        void UpdateStdCourse(Stdcourse stdCourse);

        void DeleteStdCourse(int id);

        Stdcourse GetStdCourseById(int id);
    }
}
