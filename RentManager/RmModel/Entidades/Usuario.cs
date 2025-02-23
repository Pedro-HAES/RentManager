using System.ComponentModel.DataAnnotations;

namespace RmModel.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Length(7, 25)]
        public string SenhaHash { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }

        public List<Casa>? Casas { get; set; } = [];
    }
}
