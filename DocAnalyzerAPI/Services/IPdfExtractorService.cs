namespace DocAnalyzerAPI.Services
{
    public interface IPdfExtractorService
    {
        /// <summary>
        /// Extrai o texto de um arquivo PDF e o divide em chunks.
        /// </summary>
        /// <param name="pdfPath">O caminho do arquivo PDF a ser processado.</param>
        /// <returns>Todo o conteúdo textual do PDF como uma única string.</returns>
        Task<string> ExtractTextAsync(string pdfPath);


    }
}
