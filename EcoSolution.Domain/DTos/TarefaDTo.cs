using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSolution.Domain.DTos
{
    public class TarefaDTo
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime Horario { get; set; }

    }
}
