using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;

namespace LearningManagmentSystem.Core.Repo
{
    public interface ILoginRepo
    {
        List<Login> GetAllLogin();

        void CreateNewLogin(Login login);

        void UpdateLogin(Login login);

        void DeleteLogin(int id);

        Login GetLoginById(int id);
    }
}
