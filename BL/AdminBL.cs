using DA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AdminBL
    {
        private AdminDA adminDA = new AdminDA();
        public bool logIn(Usuarios admin)
        {
            bool adminExits = adminDA.logIn(admin);
            if (!adminExits)
            {
                throw new Exception("Incorrect credentials");
            }
            return adminExits;
        }
    }
}