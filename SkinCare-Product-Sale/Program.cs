using Business_Layer.Services.AccountServices;
using Business_Layer.Services.CategoryServices;
using Business_Layer.Services.FeedbackServices;
using Business_Layer.Services.ImagesServices;
using Business_Layer.Services.NewsServices;
using Business_Layer.Services.OrderServices;
using Business_Layer.Services.PaymentServices;
using Business_Layer.Services.ProductServices;
using Data_Access_Layer.DBContext;
using Data_Access_Layer.Repositories.CategoryRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SkincareManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SkinCareContext"));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;  
    options.Cookie.IsEssential = true; 
});

//Services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
