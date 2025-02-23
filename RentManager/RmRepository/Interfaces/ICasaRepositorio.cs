using RmModel.Entidades;

namespace RmRepository.Interfaces
{
    public interface ICasaRepositorio
    {
        IEnumerable<Casa> ObtenhaTodasAsCasas();
        Casa ObtenhaCasa(int id);
    }
}
