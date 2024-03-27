using System.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin());

app.MapGet("/podcasts", async () =>
{
    var db = new SqlConnection("Server=localhost,1433;Database=Podcasts;User Id=sa;Password=Robert#123;MultipleActiveResultSets=true;TrustServerCertificate=true");
    
    return (await db.QueryAsync<Podcast>("SELECT * FROM Podcasts")).Select(x => x.title);
});

app.Run();

record Podcast (Guid id, string title);

