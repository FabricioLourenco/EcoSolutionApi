namespace EcoSolution.Domain.Entities.Base
{
    public class Arquivo : BaseEntity
    {
        public string NomeArquivo { get; set; } 

        public string TipoArquivo { get; set; } 

        public byte[] Dados { get; set; } 

        public DateTime DataUpload { get; set; } = DateTime.Now;

    }
}
