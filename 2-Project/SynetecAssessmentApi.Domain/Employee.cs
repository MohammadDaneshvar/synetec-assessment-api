using System;

namespace SynetecAssessmentApi.Domain
{
    public class Employee : Entity
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public Employee(
            int id,
            string fullname,
            string jobTitle,
            decimal salary,
            int departmentId) :base(id)
        {
            Id = id;
            Fullname = fullname;
            JobTitle = jobTitle;
            Salary = salary;
            DepartmentId = departmentId;
        }
    }
}
