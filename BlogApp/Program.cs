using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//localhost://posts/web-programlama
app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/{url}",
    defaults: new {controller = "Posts", action = "Details"}
    );


//localhost://posts/tag/web-programlama
app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller = "Posts", action = "Index" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=posts}/{action=Index}/{id?}");

app.Run();
