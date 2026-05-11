namespace DocAnalyzerAPI.DTOs.Responses;

public class DocumentResponse
{
    public Guid Id { get; set; }
    public string OriginalName { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
    public int TotalChunks { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}