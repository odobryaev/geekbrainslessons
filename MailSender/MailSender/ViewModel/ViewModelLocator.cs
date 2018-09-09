using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Services;

namespace MailSender.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<WpfMailSenderViewModel>();
            SimpleIoc.Default.Register<MessageSendResultDlgViewModel>();

            SimpleIoc.Default.Register<IDataAccessService, DatabaseAccessService>();
           
        }

        public WpfMailSenderViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WpfMailSenderViewModel>();
            }
        }
        public MessageSendResultDlgViewModel Dialog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessageSendResultDlgViewModel>();
            }
        }

    }
}