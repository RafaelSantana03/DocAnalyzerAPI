namespace DocAnalyzerAPI.Models;

public class Document
{
    public Guid Id { get; set; } // Id gerado como guid no servidor (não auto incremental)
    public string FileName { get; set; } = string.Empty; // Nome unico gerado internamente
    public string OriginalName { get; set; } = string.Empty; // Nome original do arquivo enviado pelo usuario
    public long FileSizeBytes { get; set; } // pra mostrar pro usuário e validar no futuro
    public int TotalChunks { get; set; } // útil para saber se o processamento gerou algo
    public DocumentStatus Status { get; set; } // Controla em qual etapa do processamento o documento está
    public DateTime CreateAt { get; set; }
    public DateTime? ProcessedAt { get; set; } // é null até o documento estar com status = ready

    public enum DocumentStatus
    {
        Pending,
        Processing,
        Ready,
        Failed
    } 
}
