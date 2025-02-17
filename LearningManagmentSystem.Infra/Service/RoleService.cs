using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Repo;
using LearningManagmentSystem.Core.Service;
using LearningManagmentSystem.Infra.Repo;

namespace LearningManagmentSystem.Infra.Service
{
    public class RoleService :IRoleService
    {
        private readonly IRoleRepo _roleRepo;

        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public void CreateNewRole(Role role)
        {
            _roleRepo.CreateNewRole(role);
        }

        public void DeleteRole(int id)
        {
            _roleRepo.DeleteRole(id);

        }

        public List<Role> GetAllRole()
        {
            return _roleRepo.GetAllRole();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepo.GetRoleById(id);
        }

        public void UpdateRole(Role role)
        {
            _roleRepo.UpdateRole(role);
        }
    }
}
