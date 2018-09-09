using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Emails> GetEmails();

        int CreateEmail(Emails emails);
        void DeleteEmail(Emails emails);

    }
}
