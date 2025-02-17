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
    public class StudentRepo : IStudentRepo
    {
        private readonly LmsdemoDbContext _lmsdemoDbContext;
        public StudentRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }

        public void CreateNewStudent(Student student)
        {
            var para = new[]
            {
                new SqlParameter("@id",student.Studentid),
                new SqlParameter("@fname",student.Firstname),
                new SqlParameter("@lname",student.Lastname),
                new SqlParameter("@date",student.Dateofbirth)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec CreateNewStudent @id,@fname,@lname,@date",para);
        }

        public void DeleteStudent(int id)
        {
            var para = new SqlParameter("@id", id);

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec DeleteStudent @id", para);
        }

        public List<Student> GetAllStudent()
        {
            var student= _lmsdemoDbContext.Students.FromSqlRaw("Exec GetAllStudent").ToList();
            return student;
        }

        public Student GetStudentById(int id)
        {
            var para = new SqlParameter("@id", id);
            return _lmsdemoDbContext.Students.FromSqlRaw("Exec GetStudentById @id",para).AsEnumerable().FirstOrDefault();
        }

        public void UpdateStudent(Student student)
        {
            var para = new[]
            {
                new SqlParameter("@id",student.Studentid),
                new SqlParameter("@fname",student.Firstname),
                new SqlParameter("@lname",student.Lastname),
                new SqlParameter("@date",student.Dateofbirth)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec UpdateStudent @id,@fname,@lname,@date", para);
        }
    }
}
