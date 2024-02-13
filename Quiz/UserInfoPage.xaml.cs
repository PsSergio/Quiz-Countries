namespace Quiz;

public partial class UserInfoPage : ContentPage
{
	public UserInfoPage()
	{
		InitializeComponent();
	}

    async void btnUser_Clicked(System.Object sender, System.EventArgs e)
    {

        if (nameUser.Text == null || ageUser.Text == null || ageUser.Text == "" || nameUser.Text == "") 
        {

            framaAge.BorderColor = Colors.Red;
            frameName.BorderColor = Colors.Red;

        }
        else
        {
            framaAge.BorderColor = Color.FromHex("#2F2F2F");
            frameName.BorderColor = Color.FromHex("#2F2F2F");

            string name = nameUser.Text;

            int age = (int)float.Parse(ageUser.Text);

            if (age > 100 || age < 3)
            {

                framaAge.BorderColor = Colors.Red;

            }else
            {

                await SecureStorage.SetAsync("nameUser", name); // armazenando localmente - (atributo, variável )

                await SecureStorage.SetAsync("ageUser", age.ToString());

                await Navigation.PushAsync(new InfoPage());


            }

        }

    }
}
