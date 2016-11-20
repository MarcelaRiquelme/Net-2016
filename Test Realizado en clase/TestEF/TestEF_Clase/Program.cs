using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data_Clase;
using Entidades;

namespace TestEF_Clase
{
  class Program
  {
    static void Main(string[] args)
    {
      TestEFContext ctx = new TestEFContext();

      if (ctx.Database.Exists())
        Console.WriteLine("La base esta....");
      Console.ReadLine();

      Perfil p = ctx.Perfiles.FirstOrDefault();

      Console.WriteLine($"{p.Descripcion}");

      Console.ReadLine();
    }
  }
}
