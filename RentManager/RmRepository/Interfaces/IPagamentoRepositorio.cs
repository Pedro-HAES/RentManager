using RmModel.Entidades;

namespace RmRepository.Interfaces
{
    public interface IPagamentoRepositorio
    {
        IEnumerable<Pagamento> ObtenhaTodosPagamentos();
        Pagamento ObtenhaPagamento(int id);
        void AdicioneNovoPagamento(Pagamento pagamento);
        void AtualizePagamento(Pagamento pagamento);
        void ExcluaPagamento(int id);
        IEnumerable<Pagamento> ObtenhaPagamentosPorContrato(int contratoId);
        IEnumerable<Pagamento> ObtenhaPagamentosPorData(DateTime? dataInicio = null, DateTime? dataFim = null);
        IEnumerable<Pagamento> ObtenhaPagamentosPendente();
        IEnumerable<Pagamento> ObtenhaPagamentosRealizados();
    }
}
