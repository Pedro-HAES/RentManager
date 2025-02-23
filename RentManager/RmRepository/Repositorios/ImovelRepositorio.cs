using RmModel.Entidades;
using RmRepository.AcessoADados;
using RmRepository.Interfaces;

namespace RmRepository.Repositorios
{
    public class ImovelRepositorio : IImovelRepositorio
    {
        private readonly AppDbContext _context;

        public ImovelRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void AdicioneNovoImovel(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
        }

        public void AtualizeImovel(Imovel imovel)
        {
            _context.Imoveis.Update(imovel);
            _context.SaveChanges();
        }

        public void ExcluaImovel(int id)
        {
            Imovel? imovel = _context.Imoveis.Find(id);

            if (imovel != null)
            {
                _context.Imoveis.Remove(imovel);
                _context.SaveChanges();
            }
        }

        public Imovel ObtenhaImovel(int id)
        {
            Imovel? imovel = _context.Imoveis.Find(id);
            return imovel;
        }

        public IEnumerable<Imovel> ObtenhaTodosImoveis()
        {
            return [.. _context.Imoveis];
        }
    }
}
