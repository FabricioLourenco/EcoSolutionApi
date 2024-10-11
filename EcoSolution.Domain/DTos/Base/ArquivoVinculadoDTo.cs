using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos.Base
{
    public class ArquivoVinculadoDTo
    {
        public long ArquivoId { get; set; }

        public long EntidadeId { get; set; }

        public ArquivoDTo Arquivo { get; set; }

        public EntidadeEnum Entidade { get; set; }
    }
}
