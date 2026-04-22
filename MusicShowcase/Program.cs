using MusicShowcase.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MusicGeneratorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || true) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();