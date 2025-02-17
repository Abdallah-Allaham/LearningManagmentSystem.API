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
    public class RoleRepo : IRoleRepo
    {
        private readonly LmsdemoDbContext _lmsdemoDbContext;

        public RoleRepo(LmsdemoDbContext lmsdemoDbContext)
        {
            _lmsdemoDbContext = lmsdemoDbContext;
        }

        public void CreateNewRole(Role role)
        {
            var para = new[]
            {
                new SqlParameter("@id",role.Roleid),
                new SqlParameter("@RoleName",role.Rolename)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec CreateNewRole @id,@RoleName", para);
        }

        public void DeleteRole(int id)
        {
            var para = new SqlParameter("@id", id);

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec DeleteRole @id", para);
        }

        public List<Role> GetAllRole()
        {
            return _lmsdemoDbContext.Roles.FromSqlRaw("Exec GetAllRole ").ToList();
        }

        public Role GetRoleById(int id)
        {
            var para = new SqlParameter("@id", id);

            return _lmsdemoDbContext.Roles.FromSqlRaw("Exec GetRoleById @id", para).AsEnumerable().FirstOrDefault();
        }

        public void UpdateRole(Role role)
        {
            var para = new[]
            {
                new SqlParameter("@id",role.Roleid),
                new SqlParameter("@RoleName",role.Rolename)
            };

            _lmsdemoDbContext.Database.ExecuteSqlRaw("Exec UpdateRole @id,@RoleName", para);
        }
    }
}
