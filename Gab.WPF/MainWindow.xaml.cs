using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Gab.WPF
{
    public partial class MainWindow
    {
        public Token Token { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate the dialog box
            var dlg = new LoginDialog();

            // Configure the dialog box
            dlg.Owner = this;
            // dlg.DocumentMargin = this.documentTextBox.Margin;

            dlg.Closed += Dlg_Closed;

            // Open the dialog box modal mode 
            dlg.ShowDialog();
        }

        private async void Dlg_Closed(object sender, EventArgs e)
        {
            var user = await UserDetails(Token);

            Dispatcher.Invoke(() =>
            {
                Avatar.Source = new BitmapImage(new Uri(user.PictureUrl));
                UserName.Text = $"@{user.Username}";
                Name.Text = $"{user.Name}";
            }, DispatcherPriority.Normal);
        }

        public async Task<User> UserDetails(Token token)
        {
            var url = "https://api.gab.com/v1.0/me/";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var json = await httpClient.GetStringAsync(url);

            var serializer = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.DeserializeObject<User>(json, serializer);
        }
    }
}
