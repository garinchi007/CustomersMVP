using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string Message)
        {
            if (Message == null) Message = "";
            MessageBox.Show(Message);
        }
    }
}
