using Microsoft.EntityFrameworkCore;
using WebApiHotel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbAlianzaRegionalContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"))); //usasr la cadena de coneccion
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//**** Una forma de abrir el swagger
/* app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/swagger/indext.html", permanent: false);
});*/

//***** La mejor forma de abrir el swagger

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
