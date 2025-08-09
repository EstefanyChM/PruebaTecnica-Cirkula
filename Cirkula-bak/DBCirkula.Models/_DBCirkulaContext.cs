using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBCirkula.Models;

public partial class _DBCirkulaContext : DbContext
{
    public _DBCirkulaContext()
    {
    }

    public _DBCirkulaContext(DbContextOptions<_DBCirkulaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Store__3214EC07ACE8ABFB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
