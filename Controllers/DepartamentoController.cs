using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  projeto_WebAPI.Data;
using  projeto_WebAPI.Models;

namespace projeto_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartamentoController : ControllerBase
{
    
    private readonly IRepository _repo;

    public DepartamentoController(IRepository repo)
    {
        _repo = repo;
    }
    
    [ HttpGet ]
    public async Task<IActionResult> Get()
     {
       try
            {
                var result = await _repo.GetAllDepartamentosAsync(false);
                return Ok(result) ;
            }
       catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
          
       } 
       
     }

         [ HttpGet("{DepartamentoId}") ]
    public async Task<IActionResult> GetByDepartamentoId(int DepartamentoId)
     {
       try
            {
                var result = await _repo.GetDepartamentoAsyncById(DepartamentoId, false);
                return Ok(result) ;
            }
       catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
          
       }
       
     }

        [HttpPost]

     public async Task<IActionResult> post(Departamento model)
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
       return BadRequest();
     }

    [HttpPut("{DepartamentoId}")]

     public async Task<IActionResult> put(int DepartamentoId, Departamento model)
     {
         try
         {
             var Departamento = await _repo.GetDepartamentoAsyncById(DepartamentoId, false);
             if(Departamento == null) return NotFound("Departamento nao encontrado");

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

     [HttpDelete("{DepartamentoId}")]

     public async Task<IActionResult> delete(int DepartamentoId)
     {
       try
       {
          var Departamento = await _repo.GetDepartamentoAsyncById(DepartamentoId, false);
          if(Departamento == null) return NotFound();

          _repo.Delete(Departamento);
          if(await _repo.SaveChangesAsync())
          {
            return Ok( new {message ="Deletado"});
          }
       }
       catch (Exception ex)
         {
            return BadRequest($"Erro: {ex.Message}");
         }
         return BadRequest();
     }
}     