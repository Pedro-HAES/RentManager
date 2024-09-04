using RentManager.Server.Enumeradores;

namespace RentManager.Server.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnumTipoUsuario Tipo { get; set; }
    }
}
