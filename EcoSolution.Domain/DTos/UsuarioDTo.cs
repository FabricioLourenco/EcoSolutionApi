using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos
{
    public class UsuarioDTo
    {
        public string Nome { get; set; }

        public FuncaoEnum Funcao { get; set; }

        public long EstacaoId { get; set; }

        public bool Ativo { get; set; } = true;


    }
}
