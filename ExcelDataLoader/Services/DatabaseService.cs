using ExcelDataLoader.Models;

namespace ExcelDataLoader.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly AppDbContext _context;

        public DatabaseService(AppDbContext context)
        {
            _context = context;
        }

        public void SaveUploadedFile(UploadedFile uploadedFile)
        {
            _context.UploadedFiles.Add(uploadedFile);
            _context.SaveChanges();
        }

        public void SaveClassData(List<ClassData> classDataList, int uploadedFileId)
        {
            int classId = 0;

            foreach (var classData in classDataList)
            {

                if (classData.ClassCode.Contains("КЛАСС") && !classData.ClassCode.Contains("ПО КЛАССУ"))
                {
                    var newClass = new Class
                    {
                        ClassName = classData.ClassCode,
                        UploadedFileId = uploadedFileId
                    };
                    _context.Classes.Add(newClass);
                    _context.SaveChanges();
                    classId = newClass.ClassId;
                }
                else
                {
                    if (string.IsNullOrEmpty(classData.InitialActive) ||
                        string.IsNullOrEmpty(classData.InitialPassive) ||
                        string.IsNullOrEmpty(classData.Debit) ||
                        string.IsNullOrEmpty(classData.Credit) ||
                        string.IsNullOrEmpty(classData.FinalActive) ||
                        string.IsNullOrEmpty(classData.FinalPassive))
                    {
                        continue;
                    }

                    var initialActive = decimal.Parse(classData.InitialActive);
                    var initialPassive = decimal.Parse(classData.InitialPassive);
                    var debit = decimal.Parse(classData.Debit);
                    var credit = decimal.Parse(classData.Credit);
                    var finalActive = decimal.Parse(classData.FinalActive);
                    var finalPassive = decimal.Parse(classData.FinalPassive);

                    if (classData.ClassCode.Contains("ПО КЛАССУ"))
                    {
                        var classTotal = new ClassTotal
                        {
                            InitialActive = initialActive,
                            InitialPassive = initialPassive,
                            TurnoverDebit = debit,
                            TurnoverCredit = credit,
                            FinalActive = finalActive,
                            FinalPassive = finalPassive,
                            ClassId = classId
                        };
                        _context.ClassTotals.Add(classTotal);
                    }
                    else
                    {
                        var account = new Account { AccountCode = classData.ClassCode, ClassId = classId };
                        _context.Accounts.Add(account);
                        _context.SaveChanges();

                        var balance = new Balance
                        {
                            AccountId = account.AccountId,
                            InitialActive = initialActive,
                            InitialPassive = initialPassive,
                            FinalActive = finalActive,
                            FinalPassive = finalPassive
                        };
                        _context.Balances.Add(balance);

                        var turnover = new Turnover
                        {
                            AccountId = account.AccountId,
                            Debit = debit,
                            Credit = credit
                        };
                        _context.Turnovers.Add(turnover);
                    }

                    _context.SaveChanges();
                }
            }
        }
    }
}
