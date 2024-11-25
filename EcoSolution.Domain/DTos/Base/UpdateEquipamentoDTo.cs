using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos.Base
{
    public class UpdateEquipamentoDTo
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string DadosColetados { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime Manutencao { get; set; }

        public ManualDTo? Manual { get; set; }

        public List<ArquivoVinculadoDTo>? ArquivosVinculados { get; set; }
    }
}
