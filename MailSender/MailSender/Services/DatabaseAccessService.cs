using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
    class DatabaseAccessService : IDataAccessService
    {

        private readonly EmailsDataContext _dataContext = new EmailsDataContext();
        public ObservableCollection<Emails> GetEmails() => new ObservableCollection<Emails>(_dataContext.Emails);

        public int CreateEmail(Emails email)
        {
            if (_dataContext.Emails.Contains(email))
                return email.Id;
            _dataContext.Emails.InsertOnSubmit(email);
            _dataContext.SubmitChanges();
            return email.Id;
        }

        public void DeleteEmail(Emails email)
        {
            if (!_dataContext.Emails.Contains(email))
                return;
            _dataContext.Emails.DeleteOnSubmit(email);
            _dataContext.SubmitChanges();
            return;
        }


    }
}
