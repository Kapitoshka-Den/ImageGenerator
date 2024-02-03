using System.Net;
using Infrastructure.Interfaces;

namespace Infrastructure.Wrappers;

public class Response : IResponse
{
    public Response(HttpStatusCode? statusCode, string? errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public HttpStatusCode? StatusCode { get; }
    public string? ErrorMessage { get; }
    
    #region Ошибка
    public static IResponse Fail(HttpStatusCode? statusCode, string? message = null)
        => new Response(statusCode, message);

    public static Task<IResponse> FailAsync(HttpStatusCode? statusCode, string? message = null)
        => Task.FromResult(Fail(statusCode, message));
    #endregion

    #region Успех
    public static IResponse Success(HttpStatusCode? statusCode, string? message = null)
        => new Response(statusCode, message);

    public static Task<IResponse> SuccessAsync(HttpStatusCode? statusCode, string? message = null)
        => Task.FromResult(Success(statusCode, message));
    #endregion
}

public class Response<T> : Response, IResponse<T>
{
    public Response(HttpStatusCode? statusCode, string? errorMessage = null) : base(statusCode, errorMessage){}
    public Response(T data,HttpStatusCode? statusCode, string? errorMessage = null) : base(statusCode, errorMessage)
    {
        Data = data;
    }

    public T Data { get; } = default!;

    #region Ошибка
    public new static Response<T> Fail(HttpStatusCode? statusCode, string? message = null)
        => new(statusCode, message);

    public new static Task<Response<T>> FailAsync(HttpStatusCode? statusCode, string? message = null)
        => Task.FromResult(Fail(statusCode, message));
    #endregion

    #region Успех
    public static Response<T> Success(HttpStatusCode? statusCode, T data)
        => new(data, statusCode);

    public  static Task<Response<T>> SuccessAsync(HttpStatusCode? statusCode, T data)
        => Task.FromResult(Success(statusCode, data));
    #endregion
}