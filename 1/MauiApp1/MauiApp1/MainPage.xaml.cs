using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private ExpenseViewModel ViewModel => BindingContext as ExpenseViewModel;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnAddExpenseClicked(object sender, EventArgs e)
    {
        ViewModel?.AddExpense();
    }
}
