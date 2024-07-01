
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class AdminDA
    {

        public bool logIn(Usuarios usuario)
        {
            try
            {
                using (ProyectoEntity context = new ProyectoEntity())
                {
                    return context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email &&
                    x.Contrasena == usuario.Contrasena && x.RolID== 1) != null;
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
