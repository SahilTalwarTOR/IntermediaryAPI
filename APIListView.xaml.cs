namespace vs_iAPI;
using System.Diagnostics;


public partial class APIListView : ContentPage
{
	public static APIVewModel apiView = new APIVewModel();
	public APIListView()
	{
		InitializeComponent();
		// Test adding some dummy stuff tbh
        BindingContext = apiView;
       

        Debug.WriteLine(apiView.Api_List.LongCount());

	}

	public void AddToApiList(APIObj api)
	{
		apiView.Api_List.Add(api);
	}


}