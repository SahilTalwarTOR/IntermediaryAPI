using System.Reflection.Metadata;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace vs_iAPI
{

    public partial class MainPage : ContentPage
    {
        int count = 0;
        string frequency = "";
        string api_name = "";
        internal string api_key = ""; // Theres probably someone on GitHub who just searched "api_key" and thinks they'll find something here LOL
        Boolean akcExists = false;
        string akcFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "akc.dat");
        private APIListView apiListView;

        public MainPage()
        {
            InitializeComponent();

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (File.Exists(appDataDirectory + "/akc.dat"))
                {
                    this.akcExists = true;
                }
                else
                {
                    this.akcExists = false;
                    File.Create(Path.Combine(appDataDirectory, "akc.dat"));
                    // The file exists, so we'll probablyyy have to load it. We'll do that later on

                }
            }
        }


        private void nameCompleted(object sender, EventArgs e)
        {
            doTextHide(entryName, checkName);
            this.api_name = entryName.Text;
        }

        private void pickedFrequency(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                this.frequency = picker.Items[selectedIndex];
            }


        }
        private void keyCompleted(object sender, EventArgs e)
        {
            doTextHide(entryKey, checkKey);
            this.api_key = entryKey.Text;
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

	private void saveAPI(Object sender, EventArgs e) {
            // We'll do some of the data-saving here, it's going to be quite a function..
            // We have important variables to use!

            saveCheck();
	}

        private async void saveCheck()
        {
            // Variables to check
            string localApi = this.api_key.Trim();
            string localName = this.api_name.Trim();
            string localFreq = this.frequency.Trim();

            if (localApi == "" || localName == "" || localFreq == "")
            {
                // Well, things aren't looking good, the user entered some empty parameters. Not okay! We have two options
                // 1. We respectfully tell the user to re-enter details
                // 2. We empty all fields, make the program crash, and make them re-launch everything, maybe we even lock them out for 2 hours, should I create a support hotline for them to call? I'll be the one picking up calls and I will make sure its as frustrating at possible
                // The second one may be best, but for my sanity, we will choose the first one.

                throw new ArgumentException("Missing inputs");
            } else
            {
                // Okay, we good :D
                APIObj enteredApi = new APIObj(this.api_key, this.api_name, this.frequency);
                apiListView.AddToApiList(enteredApi);
                try
                {
                    File.AppendAllText(akcFilePath, this.api_key + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error Occured Saving API", "An error occured saving the API\nCheck if akc.dat exists in AppData", "OK");
                }
            }
        }
	
    }

}
