using System.Text.Json.Serialization;
using ShelfLayoutManager.Services;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
