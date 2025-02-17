using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagmentSystem.Core.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }

        public string? Token { get; set; }

        public int Roleid { get; set; }

    }
}
