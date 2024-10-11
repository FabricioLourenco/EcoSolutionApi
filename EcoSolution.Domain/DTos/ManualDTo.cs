using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos
{
    public class ManualDTo
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public SetorEnum Setor { get; set; }

    }
}
