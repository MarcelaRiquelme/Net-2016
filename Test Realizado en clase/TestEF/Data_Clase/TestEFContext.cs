using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Data_Clase
{
  public class TestEFContext : DbContext
  {
    //  public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Perfil> Perfiles { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new ConfiguraPerfil());
    }
  }

  public class ConfiguraPerfil : EntityTypeConfiguration<Perfil>
  {
    public ConfiguraPerfil()
    {
      HasKey(p => p.IDPerfil);

      this.Property(p => p.IDPerfil).HasColumnName("ID_Perfil");

      this.ToTable("Perfiles");
    }
  }
}
