﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Transaction.Models
{
    public partial class BankContext : DbContext
    {
        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<branch> branches { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<trandetail> trandetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-SUEL2B7F;Initial Catalog=Bank;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<account>(entity =>
            {
                entity.HasKey(e => e.acnumber)
                    .HasName("account_acnumber_pk");

                entity.ToTable("account");

                entity.Property(e => e.acnumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.aod).HasColumnType("date");

                entity.Property(e => e.astatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.atype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.bid)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.custid)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.opening_balance).HasColumnType("numeric(7, 0)");

                entity.HasOne(d => d.bidNavigation)
                    .WithMany(p => p.accounts)
                    .HasForeignKey(d => d.bid)
                    .HasConstraintName("account_bid_fk");

                entity.HasOne(d => d.cust)
                    .WithMany(p => p.accounts)
                    .HasForeignKey(d => d.custid)
                    .HasConstraintName("account_custid_fk");
            });

            modelBuilder.Entity<branch>(entity =>
            {
                entity.HasKey(e => e.bid)
                    .HasName("branch_bid_pk");

                entity.ToTable("branch");

                entity.Property(e => e.bid)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.bcity)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.bname)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.HasKey(e => e.custid)
                    .HasName("customer_custid_pk");

                entity.ToTable("customer");

                entity.Property(e => e.custid)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.city)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.dob).HasColumnType("date");

                entity.Property(e => e.fname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ltname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.mname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.mobileno)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.occupation)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<trandetail>(entity =>
            {
                entity.HasKey(e => e.tnumber)
                    .HasName("trandetails_tnumber_pk");

                entity.Property(e => e.tnumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.acnumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.dot).HasColumnType("date");

                entity.Property(e => e.transaction_amount).HasColumnType("numeric(7, 0)");

                entity.Property(e => e.transaction_type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.acnumberNavigation)
                    .WithMany(p => p.trandetails)
                    .HasForeignKey(d => d.acnumber)
                    .HasConstraintName("trandetails_acnumber_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}