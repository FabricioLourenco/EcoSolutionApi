using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Enuns;

namespace EcoSolution.Domain.Entities
{
    public class Tarefa : BaseEntity
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public SetorEnum Setor { get; set; }

        public DateTime Horario { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataInsercao { get; set; } = DateTime.Now;

        public long UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public long? EquipamentoId { get; set; }

        public Equipamento Equipamento {  get; set; } 
        
        public long? MaterialId { get; set; }

        public Material Material { get; set; }

        public long? ManualId {  get; set; }

        public Manual Manual { get; set; }

        public List<ArquivoVinculado> ArquivosVinculados { get; set; }

    }
}
