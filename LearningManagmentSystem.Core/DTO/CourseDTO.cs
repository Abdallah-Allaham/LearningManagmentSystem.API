using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagmentSystem.Core.DTO
{
    //if you don't need to retrive all data, or display from DB just some date, use DTO 

    //create this DTO to retrive specific column for filtering data (search course by name)
    public class CourseDTO
    {
        public string Coursename { get; set; } = null!;

        public string? Imagename { get; set; }
    }





    // look here if you have employee table in DB and you don't have column for AnnualSalary you can reduse your effort end create
    // DTO rather than use migration 
    // or like when you want to use the join table use DTO rather than migration
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MonthlySalary { get; set; }

        public decimal AnnualSalary => MonthlySalary * 12;
    }
}
