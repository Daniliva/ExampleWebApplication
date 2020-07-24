using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLayer;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      /*  private EFDBContext _context;
        private IDirectorysRepository _dirRep;*/
        private DataManager _dataManager;
        public HomeController(ILogger<HomeController> logger,/* EFDBContext context, IDirectorysRepository dirRep, */DataManager dataManager)
        {
            _logger = logger;
           /* _context = context;
            _dirRep = dirRep;*/
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            HelloModel _model = new HelloModel() { HelloMessage = "I see you!" };
            //  List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
            //List<Directory> _dirs = _dirRep.GetAllDirectorys().ToList();
            List<Directory> _dirs = _dataManager.Directorys.GetAllDirectorys(true).ToList();
            return View(_dirs);
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
    }
}
