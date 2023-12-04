using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NotesDbContext>(options =>
        options.UseSqlite("Data Source=notesdb.db"));

builder.Services.AddCors(options =>
{
options.AddPolicy(name: "_myOrigins",
              policy =>
              {
                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
              });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_myOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
