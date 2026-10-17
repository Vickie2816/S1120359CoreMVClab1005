
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S1120359CoreMVClab1005.Models;

public class SpotController : Controller
{
    private readonly TourSurveyContext _context;

    public SpotController(TourSurveyContext context)
    {
        _context = context;
    }

    // GET: SPOTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Spot.ToListAsync());
    }

    private IActionResult View(object value)
    {
        throw new NotImplementedException();
    }

    // GET: SPOTS/Details/5
    public async Task<IActionResult> Details(int? spotid)
    {
        if (spotid == null)
        {
            return NotFound();
        }

        var spot = await _context.Spot
            .FirstOrDefaultAsync(m => m.SpotId == spotid);
        if (spot == null)
        {
            return NotFound();
        }

        return View(spot);
    }

    // GET: SPOTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SPOTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SpotId,Name,Description,Location,CreatedAt,RecommenderId,Recommender")] Spot spot)
    {
        if (ModelState.IsValid)
        {
            _context.Add(spot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(spot);
    }

    // GET: SPOTS/Edit/5
    public async Task<IActionResult> Edit(int? spotid)
    {
        if (spotid == null)
        {
            return NotFound();
        }

        var spot = await _context.Spot.FindAsync(spotid);
        if (spot == null)
        {
            return NotFound();
        }
        return View(spot);
    }

    // POST: SPOTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? spotid, [Bind("SpotId,Name,Description,Location,CreatedAt,RecommenderId,Recommender")] Spot spot)
    {
        if (spotid != spot.SpotId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(spot);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotExists(spot.SpotId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(spot);
    }

    // GET: SPOTS/Delete/5
    public async Task<IActionResult> Delete(int? spotid)
    {
        if (spotid == null)
        {
            return NotFound();
        }

        var spot = await _context.Spot
            .FirstOrDefaultAsync(m => m.SpotId == spotid);
        if (spot == null)
        {
            return NotFound();
        }

        return View(spot);
    }

    // POST: SPOTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? spotid)
    {
        var spot = await _context.Spot.FindAsync(spotid);
        if (spot != null)
        {
            _context.Spot.Remove(spot);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SpotExists(int? spotid)
    {
        return _context.Spot.Any(e => e.SpotId == spotid);
    }
}
