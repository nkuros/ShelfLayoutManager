using System.Text.Json.Serialization;
using ShelfLayoutManager.Services;
using ShelfLayoutManager.Context;
using ShelfLayoutManager.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;
    services.AddDbContext<ShelfContext>();


    services.AddCors();
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // ignore omitted parameters on models to enable optional params (e.g. User update)
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddScoped<ICabinetService, CabinetService>();
    services.AddScoped<IRowService, RowService>();
    services.AddScoped<ILaneService, LaneService>();

}


var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}


app.Run("http://localhost:4000");