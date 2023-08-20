using System.Net;

namespace Ratsatak.Application.Common.Errors;

public class RecordAlreadyExistsException : Exception, IApplicationException
{
    public RecordAlreadyExistsException(string detail)
    {
        Detail = detail;
    }

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string Title => "Record already exists";
    public string Detail { get; }
}