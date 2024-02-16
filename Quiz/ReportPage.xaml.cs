namespace Quiz;

public partial class ReportPage : ContentPage
{
	public ReportPage()
	{
		InitializeComponent();


	}

    private void pegaDadosUser()
    {



    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        //labelTotal.Text = await SecureStorage.Default.GetAsync("totalPoints");


    }
}
