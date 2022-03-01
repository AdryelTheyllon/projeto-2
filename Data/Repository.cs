using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto_WebAPI.Models;
using System.Collections.Generic;

namespace projeto_WebAPI.Data
{   
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    
        
        //Funcionario
        public async Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento = false)

        {
            IQueryable<Funcionario> query = _context.Funcionarios;

           

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id); 

            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeDepartamento)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            

            query = query.AsNoTracking()
                         .OrderBy(Funcionario => Funcionario.Id)
                         .Where(Funcionario => Funcionario.Id == FuncionarioId);

            return await query.FirstOrDefaultAsync();
        }
       
    
        
          public async Task<Escritorio[]> GetAllEscritoriosAsync(bool includeDepartamento = true)
        
         {
            IQueryable<Escritorio> query = _context.Escritorios;

            query = query.AsNoTracking()
                         .OrderBy(Escritorio => Escritorio.Id);
                         

            return await query.ToArrayAsync();  
        }
        
        public async Task<Escritorio> GetEscritorioAsyncById(int escritorioId, bool includeDepartamentos = true)
        {
            IQueryable<Escritorio> query = _context.Escritorios;

            

            query = query.AsNoTracking()
                         .OrderBy(escritorio => escritorio.Id)
                         .Where(escritorio =>escritorio.Id == escritorioId); 

            return await query.FirstOrDefaultAsync();
        }

        //Departamento
        public async Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario = false)

        {
            IQueryable<Departamento> query = _context.Departamentos;

            

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id); 

            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetDepartamentoAsyncById(int DepartamentoId, bool includeFuncionario)
        {
            IQueryable<Departamento> query = _context.Departamentos;

           

            query = query.AsNoTracking()
                         .OrderBy(Departamento => Departamento.Id)
                         .Where(Departamento => Departamento.Id == DepartamentoId);

            return await query.FirstOrDefaultAsync();
        }

    }
       
}  



        
       