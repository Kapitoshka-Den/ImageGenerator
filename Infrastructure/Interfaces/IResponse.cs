using System.Net;

namespace Infrastructure.Interfaces;

public interface IResponse
{
    public HttpStatusCode? StatusCode { get; }
    
    public string? ErrorMessage { get; }

    public bool IsSuccessStatusCode => StatusCode.HasValue && (int)StatusCode >= 200 && (int)StatusCode <= 299;
}

public interface IResponse<out T> : IResponse
{
    public T Data { get; }
}