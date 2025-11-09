namespace MauiApp1.Models;

public class Expense
{
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
