using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities
{
    public class Manual : BaseEntity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public SetorEnum Setor { get; set; }

        public long? EquipamentoId { get; set; }

        public Equipamento Equipamento { get; set; }

        public long? MaterialId { get; set; }

        public Material Material { get; set; }

        public List<ArquivoVinculado>? ArquivosVinculados { get; set; }


    }
}
