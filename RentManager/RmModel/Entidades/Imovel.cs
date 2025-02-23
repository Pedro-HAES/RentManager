using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RmModel.Entidades
{
    public abstract class Imovel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Endereco { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ValorAluguel { get; set; }

        [Required]
        public bool Disponivel { get; set; }

        [Required]
        public int LocatarioId { get; set; }

        [ForeignKey("LocatarioId")]
        public Usuario Locatario { get; set; }

        public Contrato? ContratoAtivo { get; set; }
    }
}
