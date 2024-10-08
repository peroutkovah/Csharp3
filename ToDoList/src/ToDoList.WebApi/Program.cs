var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Ahoj");
app.MapGet("/ahojsvete", () => "Ahoj svete");
app.MapGet("/nazdarsvete", () => "Nazdar světe");

app.Run();
