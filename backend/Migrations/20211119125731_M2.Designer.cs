﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace trip_it.Migrations
{
    [DbContext(typeof(TripITContext))]
    [Migration("20211119125731_M2")]
    partial class M2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Klijent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imeKlijenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kontaktTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezimeKlijenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("klijent");
                });

            modelBuilder.Entity("Models.Lokacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hotel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("lokacija");
                });

            modelBuilder.Entity("Models.Ponuda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("cena")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("lokacijaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("lokacijaID");

                    b.ToTable("ponuda");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("klijentID")
                        .HasColumnType("int");

                    b.Property<int?>("ponudaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("klijentID");

                    b.HasIndex("ponudaID");

                    b.ToTable("rezervacija");
                });

            modelBuilder.Entity("Models.Ponuda", b =>
                {
                    b.HasOne("Models.Lokacija", "lokacija")
                        .WithMany()
                        .HasForeignKey("lokacijaID");

                    b.Navigation("lokacija");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.HasOne("Models.Klijent", "klijent")
                        .WithMany()
                        .HasForeignKey("klijentID");

                    b.HasOne("Models.Ponuda", "ponuda")
                        .WithMany()
                        .HasForeignKey("ponudaID");

                    b.Navigation("klijent");

                    b.Navigation("ponuda");
                });
#pragma warning restore 612, 618
        }
    }
}
