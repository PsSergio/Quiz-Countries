namespace Quiz;

public partial class TimeOutPage : ContentPage
{
	public TimeOutPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    void btnTimeOut_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ReportPage());
    }
}
