namespace EcoSolution.Domain.DTos.Base
{
    public class UpdateArquivoDTo
    {
        public long Id { get; set; }
        public string NomeArquivo { get; set; }

        public string TipoArquivo { get; set; }

        public byte[] Dados { get; set; }
    }
}
