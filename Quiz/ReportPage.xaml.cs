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

        Label[] labelsReport = {q1Report, q2Report, q3Report, q4Report, q5Report};

        for(int i = 0; i <= 4; i++)
        {
        
            string temp = await SecureStorage.GetAsync(i.ToString());

            if(temp == null || temp == "")
            {
                labelsReport[i].Text = "Wrong";
            }
            else
            {
                labelsReport[i].Text = temp;
            }
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

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
