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

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrigemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TipoId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPlanta");

                    b.HasIndex("OrigemId");

                    b.HasIndex("TipoId");

                    b.HasIndex("TipoId1");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("API.modelos.Tipo", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("TipoId");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("API.Models.Planta", b =>
                {
                    b.HasOne("API.Models.Origem", "Origem")
                        .WithMany("Plantas")
                        .HasForeignKey("OrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.modelos.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("API.modelos.Tipo", null)
                        .WithMany("Plantas")
                        .HasForeignKey("TipoId1");

                    b.Navigation("Origem");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("API.Models.Origem", b =>
                {
                    b.Navigation("Plantas");
                });

            modelBuilder.Entity("API.modelos.Tipo", b =>
                {
                    b.Navigation("Plantas");
                });
#pragma warning restore 612, 618
        }
    }
}
