using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ConsoleApp1;

namespace ConsoleApp1
{
    public abstract class Handler
    {
        public abstract string Name { get; }
        public abstract void HandelMessaga(Message message, ITelegramBotClient botClient);
        public abstract void HandleCallBackQuery(CallbackQuery callbackQuery, ITelegramBotClient botClient);
        public virtual bool IsRegistered(Message message)
            => UserStorage.CheckUserDb(message.From.Id);

    }
}
