using EcoSolution.Domain.Enuns;
using EcoSolution.Domain.DTos.Base;

namespace EcoSolution.Domain.DTos
{
    public class ManualDTo
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public SetorEnum Setor { get; set; }

        public EquipamentoDTo? Equipamento { get; set; }   

        public MaterialDTo? Material { get; set; }

        public List<ArquivoVinculadoDTo>? ArquivosVinculados { get; set; }

    }
}
