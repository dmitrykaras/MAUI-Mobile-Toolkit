using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiApp1.Models;

namespace MauiApp1.ViewModels;

public class ExpenseViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Expense> Expenses { get; set; } = new();

    private string _category;
    public string Category
    {
        get => _category;
        set { _category = value; OnPropertyChanged(); }
    }

    private decimal _amount;
    public decimal Amount
    {
        get => _amount;
        set { _amount = value; OnPropertyChanged(); }
    }

    public decimal Total => Expenses.Sum(e => e.Amount);

    public void AddExpense()
    {
        if (!string.IsNullOrWhiteSpace(Category) && Amount > 0)
        {
            Expenses.Add(new Expense { Category = Category, Amount = Amount });
            OnPropertyChanged(nameof(Total));
            Category = string.Empty;
            Amount = 0;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
