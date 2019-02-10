using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Util;
using Quartz.Impl;
using System;

namespace ConsoleApp1
{
    public class SenderSheduler
    {
        public static string cron_expression = "0 0 10,17 ? * MON *";
        public static string cron_alltext = "0 1 16 ? * MON *";

        static IScheduler myscheduler;

        public async void Star()
        {
            try
            {
                myscheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await myscheduler.Start();

                CronScheduleBuilder shed = CronScheduleBuilder
                  .CronSchedule(cron_expression);         //48,49,50,51,52 10,11,12,13 ? * MON,TUE,WED *");

                IJobDetail job = JobBuilder.Create<TextSender>()
                    .WithIdentity("job1", "group1")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                   .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
                   .StartNow()                             // запуск сразу после начала выполнения
                   .WithSchedule(shed)            // настраиваем выполнение действия
                                                  // через 1 минуту
                                                  // бесконечное повторение                
                   .Build();                               // создаем триггер
                                                           /// начинаем выполнение работы
                //String newCronExpression = cron_expression; // the desired cron expression             


                
                await myscheduler.RescheduleJob(trigger.Key, trigger);
                await myscheduler.ScheduleJob(job, trigger);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("class SenderSheduler \r method Start \r" + ex.Message);
            }
        }
        public async void Stop()
        {
            await myscheduler.Clear();
        }
    }
}
