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
    public class StdCourseService :IStdCourseService
    {
        private readonly IStdCourseRepo _stdCourseRepo;

        public StdCourseService(IStdCourseRepo stdCourseRepo)
        {
            _stdCourseRepo = stdCourseRepo;
        }

        public void CreateNewStdCourse(Stdcourse stdCourse)
        {
            _stdCourseRepo.CreateNewStdCourse(stdCourse);
        }

        public void DeleteStdCourse(int id)
        {
            _stdCourseRepo.DeleteStdCourse(id);
        }

        public List<Stdcourse> GetAllStdCourse()
        {
            return _stdCourseRepo.GetAllStdCourse();
        }

        public Stdcourse GetStdCourseById(int id)
        {
            return _stdCourseRepo.GetStdCourseById(id);
        }

        public void UpdateStdCourse(Stdcourse stdCourse)
        {
            _stdCourseRepo.UpdateStdCourse(stdCourse);
        }
    }
}
