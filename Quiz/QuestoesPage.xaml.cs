
using Android.App;
using Android.OS;

namespace Quiz;

public partial class QuestoesPage : ContentPage
{
	public QuestoesPage()
	{

		InitializeComponent();
	}

    int countQuestions = 0;
    int totalPoints = 0;
    bool isCorrect = false, stopRunning = false;

    protected override void OnAppearing()
	{
		base.OnAppearing();

        ProgressValidation();
		TimeValidation();
	}

    bool timeExpired = false; // false

    private async void ProgressValidation()
	{

		await timeBar.ProgressTo(1, 60000, Easing.Linear);

    }

	private async void TimeOutValidation()
	{
        if (timeExpired && !stopRunning)
        {
			TimeSpan vibrationTime = TimeSpan.FromSeconds(1);

            Vibration.Default.Vibrate(vibrationTime);

            await Navigation.PushAsync(new TimeOutPage());

        }
    }

	private async void TimeValidation()
	{

		int minutes = 1;

		int seconds = 0;

		bool IsTimeOut = false;

		while (!IsTimeOut)
		{

			minutes -= 1;

			seconds = 59;

			while (seconds != 0)
			{

				seconds -= 1;

				if (seconds >= 10)
				{
					labelTime.Text = minutes + ":" + seconds;
				} else
				{
					labelTime.Text = minutes + ":" + "0" + seconds;

				}

				await Task.Delay(1000);

			}

			if (minutes == 0)
			{
				IsTimeOut = true;
			}

		}

        timeExpired = true;

        TimeOutValidation();


    }

    async void btnNextQuestion_Clicked(System.Object sender, System.EventArgs e)
    {

        countQuestions++;

		if (countQuestions == 1)
		{
            verificarResposta(ans2, 1);

            imgQuestion.Source = "question2_flag";

			ans1.Content = "England";
			ans3.Content = "Saudi Arabia";
			ans2.Content = "Germany";
			ans4.Content = "Japan";
		}
		else if (countQuestions == 2)
        {
            verificarResposta(ans3, 2);

            imgQuestion.Source = "question3_flag";

            ans1.Content = "Tanzania";
            ans2.Content = "Italy";
            ans3.Content = "Colombia";
            ans4.Content = "England";

        }
        else if (countQuestions == 3)
        {
            verificarResposta(ans4, 3);

            imgQuestion.Source = "question4_flag";

            ans1.Content = "Kenya";
            ans2.Content = "South Korea";
            ans3.Content = "Poland";
            ans4.Content = "Argentina";

        }
        else if (countQuestions == 4)
        {
            verificarResposta(ans1, 4);

            imgQuestion.Source = "question5_flag";

            ans1.Content = "Canada";
            ans2.Content = "Qatar";
            ans3.Content = "Ghana";
            ans4.Content = "Nepal";

			
        }else if(countQuestions == 5)
		{
            verificarResposta(ans2, 5);

            await SecureStorage.SetAsync("totalPoints", totalPoints.ToString());

            stopRunning = true;

            await Navigation.PushAsync(new ReportPage());
        }

    }

    private async void verificarResposta(System.Object sender, int numQuestao)
	{

		RadioButton opcaoCorreta = sender as RadioButton;
		if(opcaoCorreta.IsChecked)
		{
			isCorrect = true;
            totalPoints++;
			await SecureStorage.SetAsync((numQuestao-1).ToString(), "Correct");

		}
		else
		{
            await SecureStorage.SetAsync((numQuestao-1).ToString(), "Wrong");
            isCorrect = false;
		}
		

    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}