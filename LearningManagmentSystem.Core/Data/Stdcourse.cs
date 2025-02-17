using System;
using System.Collections.Generic;

namespace LearningManagmentSystem.Core.Data;

public partial class Stdcourse
{
    public int Id { get; set; }

    public int? Studid { get; set; }

    public int? Courseid { get; set; }

    public int? Markofstd { get; set; }

    public DateOnly? Dateofregister { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Stud { get; set; }
}
