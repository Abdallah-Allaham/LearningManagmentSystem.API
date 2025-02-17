using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;

namespace LearningManagmentSystem.Core.Repo
{
    public interface IStudentRepo
    {
        List<Student> GetAllStudent();

        void CreateNewStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);

        Student GetStudentById(int id);
    }
}
