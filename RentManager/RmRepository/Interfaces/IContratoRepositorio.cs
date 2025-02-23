using RmModel.Entidades;

namespace RmRepository.Interfaces
{
    public interface IContratoRepositorio
    {
        IEnumerable<Contrato> ObtenhaTodosOsContratos();
        Contrato ObtenhaContrato(int id);
        void AdicioneNovoContrato(Contrato contrato);
        void AtualizeContrato(Contrato contrato);
        void ExcluaContrato(int id);
        IEnumerable<Contrato> ObtenhaContratosPorImovel(int imovelId);
        IEnumerable<Contrato> ObtenhaContratosPorInquilino(int inquilinoId);
        IEnumerable<Contrato> ObtenhaContratosAtivos();
        IEnumerable<Contrato> ObtenhaContratosInativos();
    }
}
