namespace DocAnalyzerAPI.Services;

public interface IEmbeddingService
{
    /// <summary>
    /// Gera um embedding vetorial para o texto informado.
    /// </summary>
    /// <param name="texto">Texto a ser convertido em vetor.</param>
    /// <returns>Array de floats representando o embedding.</returns>
    Task<float[]> GerarEmbeddingAsync(string texto);
}
