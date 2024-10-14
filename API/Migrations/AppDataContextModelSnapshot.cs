﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("API.Models.Origem", b =>
                {
                    b.Property<int>("IdOrigem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPlanta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pais")
                        .HasColumnType("TEXT");

                    b.HasKey("IdOrigem");

                    b.ToTable("Origens");
                });

            modelBuilder.Entity("API.Models.Planta", b =>
                {
                    b.Property<int>("IdPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdOrigem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrigemIdOrigem")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPlanta");

                    b.HasIndex("OrigemIdOrigem");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("API.Models.Planta", b =>
                {
                    b.HasOne("API.Models.Origem", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemIdOrigem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Origem");
                });
#pragma warning restore 612, 618
        }
    }
}
