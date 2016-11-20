using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Data;
using Entidades;

namespace TestEF
{
  class Program
  {
    static void Main(string[] args)
    {
      TestContext ctx = TestContext.DB;

      AppDomain.CurrentDomain.UnhandledException += (s, e) =>
      {
        Console.WriteLine(" >>>>>>> CUIDADO Excepcion");
        ctx?.Dispose();
      };

      if (ctx.Database.Exists())
        Console.WriteLine("La base esta...");
      else
        Console.WriteLine(" >>>>>>> ERROR: no existe la base de datos...");

      Perfil p = ctx.Perfiles.FirstOrDefault();

      Usuario user;

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
      Console.WriteLine($"{p.Descripcion}");
      foreach (Usuario u in p.Usuarios)
        Console.WriteLine($"{u.Login}");
      Console.ReadLine();

      ctx.Dispose();
    }
  }
}
