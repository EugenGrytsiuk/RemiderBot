using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ConsoleApp1
{
    public class AllTextSender : IJob
    {
        //static ITelegramBotClient 

        public async Task Execute(IJobExecutionContext context)
        {
            TelegramBotClient telegramBot = new TelegramBotClient("751343084:AAGXzuDEhmEq4ZjjMm--JHFu4Jrb58yOK_E");
            int user = 273166881;
            await telegramBot.SendTextMessageAsync(user, $"{MessageStorage.GetAllTextDb()}");


        }
    }
}
