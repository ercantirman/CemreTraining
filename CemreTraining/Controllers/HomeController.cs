using CemreTraining.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CemreTraining.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new List<LicenseInfoDto>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<string> Search(string term)
        {
            var carList = new List<string> { "34 DNM 34", "34 ERC 34", "34 CEMRE 34" };

            var filteredCarList = !string.IsNullOrEmpty(term) ? carList.Where(p => p.ToLower().Contains(term.ToLower())).ToList() : carList;

            return filteredCarList;
        }

        [HttpPost]
        public ResultDto<LicenseInfoDto> GetTableData(LicenseFilterDto filter)
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            //Burada datayı dbden filtreleyip alacak şekilde oluşturduğun kodu çağırıp o datayı dönmen gerekiyor
            #region Değiştirmen gereken kısım
            var licenseInfos = new List<LicenseInfoDto>();

            for (var i = 0; i < 100; i++)
            {
                var licenseInfo = new LicenseInfoDto
                {
                    Id = i + 1,
                    Info1 = $"{i + 1} * Info1",
                    Info2 = $"{i + 1} * Info2",
                    Info3 = $"{i + 1} * Info3",
                    Info4 = $"{i + 1} * Info4",
                    Info5 = $"{i + 1} * Info5"
                };
                licenseInfos.Add(licenseInfo);
            }
            #endregion

            int recordsTotal = licenseInfos.Count();
            var data = licenseInfos.Skip(skip).Take(pageSize).ToList();
            var result = new ResultDto<LicenseInfoDto> { Draw = draw, RecordsFiltered = recordsTotal, RecordsTotal = recordsTotal, Data = data };
            return result;
        }
    }
}