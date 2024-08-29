using ExcelDataLoader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExcelDataLoader.Controllers
{
    public class FilesController : Controller
    {
        private readonly AppDbContext _context;

        public FilesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var files = _context.UploadedFiles.ToList();
            return View(files);
        }

        public IActionResult ViewFileData(int id)
        {
            var file = _context.UploadedFiles
            .Include(f => f.Classes)
                .ThenInclude(c => c.Accounts)
                    .ThenInclude(a => a.Balances)
            .Include(f => f.Classes)
                .ThenInclude(c => c.Accounts)
                    .ThenInclude(a => a.Turnovers)
            .Include(f => f.Classes)
                .ThenInclude(c => c.ClassTotals)
            .FirstOrDefault(f => f.Id == id);

            if (file == null)
            {
                return NotFound();
            }

            return View(file);
        }
    }
}
