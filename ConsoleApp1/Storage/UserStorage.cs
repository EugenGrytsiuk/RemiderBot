using ConsoleApp1.AppSetting;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Telegram.Bot.Types;

namespace ConsoleApp1
{
    public class UserStorage
    {
        static AppContext contex = new AppContext();

        public static void SaveEmployDb(Message message)
        {
            Employe emp = new Employe
            {
                FirstName = message.From.FirstName,
                LastName = message.From.LastName,
                TelegramName = message.From.Username,
                TelegramId = message.From.Id
            };
            contex.Employes.Add(emp);
            contex.SaveChanges();
        }

        public static List<Employe> GetAllEmployDb()
        {
            var tmp = contex.Employes.ToList();
            return tmp;
        }

        public static bool CheckUserDb(int telegramid)
            => GetAllEmployDb().Where(x => x.TelegramId == telegramid).FirstOrDefault() != null;

        
        public static IEnumerable<int> GetAllId()
                        => GetAllEmployDb().Select(x => x.TelegramId);









        //private static List<Employe> GetAllEmployes()
        //{
        //    XDocument xdoc = XDocument.Load(@"c:\Users\e.grytsiuk\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\FriendList.xml");

        //    return (from emp in xdoc.Root.Descendants("friends")
        //            select new Employe()
        //            {
        //                FirstName = emp.Element("firstName").Value,
        //                LastName = emp.Element("lastName").Value,
        //                TelegramId = int.Parse(
        //                    emp.Element(
        //                        "telegramid").Value),
        //                TelegramName = emp.Element("telegram").Value

        //            }).ToList();
        //}

        //public static bool CheckUser(int telegramid)
        //   =>  GetAllEmployes().Where(e => e.TelegramId == telegramid).FirstOrDefault() !=null;


        //public static int? GetTelegramId(string telegramname)
        //    => GetAllEmployes().Where(e => e.TelegramName == telegramname).FirstOrDefault()?.TelegramId;

        //public static IEnumerable<int> GetAllTelegramId()
        //    => GetAllEmployes().Select(i => i.TelegramId);


        //public static void SaveUserInfo(Employe user)
        //{
        //    var xdoc = XDocument.Load(@"c:\Users\e.grytsiuk\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\FriendList.xml");

        //    xdoc.Root.Add(new XElement("friend", 
        //        new XElement("telegram", user.TelegramName), 
        //        new XElement("firstname", user.FirstName), 
        //        new XElement("lastname", user.LastName), 
        //        new XElement("telegramid", user.TelegramId)));

        //    xdoc.Save(AppSettings.FriendListPath);
        //}
    }
}
