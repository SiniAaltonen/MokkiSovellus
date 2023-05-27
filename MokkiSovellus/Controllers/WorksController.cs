using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using MokkiSovellus.Models;
using MokkiSovellus.Services;

namespace MokkiSovellus.Controllers
{
    public class WorksController : Controller
    {
        private readonly IWorkService _workService;

        public WorksController(IWorkService workService)
        {
            _workService = workService;
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
            var works = await _workService.GetWorks();
            return View(works);
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _workService.GetWorkById(id.Value);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            ViewData["SeasonId"] = new SelectList(_workService.GetSeasons(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkName,WhenDuration,Equipment,SeasonId,WorkStatus")] Work work)
        {
            if (ModelState.IsValid)
            {
                await _workService.CreateWork(work);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeasonId"] = new SelectList(_workService.GetSeasons(), "Id", "Id", work.SeasonId);
            return View(work);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _workService.GetWorkById(id.Value);
            if (work == null)
            {
                return NotFound();
            }
            ViewData["SeasonId"] = new SelectList(_workService.GetSeasons(), "Id", "Id", work.SeasonId);
            return View(work);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkName,WhenDuration,Equipment,SeasonId,WorkStatus")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _workService.UpdateWork(work);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeasonId"] = new SelectList(_workService.GetSeasons(), "Id", "Id", work.SeasonId);
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _workService.GetWorkById(id.Value);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _workService.DeleteWork(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
