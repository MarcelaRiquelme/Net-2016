using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Data
{
    /// <summary>
    /// [[SINGLETON]]
    /// </summary>
    public class TestEFContext : DbContext
    {
        public static TestEFContext DB { get; private set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Perfil> Perfiles { get; set; }

        private StreamWriter _writer;

        static TestEFContext()
        {
            DB = new TestEFContext();
        }

        private TestEFContext()
        {
            //  crear writer para log de eventos
            _writer = File.CreateText($@"F:\CURSO .NET\Repositorio GitHub\Consola_Usuario\db\{this.GetType().Name}.log");
            this.Database.Log = (s) => _writer.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConfiguracionUsuario());
            modelBuilder.Configurations.Add(new ConfiguracionPerfil());


        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
                _writer?.Dispose();
        }
    }

    public class ConfiguracionUsuario : EntityTypeConfiguration<Usuario>
    {
        public ConfiguracionUsuario()
        {
            this.HasKey(usr => usr.Login);

           

            this.HasRequired(usr => usr.Perfil)
              .WithMany(p => p.Usuarios)
              .Map(cfg => cfg.MapKey("ID_Perfil"));



        }
    }
    

    public class ConfiguracionPerfil : EntityTypeConfiguration<Perfil>
    {
        public ConfiguracionPerfil()
        {
            ToTable("Perfiles");    //  evitamos Perfils

            this.HasKey(per => per.IDPerfil);

            this.Property(per => per.IDPerfil).HasColumnName("ID_Perfil");// se debe aclarar cuando en la base de datos tiene un nombre diferente al código en la clase. Si son iguales se evita este paso

           
            this.Property(pa => pa.Nombre).HasColumnName("Descripcion");

            //this.HasMany(per => per.Usuarios)
            //  .WithRequired(usr => usr.Perfil)
            //  .Map(cfg => cfg.MapKey("ID_Perfil"));
        }
    }
}
