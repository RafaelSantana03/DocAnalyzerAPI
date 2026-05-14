using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using System.Text;

namespace DocAnalyzerAPI.Services;

public class PdfExtractorService : IPdfExtractorService 
{
    public async Task<string> ExtractTextAsync(string pdfPath) 
    {
        if (!File.Exists(pdfPath)) // Lança uma exceção se o arquivo não existir
            throw new FileNotFoundException("Arquivo PDF não encontrado.", pdfPath);

        var sb = new StringBuilder(); // StringBuilder para acumular o texto extraído

        using var documento = PdfDocument.Open(pdfPath);

        foreach (Page pagina in documento.GetPages()) 
        {
           var palavras = pagina.GetWords(); // obtém as palavras da página 
           var textoDaPagina = string.Join(" ", palavras.Select(p => p.Text)); // junta as palavras em uma string
           sb.AppendLine(textoDaPagina); // adiciona o texto da página ao StringBuilder
        }

        var textoCompleto = sb.ToString().Trim(); // converte o StringBuilder para string e remove espaços em branco extras

        if(string.IsNullOrWhiteSpace(textoCompleto)) // se o texto extraído for vazio ou contiver apenas espaços em branco, lança uma exceção
            throw new InvalidDataException("O PDF não contém texto extraível. Pode ser um PDF de imagem escaneada");
    
        return textoCompleto; // Corrigido: retorna a string diretamente
    }
}
