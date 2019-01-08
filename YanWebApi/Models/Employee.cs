using System;
namespace YanWebApi.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
