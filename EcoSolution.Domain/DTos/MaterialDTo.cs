using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos
{
    public class MaterialDTo
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public long Quantidade { get; set; }

        public UnidadeMedidaEnum UnidadeMedida { get; set; }

        public SetorEnum Setor { get; set; }

    }
}
