using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands
{
    class StartCommand : Command
    {
        public override string Name => "Start";

        public override List<CallCammandInfo> CallCammandInfos => 
            new List<CallCammandInfo>()
            {
                new CallCammandInfo("/start")
            };

        public override async void Execute(Message message, ITelegramBotClient client)
        {

            if (!IsRegistered(message))
                await client.SendTextMessageAsync(message.From.Id, "Hello! Enter the secret word"); 
        }
    }
}
