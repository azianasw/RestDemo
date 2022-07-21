using System;
using System.Windows;

namespace WpfApp
{
    public class Notification : INotification
    {
        public void Show(string content)
        {
            MessageBox.Show(content);
        }
    }
}
