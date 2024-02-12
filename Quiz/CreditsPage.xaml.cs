namespace Quiz;

public partial class CreditsPage : ContentPage
{
	public CreditsPage()
	{
		InitializeComponent();
	}

    void btnBack_Clicked(System.Object sender, System.EventArgs e)
    {
		Navigation.PushAsync(new MainPage());
    }
}
