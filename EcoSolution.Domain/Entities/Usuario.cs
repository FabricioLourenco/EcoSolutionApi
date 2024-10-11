using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }

        public FuncaoEnum Funcao { get; set; }

        public long EstacaoId { get; set; }

        public string ChaveSecreta { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public List<ArquivoVinculado> ArquivosVinculados { get; set; }

        public Tarefa Tarefa { get; set; }

    }
}
