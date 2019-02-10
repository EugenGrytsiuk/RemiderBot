namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp1.AppSetting.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConsoleApp1.AppSetting.AppContext context)
        {
            Employe employe = new Employe();
            {
                employe.Id = 1;
                employe.TelegramId = 273166881;
                employe.FirstName = "Евгений";
                employe.TelegramName = "EvgenGrytsiuk";
            }
            Employe employe2 = new Employe();
            {
                employe2.Id = 2;
                employe2.TelegramId = 530089502;
                employe2.TelegramName = "Marina";
                employe2.FirstName = "mar";
            }
            context.Employes.Add(employe);
            context.Employes.Add(employe2);
            context.SaveChanges();

            UserMessage storage = new UserMessage();
            {
                storage.Id = 1;
                storage.TelegramId = 273166881;
                storage.UserMessages = "говоря, планировщик был заморожен будет означать API имеет огромную ошибку. " +
                    "Не могли бы вы предоставить трассировку стека или любые ошибки, возникшие в случае, о котором вы упоминаете." +
                    "на основе моего опыта объекта планировщика возвращенного будет таким же, как много раз вы называете";
            }
            UserMessage storage2 = new UserMessage();
            {
                storage.Id = 2;
                storage.TelegramId = 530089502;
                storage.UserMessages = "4Когда вы перебираете элементы в последовательности без предварительной " +
                    "материализации(.ToList()) - то все это время висит открытый DataReader с результатами запроса к БД.";

            }
            context.UserMessages.Add(storage);
            context.UserMessages.Add(storage2);

            context.SaveChanges();





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
