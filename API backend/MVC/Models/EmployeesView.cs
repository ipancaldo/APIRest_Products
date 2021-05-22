using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeesView
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        //public string Name { get; set; }
        public string FirstName { get; set; }
        //public DateTime Birthday { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public int Seniority { get; set; }
        //public string Phone { get; set; }
        public string HomePhone { get; set; }
    }
}