using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Entities
{
    public class ShoppingCartCourse : BaseEntity
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
