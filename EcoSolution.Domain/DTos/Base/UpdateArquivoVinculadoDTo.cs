using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos.Base
{
    public class UpdateArquivoVinculadoDTo
    {
        public long Id { get; set; }

        public long ArquivoId { get; set; }

        public long EntidadeId { get; set; }

        public UpdateArquivoDTo Arquivo { get; set; }

        public EntidadeEnum Entidade { get; set; }
    }
}
