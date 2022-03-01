namespace projeto_WebAPI.Models
{

    public class DepartamentoFuncionario
    {
        public DepartamentoFuncionario(){ }

        public DepartamentoFuncionario(int funcionarioId, int departamentoId)
        {
            this.FuncionarioId = funcionarioId;
            this.DepartamentoId = departamentoId;

        }
        
        public int FuncionarioId         { get; set; }
        public Funcionario Funcionario   { get; set; } = default!;
        public int DepartamentoId        { get; set; }
        public Departamento Departamento { get; set; } = default!;
      
        
    }
}