using System.Net;

namespace Sinqia.Calculator.Application.Exceptions;

public abstract class ExceptionBase : SystemException
{
    protected ExceptionBase(string message) : base(message) { }

    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}
