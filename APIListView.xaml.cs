namespace vs_iAPI;
using System.Diagnostics;


public partial class APIListView : ContentPage
{
	public APIVewModel apiView = new APIVewModel();
	public APIListView()
	{
		InitializeComponent();
		// Test adding some dummy stuff tbh
        BindingContext = apiView;
       

        Debug.WriteLine(this.apiView.Api_List.LongCount());

	}

	public void AddToApiList(APIObj api)
	{
		this.apiView.Api_List.Add(api);
	}


}