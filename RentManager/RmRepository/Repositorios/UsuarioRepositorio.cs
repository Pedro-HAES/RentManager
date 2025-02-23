using RmModel.Entidades;
using RmRepository.AcessoADados;
using RmRepository.Interfaces;

namespace RmRepository.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void AdicioneNovoUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void AtualizeUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void ExcluaUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Usuario> ObtenhaTodosUsuarios()
        {
            return [.. _context.Usuarios];
        }

        public Usuario ObtenhaUsuario(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id) ?? throw new ArgumentException("teste");

            return usuario;
        }
    }
}
