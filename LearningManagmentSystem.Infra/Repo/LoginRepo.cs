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
    public class LoginRepo :ILoginRepo
    {
        private readonly LmsdemoDbContext _lmsdemoDbContext;
        public LoginRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }

        public void CreateNewLogin(Login login)
        {
            var para = new[]
            {
                new SqlParameter("@id",login.Loginid),
                new SqlParameter("@username",login.Username),
                new SqlParameter("@pass",login.Password),
                new SqlParameter("@Roleid",login.Roleid),
                new SqlParameter("@Studentid",login.Studentid)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec CreateNewLogin @id,@username,@pass,@Roleid,@Studentid", para);
        }

        public void DeleteLogin(int id)
        {
            var para = new SqlParameter("@id", id);

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec DeleteLogin @id",para);
        }

        public List<Login> GetAllLogin()
        {
            return _lmsdemoDbContext.Logins.FromSqlRaw("Exec GetAllLogin ").ToList();
        }

        public Login GetLoginById(int id)
        {
            var para = new SqlParameter("@id", id);

            return _lmsdemoDbContext.Logins.FromSqlRaw("Exec GetLoginById @id", para).AsEnumerable().FirstOrDefault();
        }

        public void UpdateLogin(Login login)
        {
            var para = new[]
            {
                new SqlParameter("@id",login.Loginid),
                new SqlParameter("@username",login.Username),
                new SqlParameter("@pass",login.Password),
                new SqlParameter("@Roleid",login.Roleid),
                new SqlParameter("@Studentid",login.Studentid)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec UpdateLogin @id,@username,@pass,@Roleid,@Studentid", para);
        }
    }
}
