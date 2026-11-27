using MvcSession01.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductStore>();

var app = builder.Build();
app.Use(async (context, next) =>
{
    Console.WriteLine($"A before: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"A after : {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("B before");

    if (context.Request.Path == "/blocked")
    {
        await context.Response.WriteAsync("Blocked by middleware B (short-circuit).");
        return;   
    }

    await next();
    Console.WriteLine("B after");
});

app.Map("/ping", branch =>
{
    branch.Run(async context =>
    {
        await context.Response.WriteAsync("pong");
    });
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    Console.WriteLine($"Before: {context.Request.Path}");
    await next();                     
    Console.WriteLine($"After: {context.Response.StatusCode}");
});


app.Map("/demo", branch =>
{
    branch.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("1-Use ");
        await next();
    });

    branch.Run(async context =>         
    {
        await context.Response.WriteAsync("2-Run ");
    });

    branch.Use(async (context, next) => 
    {
        await context.Response.WriteAsync("3-Never ");
        await next();
    });
});

app.UseRouting();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "shop",
    pattern: "shop/{id:int}",
    defaults: new { controller = "Products", action = "Details" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
