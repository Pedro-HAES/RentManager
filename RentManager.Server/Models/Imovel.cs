using RentManager.Server.Enumeradores;

namespace RentManager.Server.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public EnumEstadoPropriedade Status { get; set; }
        public int LocadorId { get; set; }
        public Usuario Locador { get; set; }
    }
}
