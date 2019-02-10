using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp1.Commands
{
    //public class RemindText : Command
    //{
    //    public override string Name => "/remind";
    //    private string textMes = null;
        

    //    public override List<CallCammandInfo> CallCammandInfos =>
    //        new List<CallCammandInfo>()
    //        {
    //            new CallCammandInfo("/remind")
    //        };

    //    public override async void Execute(Message message, ITelegramBotClient telegramBotClient)
    //    {
    //        var msgId = message.MessageId;
    //        textMes = message.Text;

    //        var keyboard2 = new InlineKeyboardMarkup(new List<InlineKeyboardButton>
    //            {
    //                InlineKeyboardButton.WithCallbackData("\U00002705 Save",$"{Name}~{msgId}~true"),
                    
    //            });
    //        this.telegramBotClient.OnCallbackQuery += remindPut;
    //            await telegramBotClient.SendTextMessageAsync(message.From.Id, " Save remind text? ", replyMarkup: keyboard2);
    //        //InputMessageContent = new InputMessageContent(
    //        //                latitude: 13.1449577f,
    //        //                longitude: 52.507629f);
    //        //InputMessageContent().
    //    }

    //    private async void remindPut(object sender, CallbackQueryEventArgs e)
    //    {
    //        await telegramBotClient.SendTextMessageAsync(e.CallbackQuery.Message.From.Id, "-enter word -");
    //    }

    //    public async void HandleCallBackQuery(CallbackQuery callbackQuery, ITelegramBotClient telegramBotClient)
    //    {
    //        var telegramid = callbackQuery.From.Id;

    //        try
    //        {
    //            await telegramBotClient.SendTextMessageAsync(telegramid, "Saved remind text");
                
    //            TextSender._reminderText = textMes;
    //            try
    //            {
    //                await telegramBotClient.DeleteMessageAsync(telegramid, callbackQuery.Message.MessageId);
    //            }
    //            catch { }


    //        }
    //        catch (Exception ex)
    //        {


    //        }

    //    }
    //}
}
