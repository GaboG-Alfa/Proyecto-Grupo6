using DA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AccountBL
    {
        private UserDA accountDA = new UserDA();
        public bool logIn(Account account)
        {
            bool accountExits = accountDA.logIn(account);
            if (!accountExits)
            {
                throw new Exception("Incorrect credentials");
            }
            return accountExits;
        }
    }
}
