using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Constants
{
    public class AuthConstant
    {
        public enum Roles
        {
            Student,
            Instructor
        }
        public const string default_username = "student";
        public const string default_email = "student@student.com";
        public const string default_password = "Pa$$w0rd.";
        public const string default_first_name = "FirstName";
        public const string default_last_name = "LastName";
        public const Roles default_role = Roles.Student;
    }
}
