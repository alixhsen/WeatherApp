namespace Weather
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        DateTime currentDateTime = DateTime.Now;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            _cityEntry.Text = "Beirut";
             currentDate.Text = currentDateTime.ToString("MMMM dd , hh:mmtt");

        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            string city = string.IsNullOrWhiteSpace(_cityEntry.Text) ? "Beirut" : _cityEntry.Text;
            WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestURL(Constants.OpenWeatherMapEndpoint, city));
            BindingContext = weatherData;
        }
        string GenerateRequestURL(string endPoint, string city)
        {
            string requestUri = endPoint;
            requestUri += $"?q={city}";
            requestUri += "&units=imperial";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
