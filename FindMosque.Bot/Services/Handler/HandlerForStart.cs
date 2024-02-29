using Telegram.Bot;
using Telegram.Bot.Types;

namespace FindMosque.Bot;

public partial class BotUpdateHandler
{
    private async Task HandlerForStart(ITelegramBotClient botClient,Message message, CancellationToken cancellationToken)
    {
        var user = message.From;
        await botClient.SendTextMessageAsync
            (
            chatId: user.Id,
            text: $"start received from {user.FirstName}",
            replyToMessageId: message.MessageId,
            cancellationToken: cancellationToken
            );

    }
}

