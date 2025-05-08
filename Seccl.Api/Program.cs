using Seccl.Api.Services;
using Seccl.Middleware;
using Seccl.Middleware.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddHttpClient<SecclAuthService>();
builder.Services.AddHttpClient<PortfolioService>();
builder.Services.AddScoped<PortfolioAggregator>();

var app = builder.Build();
app.UseCors();

app.MapGet("/api/portfolio/total", async (PortfolioService pService, PortfolioAggregator aggregator) =>
{
    var balances = await pService.GetPortfolioDataAsync();
    var total = aggregator.AggregateTotal(balances);
    return Results.Ok(total);
});

app.MapGet("/api/portfolio/by-type", async (PortfolioService pService, PortfolioAggregator aggregator) =>
{
    var balances = await pService.GetPortfolioDataAsync();
    var grouped = aggregator.AggregateByAccountType(balances);
    return Results.Ok(grouped);
});

app.Run();
