using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

//https://telegrambots.github.io/book/2/send-msg/text-msg.html
namespace Telegram_Bot_CSharp
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("TOKEN");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            Thread.Sleep(3000);
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            botClient.StopReceiving();
        }
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Message message = await botClient.SendTextMessageAsync(
              chatId: e.Message.Chat, // or a chat id: 123456789
              text: "Trying *all the parameters* of `sendMessage` method",
              parseMode: ParseMode.Markdown,
              disableNotification: true,
              replyToMessageId: e.Message.MessageId,
              replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                "Check sendMessage method",
                "https://core.telegram.org/bots/api#sendmessage"
              ))
            );
            Console.WriteLine(
            $"{message.From.FirstName} sent message {message.MessageId} " +
            $"to chat {message.Chat.Id} at {message.Date}. " +
            $"It is a reply to message {message.ReplyToMessage.MessageId} " +
            $"and has {message.Entities.Length} message entities."
            );
        }
    }
}
