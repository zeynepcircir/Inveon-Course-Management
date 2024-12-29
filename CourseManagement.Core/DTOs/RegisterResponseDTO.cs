using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class RegisterResponseDTO
    {
        public string Message { get; set; }
        public List<string?>? Errors { get; set; }
        public RegisterResponseDTO(string message, List<string?>? errors)
        {
            Message = message;
            Errors = errors;
        }
    }
}
