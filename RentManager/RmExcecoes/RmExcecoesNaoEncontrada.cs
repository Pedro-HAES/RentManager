namespace RmExcecoes
{
    public class RmExcecoesNaoEncontrada : RmExcecoes
    {
        private readonly List<string> _erros;

        public RmExcecoesNaoEncontrada(List<string> mensagensDeErro)
        {
            _erros = mensagensDeErro;
        }

        public override List<string> ObtenhaMensagensDeErro() => _erros;
    }
}
