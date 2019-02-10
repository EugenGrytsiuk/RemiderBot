using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Quartz;

namespace ConsoleApp1
{
    class TextHandler : Handler
    {
        public override string Name => "Text";
        public string textMes;

        SenderSheduler sender = new SenderSheduler();
        SendAllScheduler sendAll = new SendAllScheduler();
        MessageStorage MessageStorage = new MessageStorage();
        
        public async override void HandelMessaga(Message message, ITelegramBotClient botClient)
        {
            if (IsRegistered(message))
            {
                string mestext = message.Text;
                if (mestext.StartsWith("$"))
                {
                    TextSender sender = new TextSender();
                    mestext = mestext.Substring(1);
                    TextSender._reminderText = mestext;

                        await botClient.SendTextMessageAsync(message.From.Id, "reminder text changed ");
                }
                else if (mestext.StartsWith("&"))
                {               // exemple: 0 0,5 10,16 ? * SUN,MON,TUE,WED,THU,FRI,SAT *
                    string cronExp;
                    string minut = "";
                    string hour = "";
                    string day = "";

                    sender.Stop();

                    mestext = mestext.Substring(1);
                    string[] totime = mestext.Split(' ');
                    
                        minut = totime[0].ToString();
                        hour = totime[1].ToString();
                        day = totime[2].ToString();
                    
                    cronExp = $"0 {minut} {hour} ? * {day} *";
                    SenderSheduler.cron_expression = cronExp;

                    if (CronExpression.IsValidExpression(cronExp))
                    {
                        try
                        {
                            sender.Star();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                       
                        await botClient.SendTextMessageAsync(message.From.Id, "time saved");
                    }
                    else
                    {                        
                        await botClient.SendTextMessageAsync(message.From.Id, "wrong format\r ex: min hour day\n " +
                            "like: &15 11,16 MON,TUE - this well send remind at 11.15AM and 16.15PM on monday and tuesday");
                    }                 
                }
                else if (mestext.StartsWith("*"))
                {
                    string cronExp;
                    string minut = "";
                    string hour = "";
                    string day = "";

                    sendAll.Stop();

                    mestext = mestext.Substring(1);
                    string[] totime = mestext.Split(' ');

                    minut = totime[0].ToString();
                    hour = totime[1].ToString();
                    day = totime[2].ToString();

                    cronExp = $"0 {minut} {hour} ? * {day} *";
                    SendAllScheduler.cron_alltext = cronExp;

                    if (CronExpression.IsValidExpression(cronExp))
                    {
                        try
                        {
                            sendAll.Start();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        await botClient.SendTextMessageAsync(message.From.Id, "time saved");
                    }
                    else
                    {

                        await botClient.SendTextMessageAsync(message.From.Id, "wrong format\r ex: min hour day");
                    }
                }
                else
                {
                    var msgId = message.MessageId;
                    textMes = message.Text;

                    var findIdDb = MessageStorage.GetDbId(message.From.Id);
                    await botClient.SendChatActionAsync(message.Chat.Id, chatAction: Telegram.Bot.Types.Enums.ChatAction.Typing);
                    await Task.Delay(1000);
                    var keyboard = new InlineKeyboardMarkup(new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData("\U00002705 Save ",$"{Name}~{msgId}~true"),
                        InlineKeyboardButton.WithCallbackData("\U0000274C Cancel ",$"{Name}~{msgId}~false"),
                        InlineKeyboardButton.WithCallbackData("\U00002716 Delete saved message",$"{Name}~{msgId}~delet")
                    });
                    await botClient.SendTextMessageAsync(message.From.Id, " choose time ", replyMarkup: keyboard);
                }
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
            bool needsave = true;

            try
            {
                needsave = bool.Parse(callbackdata[2]);

                if (needsave)
                {
                    if (MessageStorage.CheckMesDb(telegramid))
                    {
                        try
                        {
                            await botClient.SendTextMessageAsync(telegramid, "Message has already been saved");
                            try
                            { await botClient.DeleteMessageAsync(telegramid, callbackQuery.Message.MessageId); }
                            catch { }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        MessageStorage.SaveMessageDB(msgId, textMes, telegramid);
                        await botClient.SendTextMessageAsync(telegramid, "This message has been saved");
                        try
                        { await botClient.DeleteMessageAsync(telegramid, callbackQuery.Message.MessageId); }
                        catch { }
                    }

                }
                else
                {
                    //MessageStorage.DeletMessage(telegramid);
                    await botClient.SendTextMessageAsync(telegramid, "Message not saved!");
                    await botClient.DeleteMessageAsync(telegramid, callbackQuery.Message.MessageId);
                }


            }
            catch
            {
                MessageStorage.DeletMessage(telegramid);
                await botClient.SendTextMessageAsync(telegramid, "Message was deleted!");
                try
                { await botClient.DeleteMessageAsync(telegramid, callbackQuery.Message.MessageId); }
                catch { }
            }
        }
    }
}
   

