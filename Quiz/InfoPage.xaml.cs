namespace Quiz;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
	}

    async void btnInfoPage_Clicked(System.Object sender, System.EventArgs e)
    {

		await Navigation.PushAsync(new QuestoesPage());

    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
