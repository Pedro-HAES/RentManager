using RmModel.Entidades;

namespace RmRepository.Interfaces
{
    public interface IImovelRepositorio
    {
        IEnumerable<Imovel> ObtenhaTodosImoveis();
        Imovel ObtenhaImovel(int id);
        void AdicioneNovoImovel(Imovel imovel);
        void AtualizeImovel(Imovel imovel);
        void ExcluaImovel(int id);
    }
}
