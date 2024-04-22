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
            var db = new UsersDB();
            var user = db.SelectALL();
            int x = 2;
        }
    }
}
