namespace TaskTracking;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        //указываем, что стартовая страница — MainPage
        MainPage = new MainPage();
    }
}