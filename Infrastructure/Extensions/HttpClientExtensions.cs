using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.Interfaces;

namespace Infrastructure.Extensions;

public static class HttpClientExtensions
{
    private static readonly JsonSerializerOptions _jsonSerializeOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
        IncludeFields = true,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never
    };

    public static Task<IResponse<TK>> CreateEntityAsync<T, TK>(this HttpClient httpClient, string query, T entity, CancellationToken cancellationToken = default) =>
        httpClient.SendRequestAsync<TK>(query, HttpMethod.Post, entity, cancellationToken);
    

    public static async Task<IResponse<T>> SendRequestAsync<T>(this HttpClient httpClient, string query, HttpMethod method, object? content = null, CancellationToken cancellationToken = default)
    {
        try
        {
            using HttpRequestMessage requestMessage = new();
            requestMessage.Content = JsonContent.Create(content, options: _jsonSerializeOptions);
            requestMessage.Method = method;
            requestMessage.RequestUri = new Uri(query, UriKind.RelativeOrAbsolute);
            using HttpResponseMessage responseMessage =
                await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            return await responseMessage.ToResponseAsync<T>(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[API][ERROR] {e}");
            throw;
        }
        
    }
}