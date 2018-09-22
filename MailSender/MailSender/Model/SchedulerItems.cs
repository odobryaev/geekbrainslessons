using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Model
{
    public class SchedulerItems
    {
        public DateTime MessageDateTime
        {
            get; set;
        }

        public string Header
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }
    }
}
