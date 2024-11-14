using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos.Base
{
    public class UpdateMaterialDTo
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public long Quantidade { get; set; }

        public UnidadeMedidaEnum UnidadeMedida { get; set; }

        public SetorEnum Setor { get; set; }

        public ManualDTo? Manual { get; set; }

        public List<ArquivoVinculadoDTo>? ArquivosVinculados { get; set; }
    }
}
