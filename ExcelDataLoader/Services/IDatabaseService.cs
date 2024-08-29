using ExcelDataLoader.Models;

namespace ExcelDataLoader.Services
{
    public interface IDatabaseService
    {
        void SaveUploadedFile(UploadedFile uploadedFile);
        void SaveClassData(List<ClassData> classDataList, int uploadedFileId);
    }
}
