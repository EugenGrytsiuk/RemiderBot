using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using ConsoleApp1.Commands;


namespace ConsoleApp1
{
    public static class TelegramAdapter
    {
        private static ITelegramBotClient botclient;
        private static List<Command> commandlist;
        private static List<Handler> handlerLists;

        public static IReadOnlyList<Command> Commands => commandlist.AsReadOnly();
        public static IReadOnlyList<Handler> Handler => handlerLists.AsReadOnly();

        public static ITelegramBotClient Get()
        {
            if (botclient != null)
                return botclient;

            commandlist = new List<Command>
            {
                new StartCommand(),
                new SecretWord()
            };

            handlerLists = new List<Handler>
            {
                new TextHandler()
            };

            botclient = new TelegramBotClient(AppSettings.BotToken);
            var me = botclient.GetMeAsync().Result;
            if(me != null)
            {
                botclient.StartReceiving();
                return botclient;
            }

            throw new Exception("Bot not started");
        }



    }
}
