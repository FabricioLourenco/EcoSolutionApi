using System.ComponentModel.DataAnnotations;

namespace EcoSolution.Domain.Enuns
{
    public enum FuncaoEnum
    {
        [Display(Name = "Administrador")]
        Administrador = 1,

        [Display(Name = "Analista")]
        Analista = 2,

        [Display(Name = "Operador")]
        Operador = 3
    }
}
