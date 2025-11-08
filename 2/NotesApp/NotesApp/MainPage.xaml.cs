using NotesApp.Models;

namespace NotesApp;

public partial class MainPage : ContentPage
{
    private List<Note> notes = new();

    public MainPage()
    {
        InitializeComponent();
        NotesList.ItemsSource = notes;
    }

    private void OnAddNoteClicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim() ?? "";
        string content = ContentEditor.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(content))
        {
            DisplayAlert("Ошибка", "Введите текст заметки", "OK");
            return;
        }

        notes.Add(new Note { Title = title, Content = content });
        NotesList.ItemsSource = null;
        NotesList.ItemsSource = notes;

        EmptyLabel.IsVisible = notes.Count == 0;

        TitleEntry.Text = "";
        ContentEditor.Text = "";
    }
}
