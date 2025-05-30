using Carter;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter(new DependencyContextAssemblyCatalog(assemblies: typeof(Program).Assembly));
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// deps
WebApplication app = builder.Build();

// http request pipeline
app.MapCarter();


app.Run();
