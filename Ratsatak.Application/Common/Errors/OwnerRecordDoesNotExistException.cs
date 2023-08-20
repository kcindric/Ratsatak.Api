using System.Net;

namespace Ratsatak.Application.Common.Errors;

public class OwnerRecordDoesNotExistException : Exception, IApplicationException
{
    public OwnerRecordDoesNotExistException(string detail)
    {
        Detail = detail;
    }

    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string Title => "Owner record not found";
    public string Detail { get; }
}