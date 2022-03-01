namespace projeto_WebAPI.Models
{
    public class Departamento
    {
        public Departamento(){}


        public Departamento( int id, string nome, string Sigla )
        {
          this.Id = id;
          this.Nome = nome;
          this.Sigla = Sigla;
         
          

        }
        
      public int     Id       { get; set; }  
      public string  Nome     { get; set; } = default!;
      public string Sigla     { get; set; } = default!;
    
      
      
      
    }

}