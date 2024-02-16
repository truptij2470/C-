using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationTrupi.Models;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookstable> Bookstables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=Books;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookstable>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__Bookstab__8BEA95C5CCC7FDDF");

            entity.ToTable("Bookstable");

            entity.Property(e => e.Bookid)
                .ValueGeneratedNever()
                .HasColumnName("bookid");
            entity.Property(e => e.Bookauthor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookauthor");
            entity.Property(e => e.Bookname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookname");
            entity.Property(e => e.Bookprice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bookprice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
