using Microsoft.EntityFrameworkCore;
using WebAPIDatingAPP.DATA;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();


var app = builder.Build();


app.UseCors(builder => builder.AllowAnyHeader().AllowAnyHeader().WithOrigins("https://localhost:7185"));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
