using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FindMosque.Bot;

public partial class BotUpdateHandler
{
    private async Task HandlerForStart(ITelegramBotClient botClient,Message message, CancellationToken cancellationToken)
    {

        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                 new KeyboardButton[] { "O'zbek🇺🇿", "Русский🇷🇺" },
            })
        {
            ResizeKeyboard = true
        };

        var user = message.From;
        await botClient.SendTextMessageAsync
            (
            chatId: user.Id,
            text: $"start received from {user.FirstName}",
            replyToMessageId: message.MessageId,
            replyMarkup:replyKeyboardMarkup,
            cancellationToken: cancellationToken
            ) ;

    }
}

