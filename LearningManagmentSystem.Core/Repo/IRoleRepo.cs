using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;

namespace LearningManagmentSystem.Core.Repo
{
    public interface IRoleRepo
    {
        List<Role> GetAllRole();

        void CreateNewRole(Role role);

        void UpdateRole(Role role);

        void DeleteRole(int id);

        Role GetRoleById(int id);
    }
}
