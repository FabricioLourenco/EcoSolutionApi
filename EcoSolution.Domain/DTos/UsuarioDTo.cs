using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos
{
    public class UsuarioDTo
    {
        public string Nome { get; set; }

        public FuncaoEnum Funcao { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

    }
}
