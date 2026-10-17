using Microsoft.EntityFrameworkCore;

public class TourSurveyContext(DbContextOptions<TourSurveyContext> options) : DbContext(options)
{
    public DbSet<S1120359CoreMVClab1005.Models.Student> Student { get; set; } = default!;

    public DbSet<S1120359CoreMVClab1005.Models.Spot> Spot { get; set; } = default!;

    public DbSet<S1120359CoreMVClab1005.Models.Food> Food { get; set; } = default!;
}

