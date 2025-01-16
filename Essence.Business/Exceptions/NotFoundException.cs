using Essence.Business.Abstractions.Exception;

namespace Essence.Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not Found") : base(message)
    {

    }
}
