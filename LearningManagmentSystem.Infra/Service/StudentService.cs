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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public void CreateNewStudent(Student student)
        {
            _studentRepo.CreateNewStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepo.DeleteStudent(id);
        }

        public List<Student> GetAllStudent()
        {
            return _studentRepo.GetAllStudent();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepo.GetStudentById(id);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepo.UpdateStudent(student);
        }
    }
}
