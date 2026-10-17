
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S1120359CoreMVClab1005;
using S1120359CoreMVClab1005.Models;

public class StudentController : Controller
{
    private readonly TourSurveyContext _context;

    public StudentController(TourSurveyContext context)
    {
        _context = context;
    }

    // GET: STUDENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Student.ToListAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? studentid)
    {
        if (studentid == null)
        {
            return NotFound();
        }

        var student = await _context.Student
            .FirstOrDefaultAsync(m => m.StudentId == studentid);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StudentId,Name,Email,Department,Spots")] Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    // GET: STUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? studentid)
    {
        if (studentid == null)
        {
            return NotFound();
        }

        var student = await _context.Student.FindAsync(studentid);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: STUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? studentid, [Bind("StudentId,Name,Email,Department,Spots")] Student student)
    {
        if (studentid != student.StudentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentId))
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
        return View(student);
    }

    // GET: STUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? studentid)
    {
        if (studentid == null)
        {
            return NotFound();
        }

        var student = await _context.Student
            .FirstOrDefaultAsync(m => m.StudentId == studentid);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: STUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? studentid)
    {
        var student = await _context.Student.FindAsync(studentid);
        if (student != null)
        {
            _context.Student.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? studentid)
    {
        return _context.Student.Any(e => e.StudentId == studentid);
    }
}
