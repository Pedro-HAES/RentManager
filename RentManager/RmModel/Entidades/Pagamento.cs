using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RmModel.Entidades
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ContratoId { get; set; }

        [ForeignKey("ContratoId")]
        public Contrato Contrato { get; set; }

        [Required]
        public DateTime DataPagamento { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ValorPago { get; set; }

        [Required]
        public bool Pago { get; set; }

        public StatusPagamento StatusPagamento { get; set; }
    }
}
