using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract List<CallCammandInfo> CallCammandInfos { get; } 

        public abstract void Execute(Message message, ITelegramBotClient telegramBotClient);
        public virtual bool Contains(string command)
            => CallCammandInfos.Any(cc => command.ToLower().Contains(cc.Command.ToLower()));

        public virtual bool IsRegistered(Message message)
            => UserStorage.CheckUserDb(message.From.Id);


    }
}
