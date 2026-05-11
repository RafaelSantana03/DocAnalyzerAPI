namespace DocAnalyzerAPI.DTOs.Responses;

public class AnswerResponse
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public List<string> SourceChunks { get; set; } = new(); // Lista dos trechos do PDF que o RAG utiiza
    public DateTime GeneratedAt { get; set; }
}