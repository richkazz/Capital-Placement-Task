using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("log.txt")
        .CreateLogger();
    builder.Logging.AddSerilog(logger);

    Log.Logger = logger;
    Log.Information("Starting up...");


    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
