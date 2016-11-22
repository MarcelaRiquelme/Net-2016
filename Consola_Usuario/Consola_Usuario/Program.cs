using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Data;
using Entidades;



namespace Consola_Usuario
{
    class Program
    {
        static void Main(string[] args)
        {
            TestEFContext ctx = TestEFContext.DB;

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Console.WriteLine(" >>>>>>> CUIDADO Excepcion");
                ctx?.Dispose();
            };

            if (ctx.Database.Exists())
                Console.WriteLine("La base esta...");
            else
                Console.WriteLine(" >>>>>>> ERROR: no existe la base de datos...");



            // Perfil p = ctx.Perfiles.FirstOrDefault();
            Usuario usr = ctx.Usuarios.Where(u => u.Login == "maria").FirstOrDefault();
            Console.WriteLine($"{usr.Login} {usr.Perfil.Nombre}");
            Perfil p = usr.Perfil;
            foreach (var pp in p.Usuarios)
                 Console.WriteLine($"{pp.Login}");
               Console.ReadLine();

                //Usuario user;

                //user = new Usuario()
                //{
                //  Login = "root1",
                //  Perfil = p
                //};

                //ctx.Usuarios.Add(user);

                //  user = ctx.Usuarios.FirstOrDefault();

                //ctx.SaveChanges();
                //  Console.WriteLine($"ID Perfil: {p.IDPerfil} ; Descripcion:  {p.Descripcion}");
                //  Console.WriteLine($"{user.Login} {user.Perfil.Descripcion}");
                // Console.WriteLine($"{p.Nombre}");
                //Usuario usr = ctx.Usuarios.FirstOrDefault();

                //Console.WriteLine($"{usr.Login} {usr.Perfil.Nombre}");
                // Perfil p1 = ctx.Perfiles.Where(per => per.Nombre.ToLower() == "avanzado").FirstOrDefault();

                // if (p1 == null)

                // {
                //     p1 = new Perfil();
                //     p1.Nombre = "avanzado";


                // }
                // p1.Nombre = "Invitado";
                //Usuario usr = new Usuario();
                // usr.Login = "maria2";
                // usr.Perfil = p1;
                // ctx.Usuarios.Add(usr);
                // ctx.SaveChanges();

                

                ctx.Dispose();
        }
    }
}
