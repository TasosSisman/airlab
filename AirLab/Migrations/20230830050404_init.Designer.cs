﻿// <auto-generated />
using System;
using AirLab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirLab.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230830050404_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirLab.Models.PurpleAirData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Humidity")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_10_0")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_1_0")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_1_0_atm")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_1_0_cf_1")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_10minute")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_1week")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_24hour")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_30minute")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_60minute")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_6hour")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_alt")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_atm")
                        .HasColumnType("float");

                    b.Property<double?>("Pm_2_5_cf_1")
                        .HasColumnType("float");

                    b.Property<double?>("Pressure")
                        .HasColumnType("float");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<double?>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Um_count_0_3")
                        .HasColumnType("float");

                    b.Property<double?>("Um_count_0_5")
                        .HasColumnType("float");

                    b.Property<double?>("Um_count_1_0")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("PurpleAirData");
                });

            modelBuilder.Entity("AirLab.Models.PurpleAirSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Altitude")
                        .HasColumnType("float");

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SensorId")
                        .IsUnique();

                    b.ToTable("PurpleAirSensors");
                });

            modelBuilder.Entity("AirLab.Models.PurpleAirData", b =>
                {
                    b.HasOne("AirLab.Models.PurpleAirSensor", "Sensor")
                        .WithMany("Data")
                        .HasForeignKey("SensorId")
                        .HasPrincipalKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("AirLab.Models.PurpleAirSensor", b =>
                {
                    b.Navigation("Data");
                });
#pragma warning restore 612, 618
        }
    }
}
