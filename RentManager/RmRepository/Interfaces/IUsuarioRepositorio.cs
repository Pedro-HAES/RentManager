using RmModel.Entidades;

namespace RmRepository.Interfaces
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> ObtenhaTodosUsuarios();
        Usuario ObtenhaUsuario(int id);
        void AdicioneNovoUsuario(Usuario usuario);
        void AtualizeUsuario(Usuario usuario);
        void ExcluaUsuario(int id);
    }
}
