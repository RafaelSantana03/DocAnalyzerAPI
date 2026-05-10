using DocAnalyzerAPI.Models;
using DocAnalyzerAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace DocAnalyzerAPI.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly AppDbContext _context;

    public DocumentRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Document?> GetByIdAsync(Guid Id) // "Document?" Retorna null se não existir
    {
        return await _context.Documents.FirstOrDefaultAsync(d => d.Id == Id);
    }

    public async Task<IEnumerable<Document>> GetAllAsync(int page, int pageSize) 
    {
        return await _context.Documents.OrderByDescending(d => d.CreateAt) // OrderByDescending garante que os mais recentes sejam retornados primeiro
            .Skip((page - 1) * pageSize) // skip pula os registros das paginas anteriores, (page - 1) * pageSize calcula quantos registros pular    
            .Take(pageSize) // take pega apenas os registros da pagina atual, limitando a quantidade de registros retornados para o valor de pageSize
            .ToListAsync(); // converte o resultado para uma lista assíncrona
    }

    public async Task AddAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Document document)
    {
        _context.Documents.Update(document);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Document document)
    {
        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();
    }
}
