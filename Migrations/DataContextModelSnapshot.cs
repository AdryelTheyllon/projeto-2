﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projeto_WebAPI.Data;

#nullable disable

namespace projeto_WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6");

            modelBuilder.Entity("projeto_WebAPI.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EscritorioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EscritorioId");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tecnologia da Informação",
                            Sigla = "TI"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Administração",
                            Sigla = "ADM"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Recursos Humanos",
                            Sigla = "RH"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Financeiro",
                            Sigla = "FN"
                        });
                });

            modelBuilder.Entity("projeto_WebAPI.Models.DepartamentoFuncionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FuncionarioId", "DepartamentoId");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("DepartamentosFuncionarios");

                    b.HasData(
                        new
                        {
                            FuncionarioId = 1,
                            DepartamentoId = 1
                        },
                        new
                        {
                            FuncionarioId = 4,
                            DepartamentoId = 4
                        },
                        new
                        {
                            FuncionarioId = 3,
                            DepartamentoId = 3
                        },
                        new
                        {
                            FuncionarioId = 5,
                            DepartamentoId = 1
                        },
                        new
                        {
                            FuncionarioId = 7,
                            DepartamentoId = 2
                        },
                        new
                        {
                            FuncionarioId = 6,
                            DepartamentoId = 3
                        });
                });

            modelBuilder.Entity("projeto_WebAPI.Models.Escritorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Escritorios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Regiao = "Oeste"
                        },
                        new
                        {
                            Id = 2,
                            Regiao = "Norte"
                        });
                });

            modelBuilder.Entity("projeto_WebAPI.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SiglaDepartamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdDepartamento = 1,
                            Nome = "Adryel",
                            Rg = "12346",
                            SiglaDepartamento = "TI"
                        },
                        new
                        {
                            Id = 2,
                            IdDepartamento = 2,
                            Nome = "Isabel",
                            Rg = "56783",
                            SiglaDepartamento = "ADM"
                        },
                        new
                        {
                            Id = 3,
                            IdDepartamento = 3,
                            Nome = "Dhara",
                            Rg = "91023",
                            SiglaDepartamento = "RH"
                        },
                        new
                        {
                            Id = 4,
                            IdDepartamento = 4,
                            Nome = "Taina",
                            Rg = "17109",
                            SiglaDepartamento = "FN"
                        },
                        new
                        {
                            Id = 5,
                            IdDepartamento = 1,
                            Nome = "Lucas",
                            Rg = "12876",
                            SiglaDepartamento = "TI"
                        },
                        new
                        {
                            Id = 6,
                            IdDepartamento = 3,
                            Nome = "Pedro",
                            Rg = "780674",
                            SiglaDepartamento = "RH"
                        },
                        new
                        {
                            Id = 7,
                            IdDepartamento = 2,
                            Nome = "Paulo",
                            Rg = "456743",
                            SiglaDepartamento = "ADM"
                        });
                });

            modelBuilder.Entity("projeto_WebAPI.Models.Departamento", b =>
                {
                    b.HasOne("projeto_WebAPI.Models.Escritorio", null)
                        .WithMany("Departamentos")
                        .HasForeignKey("EscritorioId");
                });

            modelBuilder.Entity("projeto_WebAPI.Models.DepartamentoFuncionario", b =>
                {
                    b.HasOne("projeto_WebAPI.Models.Departamento", "Departamento")
                        .WithMany("DepartamentosFuncionarios")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projeto_WebAPI.Models.Funcionario", "Funcionario")
                        .WithMany("DepartamentosFuncionarios")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("projeto_WebAPI.Models.Departamento", b =>
                {
                    b.Navigation("DepartamentosFuncionarios");
                });

            modelBuilder.Entity("projeto_WebAPI.Models.Escritorio", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("projeto_WebAPI.Models.Funcionario", b =>
                {
                    b.Navigation("DepartamentosFuncionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
