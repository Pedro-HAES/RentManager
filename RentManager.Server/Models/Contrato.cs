namespace RentManager.Server.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int PropriedadeId { get; set; }
        public Imovel Propriedade { get; set; }
        public int InquilinoId { get; set; }
        public Usuario Inquilino { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorMensal { get; set; }
    }
}
