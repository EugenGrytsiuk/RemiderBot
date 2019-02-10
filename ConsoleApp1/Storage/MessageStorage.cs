using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using ConsoleApp1.AppSetting;
using System;
using AppContext = ConsoleApp1.AppSetting.AppContext;

namespace ConsoleApp1
{
    class MessageStorage
    {
        static AppContext contex = new AppContext();

        public bool CheckMesDb(int telegramid)
            => GetAllMessageDb().Where(x => x.TelegramId == telegramid).FirstOrDefault() != null;

        public static int? GetDbId(int telegramid)
            => GetAllMessageDb().Where(e => e.TelegramId == telegramid).FirstOrDefault()?.Id;

        public static List<UserMessage> GetAllMessageDb()
        {
            var tmp = contex.UserMessages.ToList();
            return tmp;
        }

        public static string GetAllTextDb()
        {
            string tmp = "";
            string users = "";
            string texts = "";

            var mesi = contex.UserMessages.Where(x => x.UserMessages == x.UserMessages);
            foreach (var um in mesi)
            {
                texts = um.UserMessages;
                foreach (var ui in contex.Employes.Where(p => p.TelegramId == um.TelegramId))
                {
                    users = ui.TelegramName;
                }
                tmp += users + "\n " + texts + "\n";
            }

            return tmp;
        }

        public void SaveMessageDB(int messageid, string message, int telegramid)
        {
            UserMessage empMessage = new UserMessage { MessageId = messageid, UserMessages = message, TelegramId = telegramid };
            contex.UserMessages.Add(empMessage);
            contex.SaveChanges();
        }

        internal void DeletMessage(int telegramid)
        {
            try
            {
                var findIdDb = MessageStorage.GetDbId(telegramid);
                var custumer = contex.UserMessages.Single(x => x.Id == findIdDb);
                contex.UserMessages.Remove(custumer);
                contex.SaveChanges();
            }
            catch
            {

            }

        }
    }
}
