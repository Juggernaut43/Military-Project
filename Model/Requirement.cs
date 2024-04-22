using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requirement
    {
       
        public int RoleId { get; set; }
        public Skills Skill { get; set; }
        public int MinGrade { get; set; }
    }

    public enum Skills
    {
        Command = 1,
        Teamwork = 2,
        Attention = 3,
        InformationProcession = 4,
    }

}
