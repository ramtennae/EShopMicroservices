WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// deps
WebApplication app = builder.Build();

// middleware


app.Run();
