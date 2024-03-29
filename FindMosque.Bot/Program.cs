using FindMosque.Bot;
using FindMosque.Bot.Data;
using FindMosque.Bot.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;

//var builder = WebApplication.CreateBuilder(args);

//var token = builder.Configuration.GetValue("BotToken", string.Empty);

//builder.Services.AddSingleton(p => new TelegramBotClient(token!));
//builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
//builder.Services.AddHostedService<BotBackgroundService>();


//var app = builder.Build();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BotDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var token = builder.Configuration.GetValue("BotToken", string.Empty);

builder.Services.AddSingleton(p => new TelegramBotClient(token!));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.AddHostedService<BotBackgroundService>();

builder.Services.AddScoped<UserService>();

builder.Services.AddLocalization();

var app = builder.Build();

var supportedCultures = new[] { "uz-Uz", "en-US", "ru-Ru" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[1])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);


app.Run();
