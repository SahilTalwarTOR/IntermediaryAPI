using System.Reflection.Metadata;

namespace vs_iAPI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void nameCompleted(object sender, EventArgs e)
        {
            doTextHide(entryName, checkName);
        }

        private void keyCompleted(object sender, EventArgs e)
        {
            doTextHide(entryKey, checkKey);
        }

        private void doTextHide(Entry textbox, CheckBox checkbox)
        {
            if (textbox.Text.Trim() != "")
            {
                checkbox.IsChecked = true;
                textbox.IsPassword = true;
            }
            else
            {
                checkbox.IsChecked = false;
                textbox.IsPassword = true;
            }
        }
    }

}
