using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionBasica.Models
{
    public class UserServiceDAL
    {

        public static Boolean checkUser(string login,string password)
        {
           // bool check = false;
            int c = 0;
            using (EjemploEntities ctx = new EjemploEntities())
            {

               c = (from p in ctx.Usuarios
                            where p.user == login && p.pass == password select p).Count();

            }
            return c > 0;
        }

    }
}