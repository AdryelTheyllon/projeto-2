using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  projeto_WebAPI.Data;
using  projeto_WebAPI.Models;

namespace projeto_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EscritorioController : ControllerBase
{
    
    private readonly IRepository _repo;

    public EscritorioController(IRepository repo)
    {
        _repo = repo;
    }
    
    [ HttpGet ]
    public async Task<IActionResult> Get()
     {
       try
            {
                var result = await _repo.GetAllEscritoriosAsync(false);
                return Ok(result) ;
            }
       catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
          
       } 
       
     } 

     
    
     [ HttpGet("{EscritorioId}") ]
    public async Task<IActionResult> GetByEscritorioId(int EscritorioId)
     {
       try
            {
                var result = await _repo.GetEscritorioAsyncById(EscritorioId, false);
                return Ok(result) ;
            }
       catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
          
       }
       
     }

   

     [HttpPost]

     public async Task<IActionResult> post(Escritorio model)
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


     
     [HttpPut("{EscritorioId}")]

     public async Task<IActionResult> put(int EscritorioId, Escritorio model)
     {
         try
         {
             var Escritorio = await _repo.GetEscritorioAsyncById(EscritorioId, false);
             if(Escritorio == null) return NotFound("Escritorio nao encontrado");

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

     [HttpDelete("{EscritorioId}")]

     public async Task<IActionResult> delete(int EscritorioId)
     {
       try
       {
          var Escritorio = await _repo.GetEscritorioAsyncById(EscritorioId, false);
          if(Escritorio == null) return NotFound();

          _repo.Delete(Escritorio);
          if(await _repo.SaveChangesAsync())
          {
            return Ok( new{message = "Deletado" } );
          }
       }
       catch (Exception ex)
         {
            return BadRequest($"Erro: {ex.Message}");
         }
         return BadRequest();
     }
}
