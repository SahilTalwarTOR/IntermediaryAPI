using System.ComponentModel;
using vs_iAPI;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;   
using System.Diagnostics;
public class APIVewModel : INotifyPropertyChanged
{
    private ObservableCollection<APIObj> api_list = new();

    public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged; // I have no idea what the fuck I'm doing

    protected virtual void OnPropertyChanged(string propertyName)
    {
        Debug.WriteLine($"Property {propertyName} changed.");
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
    }
    public ObservableCollection<APIObj> Api_List
    {
        get => api_list;
        set
        {
            if (api_list != value) // We could be a normal language
            {
                api_list = value;
                OnPropertyChanged(nameof(Api_List));
            }
        }
    }
}