using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiPractice3.Models;

public partial class ActsPuneContext : DbContext
{
    public ActsPuneContext()
    {
    }

    public ActsPuneContext(DbContextOptions<ActsPuneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=ActsPune;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__AF2D66D35525A93E");

            entity.Property(e => e.EmpNo).ValueGeneratedNever();
            entity.Property(e => e.Basic)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Basic ");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name ");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
