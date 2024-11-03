using EcoSolution.Domain.Enuns;
using EcoSolution.Domain.DTos.Base;

namespace EcoSolution.Domain.DTos
{
    public class UsuarioDTo
    {
        public string Nome { get; set; }

        public FuncaoEnum Funcao { get; set; }

        public long EstacaoId { get; set; }

        public bool Ativo { get; set; } = true;

        public List<ArquivoVinculadoDTo>? ArquivosVinculados { get; set; }

        public TarefaDTo? Tarefa { get; set; }

    }
}
