using OfficeOpenXml;

namespace ExcelDataLoader.Services
{
    public class ExcelService : IExcelService
    {
        public async Task<List<ClassData>> ReadExcelFileAsync(Stream stream)
        {
            var classDataList = new List<ClassData>();
            using (var package = new ExcelPackage(stream))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 9; row <= worksheet.Dimension.Rows; row++)
                {
                    var classCode = worksheet.Cells[row, 1].Text;
                    if (string.IsNullOrEmpty(classCode)) continue;

                    var classData = new ClassData
                    {
                        ClassCode = classCode,
                        InitialActive = worksheet.Cells[row, 2].Text,
                        InitialPassive = worksheet.Cells[row, 3].Text,
                        Debit = worksheet.Cells[row, 4].Text,
                        Credit = worksheet.Cells[row, 5].Text,
                        FinalActive = worksheet.Cells[row, 6].Text,
                        FinalPassive = worksheet.Cells[row, 7].Text
                    };

                    classDataList.Add(classData);
                }
            }

            return classDataList;
        }
    }

    public class ClassData
    {
        public string? ClassCode { get; set; }
        public string? InitialActive { get; set; }
        public string? InitialPassive { get; set; }
        public string? Debit { get; set; }
        public string? Credit { get; set; }
        public string? FinalActive { get; set; }
        public string? FinalPassive { get; set; }
    }
}
