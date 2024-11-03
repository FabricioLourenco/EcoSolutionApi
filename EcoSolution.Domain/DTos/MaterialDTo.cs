using EcoSolution.Domain.Enuns;
using EcoSolution.Domain.DTos.Base;

namespace EcoSolution.Domain.DTos
{
    public class MaterialDTo
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public long Quantidade { get; set; }

        public UnidadeMedidaEnum UnidadeMedida { get; set; }

        public SetorEnum Setor { get; set; }

        public ManualDTo? Manual { get; set; }

        public List<ArquivoVinculadoDTo>? ArquivosVinculados { get; set; }

    }
}
