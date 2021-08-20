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
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            var me = client.GetMeAsync().Result;
            client.OnMessage += OnMessageHandler;
            client.StartReceiving();


        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
                switch (msg.Text)
                {
                    case "еще":
                        await client.SendTextMessageAsync(
                       chatId: msg.Chat.Id,
                            text: "kek",
                            replyMarkup: GetButtons());
                        break;

                    case "Закончить":
                        await client.SendTextMessageAsync(
                            chatId: msg.Chat.Id,
                            text: "хочешь продолжить жми кнопку слева",
                            replyMarkup: GetButtons());
                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Я написал этого бота что бы он улучшал тебе настроение песенками", replyMarkup: GetButtons());
                        await client.SendStickerAsync(msg.Chat.Id, sticker: "https://tlgrm.ru/_/stickers/5a7/cb3/5a7cb3d0-bca6-3459-a3f0-5745d95d54b7/4.webp");
                        break;
                }
            }
        }
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "еще" }, new KeyboardButton { Text = "Закончить" } },
                },
                ResizeKeyboard = true
            };
        }
    }
}