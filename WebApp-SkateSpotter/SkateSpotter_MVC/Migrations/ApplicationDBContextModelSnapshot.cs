﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkateSpotter_MVC.Data;

#nullable disable

namespace SkateSpotter_MVC.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkateSpotter_MVC.Models.Skater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skaters");
                });

            modelBuilder.Entity("SkateSpotter_MVC.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkaterId")
                        .HasColumnType("int");

                    b.Property<float>("x_cord")
                        .HasColumnType("real");

                    b.Property<float>("y_cord")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SkaterId");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("SkateSpotter_MVC.Models.Spot", b =>
                {
                    b.HasOne("SkateSpotter_MVC.Models.Skater", "Skaters")
                        .WithMany("Spots")
                        .HasForeignKey("SkaterId");

                    b.Navigation("Skaters");
                });

            modelBuilder.Entity("SkateSpotter_MVC.Models.Skater", b =>
                {
                    b.Navigation("Spots");
                });
#pragma warning restore 612, 618
        }
    }
}
