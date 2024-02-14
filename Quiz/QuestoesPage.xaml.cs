
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

		while(!IsTimeOut)
		{

			minutes -= 1;

			seconds = 59;

			while(seconds != 0)
			{

				seconds -= 1;

				if(seconds >= 10)
				{
                    labelTime.Text = minutes + ":" + seconds;
                }else
				{
                    labelTime.Text = minutes + ":" + "0" + seconds;

                }

                await Task.Delay(1000);

			}

			if(minutes == 0)
			{
				IsTimeOut = true;
			}

		}


	}

    void btnNextQuestion_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void RadioButton_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
    }


}
