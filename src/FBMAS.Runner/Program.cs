using FBMAS.Business;
using FBMAS.Business.UseCase;
using runner;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddServices();
builder.Services.AddTransient<IScrapeFacebookMarketplace, ScrapeFacebookMarketplace>();
builder.Services.AddHostedService<Worker>();
var host = builder.Build();
host.Run();
