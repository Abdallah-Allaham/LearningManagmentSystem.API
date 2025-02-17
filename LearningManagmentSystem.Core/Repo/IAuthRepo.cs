using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.DTO;

namespace LearningManagmentSystem.Core.Repo
{
    public interface IAuthRepo
    {
        LoginDTO Login(Login login);
    }
}
