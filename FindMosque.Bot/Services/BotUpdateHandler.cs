using FindMosque.Bot.Services;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FindMosque.Bot;

public partial class BotUpdateHandler : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandler> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private UserService _userService;
    private IStringLocalizer _localizer;

    public BotUpdateHandler(ILogger<BotUpdateHandler> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Bot has new error: {exception.Message}");
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();

        _userService = scope.ServiceProvider.GetRequiredService<UserService>();


        //if (update.Message == "/start")
        //{
        //    await HandlerForStart(botClient, update.Message, cancellationToken);
        //}
        var handler = update.Type switch
        {
            //UpdateType.Message msg when msg.Text == "/start" => HandlerForStart(botClient, msg, cancellationToken),

        };

    }
}
