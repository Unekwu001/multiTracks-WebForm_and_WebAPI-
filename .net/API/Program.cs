using API.Repositories.Artist;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>(provider => new ArtistRepository("Data source=localhost;DATABASE=MultiTracksDB;Integrated Security=True"));

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//	options.JsonSerializerOptions.MaxDepth = 64; // or a higher value
//												 // Other serialization options
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
