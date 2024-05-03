﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(TollCollectionDbContext))]
    [Migration("20240503123421_RenameVehicleToTollPassageTable")]
    partial class RenameVehicleToTollPassageTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Data.Models.TollPassage", b =>
                {
                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RegistrationNumber", "Timestamp");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("TollPassages");
                });

            modelBuilder.Entity("Data.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TypeName")
                        .IsUnique();

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Motorbike"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Tractor"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Emergency"
                        },
                        new
                        {
                            Id = 4,
                            TypeName = "Diplomat"
                        },
                        new
                        {
                            Id = 5,
                            TypeName = "Foreign"
                        },
                        new
                        {
                            Id = 6,
                            TypeName = "Military"
                        },
                        new
                        {
                            Id = 7,
                            TypeName = "Taxable"
                        });
                });

            modelBuilder.Entity("Data.Models.TollPassage", b =>
                {
                    b.HasOne("Data.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleType");
                });
#pragma warning restore 612, 618
        }
    }
}