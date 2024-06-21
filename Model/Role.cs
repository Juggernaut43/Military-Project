using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDapar { get; set; }
        public int MinProfile { get; set; }
        public RequirementsList Requirements { get; set; }

        public string Requiementtring
        {
            get
            {
                string retVal = "";
                foreach (var item in Requirements)
                {
                    retVal += $"{item.Skill.ToString()}-{Apiervice.NumberToName(item.MinGrade, false)} ";                    
                }
                return retVal;
            }
        }
    }
}
