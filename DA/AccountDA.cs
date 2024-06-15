using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class AccountDA
    {

        public bool logIn(Account account)
        {
            try
            {
                using (Laboratorio2Entities context = new Laboratorio2Entities())
                {
                    return context.Account.FirstOrDefault(x => x.Email == account.Email &&
                    x.AccountPassword == account.AccountPassword && x.AccountRole == "admin") != null;
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return false;
        }
    }
}
