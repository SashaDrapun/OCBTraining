namespace ExcelDataLoader.Services
{
    public interface IExcelService
    {
        Task<List<ClassData?>> ReadExcelFileAsync(Stream stream);
    }
}
