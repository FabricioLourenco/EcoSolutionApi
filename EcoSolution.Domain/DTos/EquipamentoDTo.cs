using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos
{
    public class EquipamentoDTo
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string DadosColetados { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime Manutencao { get; set; }
    }
}
