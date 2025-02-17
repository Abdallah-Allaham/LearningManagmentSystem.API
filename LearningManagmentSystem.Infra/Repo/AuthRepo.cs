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
    public class AuthRepo : IAuthRepo
    {

        private readonly LmsdemoDbContext _lmsdemoDbContext;
        public AuthRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }


        public LoginDTO Login(Login login)
        {
            var para = new[]
            {
                new SqlParameter("@USER_NAME",login.Username),
                new SqlParameter("@pass",login.Password)
            };

            var userLogin = _lmsdemoDbContext.Logins.FromSqlRaw("Exec User_Login @user_name, @pass", para)
                .AsEnumerable().SingleOrDefault();

            if (userLogin == null) return null;
            
            //Map
            var userLoginDTO = new LoginDTO
            {

                Username = userLogin.Username,
                Roleid= (int)userLogin.Roleid
            };

            return userLoginDTO;
        }
    }
}
