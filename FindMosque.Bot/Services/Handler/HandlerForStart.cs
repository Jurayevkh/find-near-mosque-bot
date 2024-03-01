using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FindMosque.Bot;

public partial class BotUpdateHandler
{
    private async Task HandlerForStart(ITelegramBotClient botClient,Message message, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "1.1", callbackData: "11"),
                InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
                InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
            },
        });
        //ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        //    {
        //         new KeyboardButton[] { "O'zbek", "Rus" },
        //    })
        //{
        //    ResizeKeyboard = true
        //};

        var user = message.From;
        await botClient.SendTextMessageAsync
            (
            chatId: user.Id,
            text: $"start received from {user.FirstName}",
            replyToMessageId: message.MessageId,
            replyMarkup:inlineKeyboard,
            cancellationToken: cancellationToken
            ) ;

    }
}

