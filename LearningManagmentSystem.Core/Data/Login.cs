using System;
using System.Collections.Generic;

namespace LearningManagmentSystem.Core.Data;

public partial class Login
{
    public int Loginid { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Roleid { get; set; }

    public int? Studentid { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Student? Student { get; set; }
}
