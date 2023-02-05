using Project.Infrastructure.Utilities.DependencyResolvers;
using Project.Infrastructure.Utilities.Extensions;
using Project.Service.Utilities.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCoreDependencies();
builder.Services.AddProjectDependencies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyOrigin();
    c.AllowAnyMethod();
});

app.Seed();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
