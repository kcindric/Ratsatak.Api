using System.Net;

namespace Ratsatak.Application.Common.Errors;

public class RecordDoesNotExistException : Exception, IApplicationException
{
    public RecordDoesNotExistException(string detail)
    {
        Detail = detail;
    }

    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string Title => "Record not found";
    public string Detail { get; }
}