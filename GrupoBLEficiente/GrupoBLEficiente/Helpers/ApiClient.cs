namespace GrupoBLEficiente.Helpers
{
    public class GrupoBLEficienteAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5151");
            return Client;
        }
    }
}
