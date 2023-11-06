﻿// <auto-generated />
using System;
using ASP.NETCoreWebApplication2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NETCoreWebApplication2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP.NETCoreWebApplication2.Player.Entity.BuildHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateUtcTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("ASP.NETCoreWebApplication2.Player.Entity.HockeyPlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Dribbling")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GuardianShip")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Interception")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsVeteran")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Opening")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pass")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PreferredTeam")
                        .HasColumnType("int");

                    b.Property<decimal>("PuckSelection")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReceivingPuck")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<decimal>("Shot")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Staking")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Stamina")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Vision")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
