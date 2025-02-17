using System;
using System.Collections.Generic;

namespace LearningManagmentSystem.Core.Data;

public partial class Course
{
    public int Courseid { get; set; }

    public string Coursename { get; set; } = null!;

    public int? Categoryid { get; set; }

    public string? Imagename { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Stdcourse> Stdcourses { get; set; } = new List<Stdcourse>();
}
