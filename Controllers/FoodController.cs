using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S1120359CoreMVClab1005.Models;

public class FoodController : Controller
{
    private readonly TourSurveyContext _context;

    public FoodController(TourSurveyContext context)
    {
        _context = context;
    }

    // GET: Food
    public async Task<IActionResult> Index()
    {
        return View(await _context.Food.ToListAsync());
    }

    // GET: Food/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var food = await _context.Food
            .FirstOrDefaultAsync(m => m.FoodId == id);

        if (food == null)
        {
            return NotFound();
        }

        return View(food);
    }

    // GET: Food/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Food/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("FoodId,Name,Category,Restaurant,Location,Price,Rating,Description")] Food food)
    {
        if (ModelState.IsValid)
        {
            _context.Add(food);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(food);
    }

    // GET: Food/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var food = await _context.Food.FindAsync(id);

        if (food == null)
        {
            return NotFound();
        }

        return View(food);
    }

    // POST: Food/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("FoodId,Name,Category,Restaurant,Location,Price,Rating,Description")] Food food)
    {
        if (id != food.FoodId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(food);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(food.FoodId))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(food);
    }

    // GET: Food/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var food = await _context.Food
            .FirstOrDefaultAsync(m => m.FoodId == id);

        if (food == null)
        {
            return NotFound();
        }

        return View(food);
    }

    // POST: Food/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var food = await _context.Food.FindAsync(id);

        if (food != null)
        {
            _context.Food.Remove(food);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool FoodExists(int id)
    {
        return _context.Food.Any(e => e.FoodId == id);
    }
}