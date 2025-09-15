namespace Worker.Services.Interfaces
{
    public interface ICsvService
    {
        Task GenerateCsv(string csvFilePath);
    }
}
