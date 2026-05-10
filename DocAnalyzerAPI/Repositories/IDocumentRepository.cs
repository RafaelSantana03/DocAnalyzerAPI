using DocAnalyzerAPI.Models;
namespace DocAnalyzerAPI.Repositories;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid Id);
    Task<IEnumerable<Document>> GetAllAsync(int page, int pageSize);
    Task AddAsync(Document document);
    Task UpdateAsync(Document document);
    Task DeleteAsync(Document document);
}
