using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_2.Models
{
    public class Isciler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string GMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool TrueFalse { get; set; }
    }
}
