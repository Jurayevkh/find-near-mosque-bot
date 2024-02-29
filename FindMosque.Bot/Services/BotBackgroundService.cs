
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace FindMosque.Bot.Services;

public class BotBackgroundService : BackgroundService
{
    private readonly ILogger<BackgroundService> _logger;
    private readonly TelegramBotClient _client;
    private readonly IUpdateHandler _updateHandler;

    public BotBackgroundService(ILogger<BackgroundService> logger, TelegramBotClient client, IUpdateHandler updateHandler)
    {
        _logger = logger;
        _client = client;
        _updateHandler = updateHandler;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await _client.GetMeAsync(stoppingToken);
        _logger.LogInformation($"Bot succesfully started : {bot.Username}");

        _client.StartReceiving(
            _updateHandler.HandleUpdateAsync,
            _updateHandler.HandlePollingErrorAsync,
            new ReceiverOptions() {ThrowPendingUpdates=true}, stoppingToken);
    }
}
