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
    public class StdCourseRepo : IStdCourseRepo
    {
        private readonly LmsdemoDbContext _lmsdemoDbContext;

        public StdCourseRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }

        public void CreateNewStdCourse(Stdcourse stdCourse)
        {
            var para = new[]
            {
                new SqlParameter("@id",stdCourse.Id),
                new SqlParameter("@studid",stdCourse.Studid),
                new SqlParameter("@courseid",stdCourse.Courseid),
                new SqlParameter("@date",stdCourse.Dateofregister),
                new SqlParameter("@mark",stdCourse.Markofstd)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec CreateNewStdCourse @id,@studid,@courseid,@mark,@date", para);
        }

        public void DeleteStdCourse(int id)
        {
            var para = new SqlParameter("@id", id);

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec DeleteStdCourse @id", para);
        }

        public List<Stdcourse> GetAllStdCourse()
        {
            var stdCourse = _lmsdemoDbContext.Stdcourses.FromSqlRaw("Exec GetAllStdCourse").ToList();
            return stdCourse;
        }

        public Stdcourse GetStdCourseById(int id)
        {
            var para = new SqlParameter("@id", id);
            return _lmsdemoDbContext.Stdcourses.FromSqlRaw("Exec GetStdCourseById @id", para).AsEnumerable().FirstOrDefault();
        }

        public void UpdateStdCourse(Stdcourse stdCourse)
        {
            var para = new[]
            {
                new SqlParameter("@id",stdCourse.Id),
                new SqlParameter("@studid",stdCourse.Studid),
                new SqlParameter("@courseid",stdCourse.Courseid),
                new SqlParameter("@date",stdCourse.Dateofregister),
                new SqlParameter("@mark",stdCourse.Markofstd)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec UpdatestdCourse @id,@studid,@courseid,@mark,@date", para);
        }

    }
}
