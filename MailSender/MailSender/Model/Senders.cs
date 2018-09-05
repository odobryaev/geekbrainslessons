using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Model
{
    public static class Senders
    {
        public static Dictionary<string, string> SenderDictionary { get; } = new Dictionary<string, string>
        {
            {"odobryaev.geekbrains@gmail.com", "ZdvklqjwrqGF4<;<" }
        };

        public static Dictionary<string, int> ServerDictionary { get; } = new Dictionary<string, int>
        {
            {"smtp.gmail.com", 587 }
        };
    }
}
