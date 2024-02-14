
using Android.App;
using Android.OS;

namespace Quiz;

public partial class QuestoesPage : ContentPage
{
	public QuestoesPage()
	{

		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		ProgressValidation();
		TimeValidation();
	}

	private async void ProgressValidation()
	{

		bool timeExpired = false; // false

		await timeBar.ProgressTo(1, 60000, Easing.Linear);

		timeExpired = true;

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


	}

	int countQuestions = 0;
	int totalPoints = 0;
	bool isCorrect = false, marcou = false;

    async void btnNextQuestion_Clicked(System.Object sender, System.EventArgs e)
    {

        if (countQuestions == 1)
		{
			imgQuestion.Source = "question2_flag";

			ans1.Content = "England";
			ans3.Content = "Saudi Arabia";
			ans2.Content = "Germany";
			ans4.Content = "Japan";

			ans1.Value = "wrong";
			ans3.Value = "correct";
			ans2.Value = "wrong";
			ans4.Value = "wrong";


		}else if (countQuestions == 2)
		{
            imgQuestion.Source = "question3_flag";

            ans1.Content = "Tanzania";
            ans2.Content = "Italy";
            ans3.Content = "Colombia";
            ans4.Content = "England";

            ans1.Value = "wrong";
            ans2.Value = "wrong";
            ans3.Value = "wrong";
            ans4.Value = "correct";
        }
        else if (countQuestions == 3)
        {
            imgQuestion.Source = "question4_flag";

            ans1.Content = "Kenya";
            ans2.Content = "South Korea";
            ans3.Content = "Poland";
            ans4.Content = "Argentina";

            ans1.Value = "correct";
            ans2.Value = "wrong";
            ans3.Value = "wrong";
            ans4.Value = "wrong";
        }
        else if (countQuestions == 4)
        {
            imgQuestion.Source = "question5_flag";

            ans1.Content = "Canada";
            ans2.Content = "Qatar";
            ans3.Content = "Ghana";
            ans4.Content = "Nepal";

            ans1.Value = "wrong";
            ans2.Value = "correct";
            ans3.Value = "wrong";
            ans4.Value = "wrong";

			
        }else if(countQuestions == 5)
		{
            await SecureStorage.SetAsync("totalPoints", totalPoints.ToString());

            await Navigation.PushAsync(new ReportPage());
        }

        countQuestions++;

        if (isCorrect)
		{
			totalPoints++;
		}

    }

    private void verificarResposta(System.Object sender, System.EventArgs e)
	{
		if (marcou)
		{
			marcou = false;
		}
		else
		{
			RadioButton opcao = sender as RadioButton;
			string valorOpcao = opcao.Value.ToString();

			if (valorOpcao.Contains("correct"))
			{
				isCorrect = true;
			}
			else
			{
				isCorrect = false;
			}

			marcou = true;
		}
        
    }
}