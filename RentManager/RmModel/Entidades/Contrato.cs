using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RmModel.Entidades
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ImovelId { get; set; }

        [ForeignKey("ImovelId")]
        public Imovel Imovel { get; set; }

        [Required]
        public int InquilinoId { get; set; }

        [ForeignKey("InquilinoId")]
        public Usuario Inquilino { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ValorTotal { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public List<Pagamento> Pagamentos { get; set; } = [];
    }
}
