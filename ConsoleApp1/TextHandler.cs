using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp1
{
    class TextHandler : Handler
    {
        public override string Name => "Text";

        readonly MessageStorage MessageStorage = new MessageStorage();

        public async override void HandelMessaga(Message message, ITelegramBotClient botClient)
        {
            if(IsRegistered(message)==false)
            {
                var msgId = message.MessageId;
               

                var keyboard = new InlineKeyboardMarkup(new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("\U00002705 Save ",$"{Name}~{msgId}~true"),
                    InlineKeyboardButton.WithCallbackData("\U0000274C Cancel ",$"{Name}~{msgId}~false")
                });
                
                await botClient.SendTextMessageAsync(message.From.Id, AppSettings.Phrases.Question, replyMarkup: keyboard);
            }
            else 
            {
                await botClient.SendTextMessageAsync(message.From.Id, "You are not registered");
            }

        }

        public async override void HandleCallBackQuery(CallbackQuery callbackQuery, ITelegramBotClient botClient)
        {
            var telegramid = callbackQuery.From.Id;
            var callbackdata = callbackQuery.Data.Split('~');
            int msgId = int.Parse(callbackdata[1]);
            bool needsave = bool.Parse(callbackdata[2]);
            

            if (needsave)
            {
                if (MessageStorage.CheckMessages(telegramid))
                {
                    try
                    {
                        await botClient.SendTextMessageAsync(telegramid, "This message has already been saved");


                        Console.WriteLine(msgId);

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {

                    MessageStorage.SaveMessage(msgId, callbackQuery.Message.Text, telegramid);
                    await botClient.SendTextMessageAsync(telegramid, "This message has been saved");
                }

            }
            else
            {
                MessageStorage.DeletMessage(telegramid);
                await botClient.SendTextMessageAsync(telegramid, "try This message processed");

            }

        }

    }
}
