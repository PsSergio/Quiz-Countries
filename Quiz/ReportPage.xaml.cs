namespace Quiz;

public partial class ReportPage : ContentPage
{
	public ReportPage()
	{
		InitializeComponent();


	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        labelTotal.Text = await SecureStorage.Default.GetAsync("totalPoints");


    }
}
