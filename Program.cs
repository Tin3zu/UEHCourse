using Microsoft.EntityFrameworkCore;
using UEHCourse.Models;
using UEHCourse.Repository;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ vào container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("UEHCourseContext");
builder.Services.AddDbContext<UEHCourseContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IFieldRepository, FieldRepository>();

// Thêm dịch vụ phiên vào container.
builder.Services.AddSession(options =>
{
    // Cấu hình tùy chọn phiên ở đây nếu cần
});

var app = builder.Build();

// Cấu hình pipeline yêu cầu HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Giá trị mặc định HSTS là 30 ngày. Bạn có thể muốn thay đổi điều này cho các kịch bản sản xuất, xem https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Thêm middleware phiên vào ứng dụng
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
