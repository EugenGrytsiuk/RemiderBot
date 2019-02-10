using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class UserStorage
    {
        

        private static List<Employe> GetAllEmployes()
        {
            XDocument xdoc = XDocument.Load(AppSettings.FriendListPath);

            return (from emp in xdoc.Root.Descendants("friends")
                    select new Employe()
                    {
                        FirstName = emp.Element("firstName").Value,
                        LastName = emp.Element("lastName").Value,
                        TelegramId = int.Parse(
                            emp.Element(
                                "telegramid").Value),
                        TelegramName = emp.Element("telegram").Value

                    }).ToList();
        }

        public static bool CheckUser(int telegramid)
           =>  GetAllEmployes().Where(e => e.TelegramId == telegramid).FirstOrDefault() !=null;
        

        public static int? GetTelegramId(string telegramname)
            => GetAllEmployes().Where(e => e.TelegramName == telegramname).FirstOrDefault()?.TelegramId;

        public static IEnumerable<int> GetAllTelegramId()
            => GetAllEmployes().Select(i => i.TelegramId);


        public static void SaveUserInfo(Employe user)
        {
            var xdoc = XDocument.Load(AppSettings.FriendListPath);

            xdoc.Root.Add(new XElement("friend", 
                new XElement("telegram", user.TelegramName), 
                new XElement("firstname", user.FirstName), 
                new XElement("lastname", user.LastName), 
                new XElement("telegramid", user.TelegramId)));

            xdoc.Save(AppSettings.FriendListPath);
        }
    }
}
