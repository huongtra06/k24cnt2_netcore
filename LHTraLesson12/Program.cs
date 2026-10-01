using LHTraLesson12.AppDBContext;
using LHTraLesson12.Models;
using Microsoft.EntityFrameworkCore;

namespace LHTraLesson12
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("AppConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var categoryNames = new[] { "Quần áo", "Túi xách", "Giày dép", "Phụ kiện", "Váy đầm", "Áo khoác" };
                var existing = await db.Categories.Select(c => c.Name).ToListAsync();
                var missing = categoryNames.Where(name => !existing.Contains(name, StringComparer.OrdinalIgnoreCase))
                    .Select(name => new Category { Name = name, Status = 1, CreateDate = DateTime.Now });
                if (missing.Any())
                {
                    db.Categories.AddRange(missing);
                    await db.SaveChangesAsync();
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            await app.RunAsync();
        }
    }
}
