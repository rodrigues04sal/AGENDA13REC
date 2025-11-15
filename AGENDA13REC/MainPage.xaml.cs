namespace AGENDA13REC;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // A página inicial foi carregada com sucesso
    }

    // Navega para a tela "Sobre"
    private async void GoToSobre(object sender, EventArgs e)
    {
        // Navegação absoluta — funciona sempre
        await Shell.Current.GoToAsync("///sobre");
    }

    // Navega para a tela de cálculo de diária
    private async void GoToDiaria(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///diaria");
    }
}
