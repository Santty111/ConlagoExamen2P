namespace ConlagoExamen2P
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnConvertirClicked(object sender, EventArgs e)
        {
            // Verificar que se haya ingresado un valor y seleccionado unidades
            if (double.TryParse(valorEntrada.Text, out double valor) &&
                unidadOrigen.SelectedItem != null &&
                unidadDestino.SelectedItem != null)
            {
                string origen = unidadOrigen.SelectedItem.ToString();
                string destino = unidadDestino.SelectedItem.ToString();
                // Convertir el valor
                double resultadoConversion = ConvertirUnidad(valor, origen, destino);
                resultado.Text = $"Resultado: {resultadoConversion:F2}";
            }
            else
            {
                DisplayAlert("Error", "Por favor, ingrese un valor válido y seleccione las unidades.", "OK");
            }
        }
        private double ConvertirUnidad(double valor, string origen, string destino)
        {
            if (origen == destino)
                return valor;
            // Lógica de conversión entre unidades
            if (origen == "Metros/Segundo" && destino == "Kilómetros/Hora")
                return valor * 3.6;
            if (origen == "Metros/Segundo" && destino == "Millas/Hora")
                return valor * 2.23694;
            if (origen == "Kilómetros/Hora" && destino == "Metros/Segundo")
                return valor / 3.6;
            if (origen == "Kilómetros/Hora" && destino == "Millas/Hora")
                return valor * 0.621371;
            if (origen == "Millas/Hora" && destino == "Metros/Segundo")
                return valor / 2.23694;
            if (origen == "Millas/Hora" && destino == "Kilómetros/Hora")
                return valor / 0.621371;
            return valor;
        }
        private void OnLimpiarClicked(object sender, EventArgs e)
        {
            // Limpiar todos los campos
            valorEntrada.Text = string.Empty;
            resultado.Text = "Resultado:";
            unidadOrigen.SelectedIndex = -1;
            unidadDestino.SelectedIndex = -1;
        }
    }
}