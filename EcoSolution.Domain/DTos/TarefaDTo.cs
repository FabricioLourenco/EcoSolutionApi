using EcoSolution.Domain.Enuns;
using EcoSolution.Domain.DTos.Base;

namespace EcoSolution.Domain.DTos
{
    public class TarefaDTo
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime Horario { get; set; }

        public bool Ativo { get; set; } = true;

        public EquipamentoDTo? Equipamento { get; set; }

        public MaterialDTo? Material { get; set; }

        public ManualDTo? Manual { get; set; }

        public List<ArquivoVinculadoDTo?> ArquivosVinculados { get; set; }

    }
}
