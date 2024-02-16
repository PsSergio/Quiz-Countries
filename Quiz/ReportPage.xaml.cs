namespace Quiz;

public partial class ReportPage : ContentPage
{
	public ReportPage()
	{
		InitializeComponent();


	}

    private async void pegaDadosUser()
    {

        getName.Text += await SecureStorage.GetAsync("nameUser");
        getAge.Text += await SecureStorage.GetAsync("ageUser");


    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        pegaDadosUser();

        totalPoints.Text += await SecureStorage.GetAsync("totalPoints");

    }

    void btnBackHome_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}
