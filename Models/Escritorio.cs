namespace projeto_WebAPI.Models
{
    public class Escritorio
    {   
        public Escritorio() {}
        

        public Escritorio( int id, string regiao )
        {
          this.Id = id;
          
          this.Regiao = regiao;
          

        }
        
      public int     Id                     { get; set; }  
      public string  Regiao                 { get; set; } = default!;
     
      
     
    }

}