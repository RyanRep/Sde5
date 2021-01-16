using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Sde5.Models.Sde;

namespace Sde5.Data
{
  public partial class SdeContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public SdeContext(DbContextOptions<SdeContext> options):base(options)
    {
    }

    public SdeContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Sde5.Models.Sde.ListExtract>().HasNoKey();
        builder.Entity<Sde5.Models.Sde.DeliveryExtract>()
              .HasOne(i => i.Extract)
              .WithMany(i => i.DeliveryExtracts)
              .HasForeignKey(i => i.ExtractId)
              .HasPrincipalKey(i => i.ExtractId);
        builder.Entity<Sde5.Models.Sde.DeliveryParameter>()
              .HasOne(i => i.DeliveryExtract)
              .WithMany(i => i.DeliveryParameters)
              .HasForeignKey(i => i.DeliveryExtractId)
              .HasPrincipalKey(i => i.DeliveryExtractId);
        builder.Entity<Sde5.Models.Sde.DeliveryParameter>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.DeliveryParameters)
              .HasForeignKey(i => i.ParameterId)
              .HasPrincipalKey(i => i.ParameterId);
        builder.Entity<Sde5.Models.Sde.DeliveryParameter>()
              .HasOne(i => i.ParameterValue)
              .WithMany(i => i.DeliveryParameters)
              .HasForeignKey(i => i.ParameterValueCode)
              .HasPrincipalKey(i => i.ParameterValueCode);
        builder.Entity<Sde5.Models.Sde.Parameter>()
              .HasOne(i => i.Extract)
              .WithMany(i => i.Parameters)
              .HasForeignKey(i => i.ExtractId)
              .HasPrincipalKey(i => i.ExtractId);


        this.OnModelBuilding(builder);
    }


    public DbSet<Sde5.Models.Sde.DeliveryExtract> DeliveryExtracts
    {
      get;
      set;
    }

    public DbSet<Sde5.Models.Sde.DeliveryParameter> DeliveryParameters
    {
      get;
      set;
    }

    public DbSet<Sde5.Models.Sde.Extract> Extracts
    {
      get;
      set;
    }

    public DbSet<Sde5.Models.Sde.List> Lists
    {
      get;
      set;
    }

    public DbSet<Sde5.Models.Sde.ListExtract> ListExtracts
    {
      get;
      set;
    }

    public DbSet<Sde5.Models.Sde.Parameter> Parameters
    {
      get;
      set;
    }

    public DbSet<Sde5.Models.Sde.ParameterValue> ParameterValues
    {
      get;
      set;
    }
  }
}
