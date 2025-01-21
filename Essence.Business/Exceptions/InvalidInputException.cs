using Essence.Business.Abstractions.Exception;
using System.Net;

namespace Essence.Business.Exceptions;

public class InvalidInputException : Exception, IBaseException
{
    public InvalidInputException(string message) : base(message)
    {

    }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

}