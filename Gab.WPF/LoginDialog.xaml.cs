using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Gab.WPF
{
    public partial class LoginDialog
    {
        string clientId = "< Your Client Id >";
        string clientSecret = "< Your Client Secret >";
        string callbackUrl = "< Your Callback URL >";

        string scopes = "read engage-user engage-post write-post notifications";

        public LoginDialog()
        {
            InitializeComponent();
  
            var startUri = new Uri($"https://api.gab.com/oauth/authorize?response_type=code&client_id={clientId}&redirect_uri={callbackUrl}&scope={scopes}");
             
            this.Browser.ScriptErrorsSuppressed = true;
            this.Browser.Navigated += Browser_Navigated;
            this.Browser.Navigate(startUri);
        }

        private async void Browser_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        { 
            if (e.Url.PathAndQuery.Contains("code="))
            { 
                var code = e.Url.PathAndQuery.Split('=').Last();

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

                ((MainWindow)Owner).Token = token;


                this.Close();
            }
        } 
    }
}
