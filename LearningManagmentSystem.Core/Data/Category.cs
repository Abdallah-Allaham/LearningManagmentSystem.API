using System;
using System.Collections.Generic;

namespace LearningManagmentSystem.Core.Data;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
