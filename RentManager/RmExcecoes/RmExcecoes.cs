namespace RmExcecoes
{
    public abstract class RmExcecoes : SystemException
    {
        public abstract List<string> ObtenhaMensagensDeErro();
    }
}
