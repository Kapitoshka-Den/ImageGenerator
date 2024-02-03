using GenerateImagesAPI.Models;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;

namespace GenerateImagesAPI.Managers;

public class GeneratorImagesManager : IGeneratorImagesManager
{
    private readonly HttpClient _httpClient;

    public GeneratorImagesManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public Task<IResponse<GenerateImage>> GenerateImage(GenerateImageRequest generateImageRequest,
        CancellationToken cancellationToken = default) =>
        _httpClient.CreateEntityAsync<GenerateImageRequest, GenerateImage>(GenerateImagesEndpoints.GetGenerateImage,
            generateImageRequest, cancellationToken);
}