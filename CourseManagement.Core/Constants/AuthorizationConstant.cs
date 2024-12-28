using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Constants
{
    public class AuthorizationConstant
    {
        public enum Roles
        {
            Student,
            Instructor
        }
        public const string default_username = "student";
        public const string default_email = "student@student.com";
        public const string default_password = "Pa$$w0rd.";
        public const Roles default_role = Roles.Student;
    }
}
