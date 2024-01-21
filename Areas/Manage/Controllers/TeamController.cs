using Lumia.Areas.Manage.ViewModels;
using Lumia.DAL;
using Lumia.Helpers;
using Lumia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lumia.Areas.Manage.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public TeamController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var fruits=_context.Teams.ToList();
            return View(fruits);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateTeamVm vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            Team team = new Team()
            {
                FullName = vm.FullName,
                Word = vm.Word,
                Description = vm.Description
            };
            team.ImgUrl = vm.File.Upload ( _environment.WebRootPath, @"/Upload/");
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Team team = await _context.Teams.FindAsync(id);
            UpdateTeamVm teamVm = new UpdateTeamVm()
            {
                Id = team.Id,
                FullName = team.FullName,
                Word = team.Word,
                Description = team.Description
            };
            return View(teamVm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateTeamVm teamVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Team oldTeam=await _context.Teams.FirstOrDefaultAsync(c=>c.Id==teamVm.Id);
            oldTeam.FullName=teamVm.FullName;
            oldTeam.Word=teamVm.Word;
            oldTeam.Description=teamVm.Description;
            if (oldTeam.ImgUrl != null)
            {
                oldTeam.ImgUrl.Delete(_environment.WebRootPath, @"/Upload/");
                oldTeam.ImgUrl = teamVm.File.Upload(_environment.WebRootPath, @"/Upload/");
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
           
        

        public async Task<IActionResult> Delete(int id)
        {
            Team oldTeam =  _context.Teams.FirstOrDefault(c => c.Id == id);
            _context.Teams.Remove(oldTeam);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
