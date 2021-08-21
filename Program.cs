using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBOTS
{
    class Program
    {
        private const string Token = "1960934916:AAHlVrPiEd8WQBQQtRkp04gVTIqo-2ohedo";
        private static TelegramBotClient _client;

        static void Main()
        {
            _client = new TelegramBotClient(Token);
            _client.OnMessage += OnMessageHandler;
            _client.StartReceiving();
            Console.ReadKey();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message.Text is null)
                return;

            Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");

            switch (message.Text)
            {
                case "еще":
                    await _client.SendTextMessageAsync(
                   message.Chat.Id,
                       "kek",
                        replyMarkup: GetButtons());
                    break;

                case "Закончить":
                    await _client.SendTextMessageAsync(
                      message.Chat.Id,
                       "хочешь продолжить жми кнопку слева",
                        replyMarkup: GetButtons());
                    break;

                default:
                    await _client.SendTextMessageAsync(message.Chat.Id, "Я написал этого бота что бы он улучшал тебе настроение песенками", replyMarkup: GetButtons());
                    await _client.SendStickerAsync(message.Chat.Id, sticker: "https://tlgrm.ru/_/stickers/5a7/cb3/5a7cb3d0-bca6-3459-a3f0-5745d95d54b7/4.webp");
                    break;
            }

        }

        private static IReplyMarkup GetButtons() =>
             new ReplyKeyboardMarkup
             {
                 Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "еще" }, new KeyboardButton { Text = "Закончить" } }
                },
                 ResizeKeyboard = true
             };
    }
}