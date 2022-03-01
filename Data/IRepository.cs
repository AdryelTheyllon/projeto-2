using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto_WebAPI.Models;
using System.Collections.Generic;

namespace projeto_WebAPI.Data
{   
    public interface IRepository
    {
       //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Funcionario
        Task<Funcionario[]> GetAllFuncionariosAsync(bool includeEscritorio);        
       
        Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeEscritorio);
        
       //Escritorio
        Task<Escritorio[]> GetAllEscritoriosAsync(bool includeFuncionario);
        Task<Escritorio> GetEscritorioAsyncById(int EscritorioId, bool includeFuncionario);
      

        //Departamento
         Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario);
         Task<Departamento> GetDepartamentoAsyncById(int DepartamentoId, bool includeFuncionario);
        
    }
    
}

 
       

        
    

     