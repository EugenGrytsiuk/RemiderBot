using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class  SendAllScheduler
    {
        public static string cron_alltext = "0 1 16 ? * MON *";

        static IScheduler myscheduler;// = new StdSchedulerFactory();

        public async void Start()
        {
            try
            {
                NameValueCollection properties = new NameValueCollection();
                properties["quartz.scheduler.instanceName"] = "MyShedSend";

                myscheduler = await new StdSchedulerFactory(properties).GetScheduler();
                await myscheduler.Start();

                CronScheduleBuilder shedall = CronScheduleBuilder
                   .CronSchedule(cron_alltext);

                IJobDetail job2 = JobBuilder.Create<AllTextSender>()
                     .WithIdentity("trigger2", "group2")
                    .Build();

                ITrigger trigger2 = TriggerBuilder.Create()
                        .WithIdentity("trigger2", "group2")
                        .StartNow()
                        .WithSchedule(shedall)
                        .Build();

                await myscheduler.RescheduleJob(trigger2.Key, trigger2);
                await myscheduler.ScheduleJob(job2, trigger2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("class SendAllScheduler \n method Start \n" + ex.Message.ToString());
            }
        }

        public async void Stop()
        {

            await myscheduler.Clear();
        }

    }
}
