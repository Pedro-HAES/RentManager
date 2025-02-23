using RmModel.Entidades;
using RmRepository.AcessoADados;
using RmRepository.Interfaces;

namespace RmRepository.Repositorios
{
    public class ContratoRepositorio : IContratoRepositorio
    {
        private readonly AppDbContext _context;

        public ContratoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void AdicioneNovoContrato(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            _context.SaveChanges();
        }

        public void AtualizeContrato(Contrato contrato)
        {
            _context.Contratos.Update(contrato);
            _context.SaveChanges();
        }

        public void ExcluaContrato(int id)
        {
            Contrato? contrato = _context.Contratos.Find(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
                _context.SaveChanges();
            }
        }

        public Contrato ObtenhaContrato(int id)
        {
            Contrato? contrato = _context.Contratos.Find(id);
            return contrato;
        }

        public IEnumerable<Contrato> ObtenhaContratosAtivos()
        {
            List<Contrato> contratosAtivos = [.. _context.Contratos.Where(c => c.Ativo)];
            return contratosAtivos;
        }

        public IEnumerable<Contrato> ObtenhaContratosInativos()
        {
            List<Contrato> contratosInativos = [.. _context.Contratos.Where(c => !c.Ativo)];
            return contratosInativos;
        }

        public IEnumerable<Contrato> ObtenhaContratosPorImovel(int imovelId)
        {
            return [.. _context.Contratos.Where(c => c.ImovelId == imovelId)];
        }

        public IEnumerable<Contrato> ObtenhaContratosPorInquilino(int inquilinoId)
        {
            return [.. _context.Contratos.Where(contrato => contrato.InquilinoId == inquilinoId)];
        }

        public IEnumerable<Contrato> ObtenhaTodosOsContratos()
        {
            var todosOsContratos = _context.Contratos.ToList();
            return todosOsContratos;
        }
    }
}
