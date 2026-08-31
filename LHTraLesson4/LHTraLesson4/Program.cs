var builder = WebApplication.CreateBuilder(args);

// Dang ky MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Xu ly loi khi khong o moi truong Development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS
app.UseHttpsRedirection();

// Su dung file tinh trong wwwroot
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Cau hinh route mac dinh
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();