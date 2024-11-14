using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities
{
    public class Material : BaseEntity
    {
        public string Nome {  get; set; }

        public string Descricao { get; set; }

        public long Quantidade { get; set; }

        public UnidadeMedidaEnum UnidadeMedida { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public Manual? Manual { get; set; }

        public List<ArquivoVinculado>? ArquivosVinculados { get; set; }

    }
}
