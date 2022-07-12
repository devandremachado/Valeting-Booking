namespace Valeting.Shared.CustomException
{
    public class DomainException : Exception
    {
        public DomainException(string mensagem) : base(mensagem)
        { }
    }
}
