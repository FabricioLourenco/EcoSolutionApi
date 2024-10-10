using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }

        public FuncaoEnum Funcao { get; set; }

        public bool Ativo { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public List<ArquivoVinculado> ArquivosVinculados { get; set; }

        public Tarefa Tarefa { get; set; }

    }
}
