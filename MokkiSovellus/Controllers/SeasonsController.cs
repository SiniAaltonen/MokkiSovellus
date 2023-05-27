using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MokkiSovellus.Models;
using MokkiSovellus.Services;

namespace MokkiSovellus.Controllers
{
    public class SeasonsController : Controller
    {
        private readonly ISeasonService _seasonService;

        public SeasonsController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        // GET: Seasons
        public async Task<IActionResult> Index()
        {
            var seasons = await _seasonService.GetAllSeasons();
            return View(seasons);
        }

        // GET: Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _seasonService.GetSeasonById(id.Value);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: Seasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Season season)
        {
            if (ModelState.IsValid)
            {
                await _seasonService.CreateSeason(season);
                return RedirectToAction(nameof(Index));
            }

            return View(season);
        }

        // GET: Seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _seasonService.GetSeasonById(id.Value);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Seasons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Season season)
        {
            if (id != season.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _seasonService.UpdateSeason(season);
                return RedirectToAction(nameof(Index));
            }

            return View(season);
        }

        // GET: Seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _seasonService.GetSeasonById(id.Value);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _seasonService.DeleteSeason(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

