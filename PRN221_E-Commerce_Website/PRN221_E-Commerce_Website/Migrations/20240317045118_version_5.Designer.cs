﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PRN221_E_Commerce_Website.Data;

#nullable disable

namespace PRN221_E_Commerce_Website.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240317045118_version_5")]
    partial class version_5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Account");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("Gender");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Password");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("Phone");

                    b.Property<int>("RoleID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("roleID");

                    b.HasKey("Id");

                    b.HasIndex("RoleID");

                    b.HasIndex(new[] { "AccountName" }, "accountName")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CategoryID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("OrderID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("AccountID");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PizzaId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("PizzaID");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer");

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PayMethodID")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderID", "PizzaId");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.HasIndex("PayMethodID");

                    b.ToTable("Order Detail", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.PayMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("PayMethod", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("PizzaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("IsAvailable")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PizzaImage")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pizza", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.UserPaymentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSuccees")
                        .HasColumnType("boolean");

                    b.Property<int>("PayMethodID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PayMethodID");

                    b.ToTable("UserPaymentTransaction", (string)null);
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Account", b =>
                {
                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Order", b =>
                {
                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.Pizza", "Pizza")
                        .WithMany("Orders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.Order", "Order")
                        .WithOne("OrderDetail")
                        .HasForeignKey("PRN221_E_Commerce_Website.Data.Entities.OrderDetail", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.PayMethod", "PayMethod")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PayMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PayMethod");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Pizza", b =>
                {
                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.Category", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.UserPaymentTransaction", b =>
                {
                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.Account", "Account")
                        .WithMany("UserPaymentTransaction")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRN221_E_Commerce_Website.Data.Entities.PayMethod", "PayMethod")
                        .WithMany("UserPaymentTransactions")
                        .HasForeignKey("PayMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PayMethod");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Account", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserPaymentTransaction");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Category", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.PayMethod", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("UserPaymentTransactions");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Pizza", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PRN221_E_Commerce_Website.Data.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
