﻿// <auto-generated />
using System;
using Database.Scada;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Scada.Migrations
{
    [DbContext(typeof(ScadaDbContext))]
    [Migration("20230604143015_ExtensionDatabase")]
    partial class ExtensionDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Database.Scada.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Database.Scada.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContactorId")
                        .HasColumnType("int");

                    b.Property<int?>("ContractorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Database.Scada.Models.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REGON")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Database.Scada.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Fired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hired")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFired")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Database.Scada.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplyId")
                        .IsUnique();

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Database.Scada.Models.ProductionOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContractorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quanity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ScheduledEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduledStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductionOrders");
                });

            modelBuilder.Entity("Database.Scada.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Database.Scada.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Database.Scada.Models.Supply", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("Database.Scada.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContractorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentCreditingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Database.Scada.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDeleted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("Database.Scada.Models.Contact", b =>
                {
                    b.HasOne("Database.Scada.Models.Contractor", "Contractor")
                        .WithMany("Contacts")
                        .HasForeignKey("ContractorId");

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("Database.Scada.Models.Contractor", b =>
                {
                    b.HasOne("Database.Scada.Models.Address", "Address")
                        .WithMany("Contractors")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Database.Scada.Models.Employee", b =>
                {
                    b.HasOne("Database.Scada.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Database.Scada.Models.Product", b =>
                {
                    b.HasOne("Database.Scada.Models.Supply", "Supply")
                        .WithOne("Product")
                        .HasForeignKey("Database.Scada.Models.Product", "SupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Scada.Models.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supply");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Database.Scada.Models.ProductionOrder", b =>
                {
                    b.HasOne("Database.Scada.Models.Contractor", "Contractor")
                        .WithMany("ProductionOrders")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Scada.Models.Product", "Product")
                        .WithMany("ProductionOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Database.Scada.Models.Transaction", b =>
                {
                    b.HasOne("Database.Scada.Models.Contractor", "Contractor")
                        .WithMany("Transactions")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("EmployeeSkill", b =>
                {
                    b.HasOne("Database.Scada.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Scada.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Scada.Models.Address", b =>
                {
                    b.Navigation("Contractors");
                });

            modelBuilder.Entity("Database.Scada.Models.Contractor", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("ProductionOrders");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Database.Scada.Models.Product", b =>
                {
                    b.Navigation("ProductionOrders");
                });

            modelBuilder.Entity("Database.Scada.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Database.Scada.Models.Supply", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Database.Scada.Models.Unit", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}