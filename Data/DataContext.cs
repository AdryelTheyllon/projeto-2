using Microsoft.EntityFrameworkCore;
using projeto_WebAPI.Models ;
using System.Collections.Generic;
using projeto_WebAPI.Data;

namespace projeto_WebAPI.Data
{


    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Funcionario> Funcionarios  { get; set; } = default!;
        public DbSet<Escritorio> Escritorios { get; set; } = default!; 
        public DbSet<Departamento> Departamentos { get; set; } = default!;
        public DbSet<DepartamentoFuncionario> DepartamentosFuncionarios { get; set; } = default!;

         protected override void OnModelCreating(ModelBuilder builder)
         {
              builder.Entity<DepartamentoFuncionario>()
                .HasKey(AD => new { AD.FuncionarioId, AD.DepartamentoId });
                   
                 
                 
                    builder.Entity<Escritorio>()
                .HasData(new List<Escritorio>(){
                    new Escritorio(1, "Oeste"),
                    new Escritorio(2, "Norte"),
                   
                    
                });
                    builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Tecnologia da Informação","TI" ),
                    new Departamento(2, "Administração","ADM" ),
                    new Departamento(3, "Recursos Humanos","RH" ),
                    new Departamento(4, "Financeiro","FN" ),
                    
                });

                builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>(){
                    // id , nome , rg, sigla, id departamento  
                    new Funcionario(1, "Adryel", "12346" ,  "TI", 1 ),
                    new Funcionario(2, "Isabel", "56783" , "ADM", 2 ),
                    new Funcionario(3, "Dhara",  "91023" ,  "RH", 3 ),
                    new Funcionario(4, "Taina",  "17109" , "FN" , 4 ), 
                    new Funcionario(5, "Lucas",  "12876" ,  "TI", 1 ),
                    new Funcionario(6, "Pedro",  "780674",  "RH", 3 ),
                    new Funcionario(7, "Paulo",  "456743", "ADM", 2 )
                    
                });

                            builder.Entity<DepartamentoFuncionario>()
                .HasData(new List<DepartamentoFuncionario>() {
                    new DepartamentoFuncionario() {FuncionarioId = 1, DepartamentoId = 1 },
                    new DepartamentoFuncionario() {FuncionarioId = 4, DepartamentoId = 4 },
                    new DepartamentoFuncionario() {FuncionarioId = 3, DepartamentoId = 3 },
                    new DepartamentoFuncionario() {FuncionarioId = 5, DepartamentoId = 1 },
                    new DepartamentoFuncionario() {FuncionarioId = 7, DepartamentoId = 2 },
                    new DepartamentoFuncionario() {FuncionarioId = 6, DepartamentoId = 3 }
                });

         }
    }
}