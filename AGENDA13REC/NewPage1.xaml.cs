namespace AGENDA13REC;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
        // Tela de cálculo pronta para uso
    }

    // Atualiza textos quando Stepper, Picker ou DatePicker mudam
    private void OnValueChanged(object sender, EventArgs e)
    {
        AdultosLabel.Text = $"{AdultosStepper.Value} adulto(s)";
        CriancasLabel.Text = $"{CriancasStepper.Value} criança(s)";
    }

    // Quando o usuário clica no botão de calcular
    private async void CalcularDiaria(object sender, EventArgs e)
    {
        // Verifica se a suíte foi escolhida
        if (SuitePicker.SelectedIndex == -1)
        {
            await DisplayAlertAsync("Erro", "Selecione uma suíte.", "OK");
            return;
        }

        // Garante que as datas foram selecionadas
        if (CheckInDate.Date is null || CheckOutDate.Date is null)
        {
            await DisplayAlertAsync("Erro", "Selecione datas válidas.", "OK");
            return;
        }

        // Check-out deve ser depois do check-in
        if (CheckOutDate.Date.Value <= CheckInDate.Date.Value)
        {
            await DisplayAlertAsync("Erro", "O check-out deve ser após o check-in.", "OK");
            return;
        }

        // Calcula número de dias
        int dias = (CheckOutDate.Date.Value - CheckInDate.Date.Value).Days;

        // Escolhe o preço da suíte conforme item selecionado
        double valorSuite = SuitePicker.SelectedIndex switch
        {
            0 => 150,
            1 => 300,
            2 => 500,
            _ => 0
        };

        int adultos = (int)AdultosStepper.Value;
        int criancas = (int)CriancasStepper.Value;

        // Crianças adicionam custo extra
        double valorTotal = (valorSuite * dias) + (criancas * 50);

        ResultadoLabel.Text = $"Valor total: R${valorTotal:F2}";
    }

    // Corrige o aviso de DisplayAlert obsoleto
    private Task DisplayAlertAsync(string title, string message, string button)
    {
        return DisplayAlert(title, message, button);
    }
}
