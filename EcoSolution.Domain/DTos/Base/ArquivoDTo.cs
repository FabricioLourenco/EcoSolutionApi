namespace EcoSolution.Domain.DTos.Base
{
    public class ArquivoDTo
    {
        public string NomeArquivo { get; set; }

        public string TipoArquivo { get; set; }

        public byte[] Dados { get; set; }
    }
}
