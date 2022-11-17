using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DataAccess
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public string EMPCode { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }

    }
}
