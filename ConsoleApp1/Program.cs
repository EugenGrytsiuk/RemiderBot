using ConsoleApp1.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static ConsoleApp1.UserStorage;

namespace ConsoleApp1
{
    class Program
    {
        static Main2 main2 = new Main2();
        
        public static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(TredSend);
            ThreadPool.QueueUserWorkItem(TredSendAll);
            
            Console.WriteLine("Hello");
            
            main2.RunBot();
            
            
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
            Console.ReadLine();
            var text = MessageStorage.GetAllTextDb();
            Console.WriteLine(text);
            Console.ReadLine();
        }
        #region
        public static void TredSend(object state)
        {
            SenderSheduler sender = new SenderSheduler();
            sender.Star();
        }
        public static void TredSendAll(object state)
        {
            SendAllScheduler SendAll = new SendAllScheduler();
            SendAll.Start();
        }
        public class Main2
        {
            private ITelegramBotClient telegramBot;

            public void RunBot()
            {
                telegramBot = TelegramAdapter.Get();
                this.telegramBot.OnMessage += Bot_OnMessage;
                this.telegramBot.OnCallbackQuery += Bot_OnCallbackQuery;
                telegramBot.OnMessageEdited += Bot_OnMessageEdited;



            }

            private void Bot_OnMessageEdited(object sender, MessageEventArgs e)
            {
               try
                {

                }
                catch
                {

                }
            }

            private void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
            {
                var callbackData = e.CallbackQuery.Data.Split('~');
                var handlerName = callbackData[0];
                var handler = TelegramAdapter.Handler.Where(h => h.Name == handlerName).FirstOrDefault();


                handler?.HandleCallBackQuery(e.CallbackQuery, telegramBot);


            }

            public virtual bool IsRegistered(Message message)
            => UserStorage.CheckUserDb(message.From.Id);

            public void Bot_OnMessage(object sender, MessageEventArgs e)
            {
                ToLog logwriter = new ToLog();

                if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text && !string.IsNullOrEmpty(e.Message.Text))
                {
                    var command = e.Message.Text.Contains(" ") ?
                    e.Message.Text.Substring(0, e.Message.Text.IndexOf(" "))
                    : e.Message.Text;

                    var cmnd = TelegramAdapter.Commands.Where(c => c.Contains(command)).FirstOrDefault();

                    if (cmnd != null)
                    {
                        cmnd.Execute(e.Message, this.telegramBot);
                    }
                   
                    else
                    {
                        var hnd = TelegramAdapter.Handler.Where(h => h.Name == "Text").FirstOrDefault();
                        hnd.HandelMessaga(e.Message, this.telegramBot);
                    }
                    
                }
            }

            internal void Stop()
            {
                telegramBot.StopReceiving();
            }
        }
        #endregion
    }
}
