using RmModel.Entidades;
using RmRepository.AcessoADados;
using RmRepository.Interfaces;

namespace RmRepository.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly AppDbContext _context;

        public PagamentoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void AdicioneNovoPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void AtualizePagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Update(pagamento);
            _context.SaveChanges();
        }

        public void ExcluaPagamento(int id)
        {
            Pagamento? pagamento = _context.Pagamentos.Find(id);
            _context.Pagamentos.Remove(pagamento);
            _context.SaveChanges();
        }

        public Pagamento ObtenhaPagamento(int id)
        {
            return _context.Pagamentos.Find(id);
        }

        public IEnumerable<Pagamento> ObtenhaPagamentosPendente()
        {
           return [.. _context.Pagamentos.Where(pagamento => !pagamento.Pago)];
        }

        public IEnumerable<Pagamento> ObtenhaPagamentosPorContrato(int contratoId)
        {
            return _context.Pagamentos.Where(pagamentos => pagamentos.ContratoId == contratoId);
        }

        public IEnumerable<Pagamento> ObtenhaPagamentosPorData(DateTime? dataInicio = null, DateTime? dataFim = null)
        {
            var query = _context.Pagamentos.AsQueryable();

            if (dataInicio.HasValue)
            {
                query = query.Where(p => p.DataPagamento.Date >= dataInicio.Value.Date);
            }

            if (dataFim.HasValue)
            {
                query = query.Where(p => p.DataPagamento.Date <= dataFim.Value.Date);
            }

            return [.. query];
        }

        public IEnumerable<Pagamento> ObtenhaPagamentosRealizados()
        {
            var pagamentosRealizados = _context.Pagamentos.Where(pagamentos => pagamentos.Pago).ToList();
            return pagamentosRealizados;
        }

        public IEnumerable<Pagamento> ObtenhaTodosPagamentos()
        {
            List<Pagamento> pagamentos = _context.Pagamentos.ToList();
            return pagamentos;
        }
    }
}
