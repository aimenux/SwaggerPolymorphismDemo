using Example01;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup();
startup.ConfigureServices(builder);
var app = builder.Build();
startup.Configure(app);
await app.RunAsync();
