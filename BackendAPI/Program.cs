using BackendAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<EmployeeDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnectionString"))
//     );

builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EmployeeConnectionString"))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.MapControllers();

app.Run();


// docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MattMurdock@095' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest