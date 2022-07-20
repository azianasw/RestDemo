using System;
using System.Windows;

namespace WpfApp
{
    public interface INotification
    {
        void Show(string content);
    }

    public class Notification : INotification
    {
        public void Show(string content)
        {
            MessageBox.Show(content);
        }
    }
}
