using System;
using System.Collections.Generic;

namespace LearningManagmentSystem.Core.Data;

public partial class Student
{
    public int Studentid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateOnly? Dateofbirth { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Stdcourse> Stdcourses { get; set; } = new List<Stdcourse>();
}

