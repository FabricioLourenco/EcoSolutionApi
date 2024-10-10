using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities
{
    public class Equipamento : BaseEntity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string DadosColetados { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime Manutencao { get; set; }

        public Manual Manual { get; set; }

        public List<ArquivoVinculado> ArquivosVinculados { get; set; }

    }
}
