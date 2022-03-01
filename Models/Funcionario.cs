namespace projeto_WebAPI.Models
{
    public class Funcionario
    {   
        public Funcionario() {}
        

        public Funcionario( int id, string nome, string rg,  string siglaDepartamento, int IDdepartamento )
        {
          this.Id = id;
          this.Nome = nome;
          this.Rg = rg;
          this.SiglaDepartamento = siglaDepartamento;
          this.IdDepartamento = IDdepartamento;

        }
        
      public int     Id                     { get; set; }  
      public string  Nome                   { get; set; } = default!;
      public string  Rg                     { get; set; } = default!;
      public string  SiglaDepartamento      { get; set; } = default!;
      public int     IdDepartamento         { get; set; }  
     
     
    }

}