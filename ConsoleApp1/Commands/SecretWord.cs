using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands
{
    class SecretWord : Command
    {
        public override string Name => "Secret";

        public override List<CallCammandInfo> CallCammandInfos =>
            new List<CallCammandInfo>()
            {
                new CallCammandInfo("UTEC2019")
            };

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            if(!IsRegistered(message))
            {

                UserStorage.SaveEmployDb(message);
                await client.SendTextMessageAsync(message.From.Id, "Congratulations! You was registered");
            }
            else
            {
                await client.SendTextMessageAsync(message.From.Id, "You has already been registered");
            }
        }
    }
}
