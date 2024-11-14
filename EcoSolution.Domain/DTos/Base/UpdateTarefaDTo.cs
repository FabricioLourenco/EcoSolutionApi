using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos.Base
{
    public class UpdateTarefaDTo
    {
        public long Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime Horario { get; set; }

        public bool Ativo { get; set; } = true;

        public EquipamentoDTo? Equipamento { get; set; }

        public MaterialDTo? Material { get; set; }

        public ManualDTo? Manual { get; set; }

        public List<ArquivoVinculadoDTo>? ArquivosVinculados { get; set; }
    }
}
