﻿namespace Quiz;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

    }

    async void btnCredits_Clicked(System.Object sender, System.EventArgs e)
    {

		await Navigation.PushAsync(new CreditsPage());

    }

    async void btnStart_Clicked(System.Object sender, System.EventArgs e)
    {

        await Navigation.PushAsync(new UserInfoPage());

    }
}


