using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRD_P1
{
    public class MessageBoxProvider : IMessageProvider
    {
        public void SendMessage(string message)
        {
            Task messageToShow = new Task(() =>
                MessageBox.Show(message));
            messageToShow.Start();
        }
    }
}