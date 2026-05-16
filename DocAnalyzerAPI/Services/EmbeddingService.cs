using OpenAI;
using OpenAI.Embeddings;

namespace DocAnalyzerAPI.Services;

public class EmbeddingService : IEmbeddingService
{
    private readonly EmbeddingClient _client;

    public EmbeddingService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"]
            ?? throw new InvalidOperationException("Chave da OpenAI não configurada.");

        var modelo = configuration["OpenAI:EmbeddingModel"] ?? "text-embedding-3-small";

        _client = new EmbeddingClient(modelo, apiKey);
    }

    public async Task<float[]> GerarEmbeddingAsync(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException("O texto para embedding não pode ser vazio.", nameof(texto));

        var resultado = await _client.GenerateEmbeddingAsync(texto);

        return resultado.Value.ToFloats().ToArray();
    }
}