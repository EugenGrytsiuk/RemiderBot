using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class MessageStorage
    {
        public static bool CheckMessages(int telegramId)
        
            => GetAllMessages().Where(m => m.TelegramId == telegramId) !=null;
           


        

        public static IEnumerable<int> GetAllTelegramId()
            => GetAllMessages().Select(i => i.MessageId);

        public static void SaveMessage(int messageid, string message, int telegramid)
        {
            var xdoc = XDocument.Load(AppSettings.SavedMessagesPath);

            xdoc.Root.Add(new XElement("mess",
                new XElement("telegramid", telegramid),
                new XElement("messageid", messageid),
                new XElement("message", message)));

            xdoc.Save(AppSettings.SavedMessagesPath);

        }

        public static List<UserMessage> GetAllMessages()
        {
            var xdoc = XDocument.Load(AppSettings.SavedMessagesPath);

            return (from mes in xdoc.Root.Descendants("Mess")
                    select new UserMessage()
                    {
                        MessageId = int.Parse(mes.Element("messageid").Value),
                        UserMessages = mes.Element("message").Value,
                        TelegramId = int.Parse(mes.Element("telegramid").Value)                   
                    }).ToList();
        }

        internal static void DeletMessage(int telgId)
        {
            var xdoc = XDocument.Load(AppSettings.SavedMessagesPath);

            xdoc.Root.Element("telegramid").Remove();
            xdoc.Save(AppSettings.SavedMessagesPath);
           // throw new Exception("Bot not started");
            

        }
    }
}
