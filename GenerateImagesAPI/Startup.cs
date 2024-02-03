using System.Globalization;
using GenerateImagesAPI.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenerateImagesAPI;

public static class Startup
{
    public const string ApiGenerationImage = "textToImage";

    
    public static IHttpClientBuilder AddGeneratorHttpClient(this IServiceCollection services, IConfiguration configuration) =>
        services.AddHttpClient<IGeneratorImagesManager, GeneratorImagesManager>(client =>
        {
            client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
            client.BaseAddress = new Uri(configuration[ApiGenerationImage] ?? throw new Exception("Incorrect API url"));
        });
}