using Frontend;

HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7167/")
};
Sistema sistema = new Sistema(cliente);
sistema.IniciarSistema();