using System.Text.Json;
using Infrastructure.Interfaces;
using Infrastructure.Wrappers;

namespace Infrastructure.Extensions;

public static class ResponseExtensions
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static async Task<IResponse<T>> ToResponseAsync<T>(this HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken = default)
    {
        var responseString =
            await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var response = JsonSerializer.Deserialize<T>(responseString) ?? default!;
        return await Response<T>.SuccessAsync(httpResponseMessage.StatusCode, response);
    }
}