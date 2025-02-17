using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;

namespace LearningManagmentSystem.Core.Service
{
    public interface ILoginService
    {
        List<Login> GetAllLogin();

        void CreateNewLogin(Login login);

        void UpdateLogin(Login login);

        void DeleteLogin(int id);

        Login GetLoginById(int id);
    }
}
