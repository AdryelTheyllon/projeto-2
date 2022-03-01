using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  projeto_WebAPI.Data;
using  projeto_WebAPI.Models;

namespace projeto_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
     private readonly IRepository _repo;

     public FuncionarioController(IRepository repo)
    {
          _repo= repo; 
    }

   
   
    [ HttpGet ]
    public async Task<IActionResult> Get()
    {

     try
    {
        var result = await _repo.GetAllFuncionariosAsync(false);
        return Ok(result);
    }
    catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
          
       }

    }
      
       [ HttpGet("{FuncionarioId}") ]
    public async Task<IActionResult> GetByFuncionarioId( int FuncionarioId)
     {
     try
    {
        var result = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);
        return Ok(result);
    }
    catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
          
       }
        
        
    }

    
     [HttpPost ]
    
       public async Task<IActionResult> post(Funcionario model )
       {
         try
         {
            _repo.Add(model);
            if(await _repo.SaveChangesAsync())
            {
               return Ok(model);
            }
         }
         catch (Exception ex)
         {
            return BadRequest($"Erro: {ex.Message}");
         }
         return BadRequest( );
     } 

     [HttpPut("{funcionarioId}") ]
    
       public async Task<IActionResult> put(int funcionarioId, Funcionario model )
       {
         try
         {
            var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
            if(funcionario == null) return NotFound("Funcionario nao encontrado");

            _repo.Update(model);
            if(await _repo.SaveChangesAsync())
            {
               return Ok(model);
            }
         }
         catch (Exception ex)
         {
            return BadRequest($"Erro: {ex.Message}");
         }
         return BadRequest();
     } 

      [HttpDelete("{funcionarioId}") ]
    
       public async Task<IActionResult> delete(int funcionarioId  )
       {
         try
         {
            var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
            if(funcionario == null) return NotFound();

            _repo.Delete(funcionario);
            if(await _repo.SaveChangesAsync())
            {
               return Ok( new {message= "Deletado"});
            }
         }
         catch (Exception ex)
         {
            return BadRequest($"Erro: {ex.Message}");
         }
         return BadRequest();
     }
}




