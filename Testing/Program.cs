﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new RolesDB();
            var user = db.SelectALL();
            int i = 1;

            Skills a = Skills.Teamwork;
            var l = a.ToString();
            
        }
    }
}
