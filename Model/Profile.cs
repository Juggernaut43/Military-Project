using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Profile
    {
        public User User { get; set; }
        public int Dapar { get; set; }
        public int ProfileGrade { get; set; }
        public Yom100Grades Y100Grades { get; set; }

    }
}
