using GenerateImagesAPI.Models;
using Infrastructure.Interfaces;

namespace GenerateImagesAPI.Managers;

public interface IGeneratorImagesManager
{
    /// <summary>
    /// Генерация изображения
    /// </summary>
    /// <param name="generateImageRequest">Сущность запроса картинки</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    public Task<IResponse<GenerateImage>> GenerateImage(GenerateImageRequest generateImageRequest,
        CancellationToken cancellationToken = default);

}