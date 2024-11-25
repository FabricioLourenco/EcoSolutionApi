using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.DTos.Base
{
    public class UpdateManualDTo
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public SetorEnum Setor { get; set; }

        public UpdateEquipamentoDTo? Equipamento { get; set; }

        public UpdateMaterialDTo? Material { get; set; }

        public List<UpdateArquivoVinculadoDTo>? ArquivosVinculados { get; set; }
    }
}
