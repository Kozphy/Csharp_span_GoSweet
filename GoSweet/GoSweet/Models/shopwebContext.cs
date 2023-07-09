﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoSweet.Models
{
    public partial class shopwebContext : DbContext
    {
        public shopwebContext()
        {
        }

        public shopwebContext(DbContextOptions<shopwebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer_accounttable> Customer_accounttables { get; set; }
        public virtual DbSet<Customer_datatable> Customer_datatables { get; set; }
        public virtual DbSet<Firm_accounttable> Firm_accounttables { get; set; }
        public virtual DbSet<Firm_datatable> Firm_datatables { get; set; }
        public virtual DbSet<Firm_pagetable> Firm_pagetables { get; set; }
        public virtual DbSet<Firm_picturetable> Firm_picturetables { get; set; }
        public virtual DbSet<Group_datatable> Group_datatables { get; set; }
        public virtual DbSet<Lock_datatable> Lock_datatables { get; set; }
        public virtual DbSet<Member_membertable> Member_membertables { get; set; }
        public virtual DbSet<Notify_datatable> Notify_datatables { get; set; }
        public virtual DbSet<Order_assesstable> Order_assesstables { get; set; }
        public virtual DbSet<Order_datatable> Order_datatables { get; set; }
        public virtual DbSet<Product_datatable> Product_datatables { get; set; }
        public virtual DbSet<Product_picturetable> Product_picturetables { get; set; }
        public virtual DbSet<Talk_datatable> Talk_datatables { get; set; }
        public virtual DbSet<Talk_persontable> Talk_persontables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_accounttable>(entity =>
            {
                entity.HasKey(e => e.c_number)
                    .HasName("PK_c_accounttable");

                entity.ToTable("Customer_accounttable");

                entity.Property(e => e.c_account)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.c_nickname)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.c_password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer_datatable>(entity =>
            {
                entity.HasKey(e => e.c_number)
                    .HasName("PK_c_datatable");

                entity.ToTable("Customer_datatable");

                entity.Property(e => e.c_number).ValueGeneratedNever();

                entity.Property(e => e.c_email).HasMaxLength(50);

                entity.Property(e => e.c_name).HasMaxLength(50);

                entity.Property(e => e.c_phone).HasMaxLength(50);

                entity.Property(e => e.c_place).HasMaxLength(50);

                entity.HasOne(d => d.c_numberNavigation)
                    .WithOne(p => p.Customer_datatable)
                    .HasForeignKey<Customer_datatable>(d => d.c_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_datatable_Customer_accounttable");
            });

            modelBuilder.Entity<Firm_accounttable>(entity =>
            {
                entity.HasKey(e => e.f_number)
                    .HasName("PK_f_accounttable");

                entity.ToTable("Firm_accounttable");

                entity.Property(e => e.f_account)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.f_nickname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.f_password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Firm_datatable>(entity =>
            {
                entity.HasKey(e => e.f_number)
                    .HasName("PK_f_datatable");

                entity.ToTable("Firm_datatable");

                entity.Property(e => e.f_number).ValueGeneratedNever();

                entity.Property(e => e.f_mail).HasMaxLength(50);

                entity.Property(e => e.f_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.f_personname).HasMaxLength(50);

                entity.Property(e => e.f_place).HasMaxLength(50);

                entity.HasOne(d => d.f_numberNavigation)
                    .WithOne(p => p.Firm_datatable)
                    .HasForeignKey<Firm_datatable>(d => d.f_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Firm_datatable_Firm_accounttable");
            });

            modelBuilder.Entity<Firm_pagetable>(entity =>
            {
                entity.HasKey(e => e.f_numberr)
                    .HasName("PK_f_pagetable");

                entity.ToTable("Firm_pagetable");

                entity.Property(e => e.f_numberr).ValueGeneratedNever();

                entity.Property(e => e.f_message).HasMaxLength(50);

                entity.Property(e => e.f_pagename)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.f_numberrNavigation)
                    .WithOne(p => p.Firm_pagetable)
                    .HasForeignKey<Firm_pagetable>(d => d.f_numberr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Firm_pagetable_Firm_accounttable");
            });

            modelBuilder.Entity<Firm_picturetable>(entity =>
            {
                entity.HasKey(e => new { e.f_numberr, e.f_picture })
                    .HasName("PK_f_picturetable");

                entity.ToTable("Firm_picturetable");

                entity.Property(e => e.f_picture).HasMaxLength(50);

                entity.HasOne(d => d.f_numberrNavigation)
                    .WithMany(p => p.Firm_picturetables)
                    .HasForeignKey(d => d.f_numberr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Firm_picturetable_Firm_accounttable");
            });

            modelBuilder.Entity<Group_datatable>(entity =>
            {
                entity.HasKey(e => e.g_number)
                    .HasName("PK_g_datatable");

                entity.ToTable("Group_datatable");

                entity.Property(e => e.g_end).HasColumnType("date");

                entity.Property(e => e.g_start).HasColumnType("date");

                entity.HasOne(d => d.f_numberNavigation)
                    .WithMany(p => p.Group_datatables)
                    .HasForeignKey(d => d.f_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_datatable_Firm_accounttable");

                entity.HasOne(d => d.p_numberNavigation)
                    .WithMany(p => p.Group_datatables)
                    .HasForeignKey(d => d.p_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_g_datatable_p_datatable");
            });

            modelBuilder.Entity<Lock_datatable>(entity =>
            {
                entity.HasKey(e => e.l_number)
                    .HasName("PK_l_datatable");

                entity.ToTable("Lock_datatable");

                entity.Property(e => e.l_number).ValueGeneratedNever();

                entity.Property(e => e.l_message).HasMaxLength(50);

                entity.HasOne(d => d.l_numberNavigation)
                    .WithOne(p => p.Lock_datatable)
                    .HasForeignKey<Lock_datatable>(d => d.l_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_datatable_Customer_accounttable");

                entity.HasOne(d => d.l_number1)
                    .WithOne(p => p.Lock_datatable)
                    .HasForeignKey<Lock_datatable>(d => d.l_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_datatable_Firm_accounttable");
            });

            modelBuilder.Entity<Member_membertable>(entity =>
            {
                entity.HasKey(e => e.m_number)
                    .HasName("PK_m_membertable");

                entity.ToTable("Member_membertable");

                entity.HasOne(d => d.g_numberNavigation)
                    .WithMany(p => p.Member_membertables)
                    .HasForeignKey(d => d.g_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_membertable_g_datatable");

                entity.HasOne(d => d.p_numberNavigation)
                    .WithMany(p => p.Member_membertables)
                    .HasForeignKey(d => d.p_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_membertable_p_datatable");
            });

            modelBuilder.Entity<Notify_datatable>(entity =>
            {
                entity.HasKey(e => e.n_number)
                    .HasName("PK_Notify_datatable_1");

                entity.ToTable("Notify_datatable");

                entity.Property(e => e.o_status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.c_numberNavigation)
                    .WithMany(p => p.Notify_datatables)
                    .HasForeignKey(d => d.c_number)
                    .HasConstraintName("FK_Notify_datatable_Customer_accounttable");

                entity.HasOne(d => d.f_numberNavigation)
                    .WithMany(p => p.Notify_datatables)
                    .HasForeignKey(d => d.f_number)
                    .HasConstraintName("FK_Notify_datatable_Firm_accounttable");

                entity.HasOne(d => d.o_numberNavigation)
                    .WithMany(p => p.Notify_datatables)
                    .HasForeignKey(d => d.o_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_n_datatable_o_datatable");
            });

            modelBuilder.Entity<Order_assesstable>(entity =>
            {
                entity.HasKey(e => new { e.o_number, e.p_number })
                    .HasName("PK_o_assesstable");

                entity.ToTable("Order_assesstable");

                entity.Property(e => e.o_ccomment).HasMaxLength(50);

                entity.Property(e => e.o_fcomment).HasMaxLength(50);

                entity.HasOne(d => d.o_numberNavigation)
                    .WithMany(p => p.Order_assesstables)
                    .HasForeignKey(d => d.o_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_o_assesstable_o_datatable");

                entity.HasOne(d => d.p_numberNavigation)
                    .WithMany(p => p.Order_assesstables)
                    .HasForeignKey(d => d.p_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_o_assesstable_p_datatable");
            });

            modelBuilder.Entity<Order_datatable>(entity =>
            {
                entity.HasKey(e => e.o_number)
                    .HasName("PK_o_datatable");

                entity.ToTable("Order_datatable");

                entity.Property(e => e.o_end).HasColumnType("date");

                entity.Property(e => e.o_place).HasMaxLength(50);

                entity.Property(e => e.o_shipstatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.o_start).HasColumnType("date");

                entity.Property(e => e.o_status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.c_numberNavigation)
                    .WithMany(p => p.Order_datatables)
                    .HasForeignKey(d => d.c_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_datatable_Customer_accounttable");

                entity.HasOne(d => d.f_numberNavigation)
                    .WithMany(p => p.Order_datatables)
                    .HasForeignKey(d => d.f_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_datatable_Firm_accounttable");

                entity.HasOne(d => d.m_numberNavigation)
                    .WithMany(p => p.Order_datatables)
                    .HasForeignKey(d => d.m_number)
                    .HasConstraintName("FK_o_datatable_m_membertable");

                entity.HasOne(d => d.p_numberNavigation)
                    .WithMany(p => p.Order_datatables)
                    .HasForeignKey(d => d.p_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_o_datatable_p_datatable");
            });

            modelBuilder.Entity<Product_datatable>(entity =>
            {
                entity.HasKey(e => e.p_number)
                    .HasName("PK_p_datatable");

                entity.ToTable("Product_datatable");

                entity.Property(e => e.p_category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.p_describe).HasMaxLength(50);

                entity.Property(e => e.p_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.p_savedate).HasMaxLength(50);

                entity.Property(e => e.p_saveway).HasMaxLength(50);

                entity.Property(e => e.p_spec).HasMaxLength(50);

                entity.HasOne(d => d.f_numberNavigation)
                    .WithMany(p => p.Product_datatables)
                    .HasForeignKey(d => d.f_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_datatable_Firm_accounttable");
            });

            modelBuilder.Entity<Product_picturetable>(entity =>
            {
                entity.HasKey(e => new { e.p_number, e.p_url })
                    .HasName("PK_p_picturetable");

                entity.ToTable("Product_picturetable");

                entity.Property(e => e.p_url).HasMaxLength(50);

                entity.HasOne(d => d.p_numberNavigation)
                    .WithMany(p => p.Product_picturetables)
                    .HasForeignKey(d => d.p_number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_p_picturetable_p_datatable");
            });

            modelBuilder.Entity<Talk_datatable>(entity =>
            {
                entity.HasKey(e => e.t_number)
                    .HasName("PK_t_datatable");

                entity.ToTable("Talk_datatable");

                entity.Property(e => e.t_message)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.t_time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Talk_persontable>(entity =>
            {
                entity.HasKey(e => e.t_id);

                entity.ToTable("Talk_persontable");

                entity.Property(e => e.t_id).HasMaxLength(50);

                entity.HasOne(d => d.c_numberNavigation)
                    .WithMany(p => p.Talk_persontables)
                    .HasForeignKey(d => d.c_number)
                    .HasConstraintName("FK_Talk_persontable_Customer_accounttable");

                entity.HasOne(d => d.f_numberNavigation)
                    .WithMany(p => p.Talk_persontables)
                    .HasForeignKey(d => d.f_number)
                    .HasConstraintName("FK_Talk_persontable_Firm_accounttable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}