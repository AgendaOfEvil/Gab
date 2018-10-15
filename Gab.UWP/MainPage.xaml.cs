using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;

namespace Gab.UWP
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                LoginButton.IsEnabled = false;
                LoginButton.Content = "Authorizing";
            });
             
            var clientId = "< Your Client Id >";
            var clientSecret = "< Your Client Secret >";
            var callbackUrl = "< Your Callback URL >";

            // scoped separated by a 'space'
            var scopes = "read engage-user engage-post write-post notifications";
              
            var startUri = new Uri($"https://api.gab.com/oauth/authorize?response_type=code&client_id={clientId}&redirect_uri={callbackUrl}&scope={scopes}");
            // When using the desktop flow, the success code is displayed in the html title of this end uri
            var endUri = new Uri(callbackUrl);


            var webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);
            if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var res = webAuthenticationResult.ResponseData;

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    LoginButton.Content = "Getting Access Token";
                });

                var code = res.Split('=').Last();

                var client = new HttpClient();

                var parameters = new List<KeyValuePair<string, string>>();

                parameters.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                parameters.Add(new KeyValuePair<string, string>("code", code));
                parameters.Add(new KeyValuePair<string, string>("client_id", clientId));
                parameters.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                parameters.Add(new KeyValuePair<string, string>("redirect_uri", callbackUrl));

                var content = new FormUrlEncodedContent(parameters);

                var url = "https://api.gab.com/oauth/token";

                var tokenRes = await client.PostAsync(url, content);

                var json = await tokenRes.Content.ReadAsStringAsync();

                var token = JsonConvert.DeserializeObject<Token>(json);
                 
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    LoginButton.Content = "Getting User Data";
                });
                 
                var user = await UserDetails(token);

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    LoginButton.Content = "Success";
                    Avatar.Source = new BitmapImage(new Uri(user.PictureUrl));
                    UserName.Text = $"@{user.Username}";
                    Name.Text = $"{user.Name}";
                });
            }
            else if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {
                var x = "HTTP Error returned by AuthenticateAsync() : " + webAuthenticationResult.ResponseErrorDetail;
            }
            else
            {
                var x = "Error returned by AuthenticateAsync() : " + webAuthenticationResult.ResponseStatus;
            }
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