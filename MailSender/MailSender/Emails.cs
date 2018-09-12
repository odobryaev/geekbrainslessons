using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MailSender
{
    partial class Emails : IDataErrorInfo
    {
        public string Error { get; }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Value):
                        var address = Value;
                        if (string.IsNullOrWhiteSpace(Value))
                            return "����� ����";
                        if (!Regex.IsMatch(address, @"[a-zA-Z]\w*@\w+\.\w+"))
                            return "������������ �����";
                        return "";
                    default: return "";
                }
            }

        }
        
    }
}