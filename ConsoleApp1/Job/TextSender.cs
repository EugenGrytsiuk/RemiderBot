using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Telegram.Bot;



namespace ConsoleApp1
{
    public class TextSender : IJob
    {
        public static string _reminderText = "What To Do";

        public async Task Execute(IJobExecutionContext context)
        {
            TelegramBotClient telegramBot = new TelegramBotClient("751343084:AAGXzuDEhmEq4ZjjMm--JHFu4Jrb58yOK_E");
            foreach (int user in  UserStorage.GetAllId())
            {
                await telegramBot.SendTextMessageAsync(user, $"{_reminderText}");
                Console.WriteLine("message was send");
            }
            

        }
    }
   
}
