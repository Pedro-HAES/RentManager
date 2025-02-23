using RmModel.Entidades;
using RmRepository.AcessoADados;
using RmRepository.Interfaces;

namespace RmRepository.Repositorios
{
    public class CasaRepositorio : ICasaRepositorio
    {

        private readonly AppDbContext _context;

        public CasaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public Casa ObtenhaCasa(int id)
        {
           return _context.Casas.Find(id);
        }

        public IEnumerable<Casa> ObtenhaTodasAsCasas()
        {
            return _context.Casas.ToList();
        }
    }
}
