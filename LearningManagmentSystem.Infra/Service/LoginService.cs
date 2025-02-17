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
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginRepo;

        public LoginService(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public void CreateNewLogin(Login login)
        {
            _loginRepo.CreateNewLogin(login);
        }

        public void DeleteLogin(int id)
        {
            _loginRepo.DeleteLogin(id);
        }

        public List<Login> GetAllLogin()
        {
            return _loginRepo.GetAllLogin();
        }

        public Login GetLoginById(int id)
        {
            return _loginRepo.GetLoginById(id);
        }

        public void UpdateLogin(Login login)
        {
            _loginRepo.UpdateLogin(login);
        }
    }
}
