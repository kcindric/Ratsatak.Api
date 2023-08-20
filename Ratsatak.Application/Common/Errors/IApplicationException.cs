using System.Net;

namespace Ratsatak.Application.Common.Errors;

public interface IApplicationException
{
    public HttpStatusCode StatusCode { get; }
    public string Title { get; }
    public string Detail { get; }
}