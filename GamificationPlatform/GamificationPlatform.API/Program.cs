using GamificationPlatform.Core.Context;
using GamificationPlatform.Core.Repositories;
using GamificationPlatform.Infrastructure.Dtos;
using GamificationPlatform.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MainPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MainPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
