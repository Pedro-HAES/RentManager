namespace RentManager.Server.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
    }
}
