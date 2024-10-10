using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities.Base
{
    public class ArquivoVinculado : BaseEntity
    {
        public long ArquivoId { get; set; }  

        public long EntidadeId { get; set; }

        public Arquivo Arquivo { get; set; }

        public EntidadeEnum Entidade { get; set; }  
        
    }
}
