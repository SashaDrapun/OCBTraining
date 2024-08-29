using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelDataLoader.Models;
using Microsoft.EntityFrameworkCore;
using ExcelDataLoader.Services;

public class UploadController : Controller
{
    private readonly AppDbContext _context;

    public UploadController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file, [FromServices] IExcelService excelService, [FromServices] IDatabaseService databaseService)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is not selected or empty.");
        }

        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            stream.Position = 0;

            try
            {
                var classDataList = await excelService.ReadExcelFileAsync(stream);

                if (classDataList != null)
                {
                    var uploadedFile = new UploadedFile
                    {
                        FileName = file.FileName,
                        UploadDate = DateTime.Now
                    };
                    databaseService.SaveUploadedFile(uploadedFile);

                    databaseService.SaveClassData(classDataList.Where(c => c != null).ToList(), uploadedFile.Id);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing the file: " + ex.Message);
            }
        }

        return RedirectToAction("Index");
    }


}