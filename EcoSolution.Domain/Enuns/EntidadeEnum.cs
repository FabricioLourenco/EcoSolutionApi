using System.ComponentModel.DataAnnotations;

namespace EcoSolution.Domain.Enuns
{
    public enum EntidadeEnum
    {
        [Display(Name = "Usuario")]
        Usuario = 1,

        [Display(Name = "Tarefa")]
        Tarefa = 2,

        [Display(Name = "Material")]
        Material = 3,

        [Display(Name = "Equipamento")]
        Equipamento = 4,

        [Display(Name = "Manual")]
        Manual = 5
    }
}
