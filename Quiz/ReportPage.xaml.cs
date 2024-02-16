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

    private async void validacaoQuestoes()
    {
        

        Label[] labelsReport = new Label[5];
        labelsReport[0] = q1Report;
        labelsReport[1] = q2Report;
        labelsReport[2] = q3Report;
        labelsReport[3] = q4Report;
        labelsReport[4] = q5Report;

        for(int i = 0; i <= 4; i++)
        {
            labelsReport[i].Text = await SecureStorage.GetAsync(i.ToString());
        }

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        pegaDadosUser();

        validacaoQuestoes();

        totalPoints.Text += await SecureStorage.GetAsync("totalPoints");

    }

    async void btnBackHome_Clicked(System.Object sender, System.EventArgs e)
    {

        SecureStorage.Default.RemoveAll();

        await Navigation.PushAsync(new MainPage());

    }
}
