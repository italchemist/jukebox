

namespace Jukebox.Extensions.TrackProviders.VkCom {
	using System.Text.RegularExpressions;
	using System;
	using System.Windows.Forms;

	public partial class AuthenticationForm : Form {
		public AuthenticationForm() {
			InitializeComponent();
		}

		private void AuthenticationForm_Load(object sender, EventArgs e) {
			webBrowser1.Navigate("https://oauth.vk.com/authorize?response_type=token&redirect_uri=vk.com&client_id=3431166&scope=8&display=page");
			webBrowser1.Navigated += WebBrowser1OnNavigated;
		}

		private void WebBrowser1OnNavigated(object sender, WebBrowserNavigatedEventArgs webBrowserNavigatedEventArgs) {
			var a = webBrowserNavigatedEventArgs.Url;
			if (!String.IsNullOrEmpty(a.Fragment)) {
				Regex r = new Regex("access_token=(.*)&expires_in");
				var access_token = r.Match(a.Fragment).Groups[1].Value;
				AccessToken = access_token;
				Close();
				/*
				var code = a.Fragment.Substring(6);
				var url = new Uri("https://api.vk.com/oauth/access_token?client_id=3431166&client_secret=Sifa33Xk0cWrSF4rnfz2&code=" + code.ToString());

				var request = WebRequest.Create(url) as HttpWebRequest;
				//request.Method = "POST";

				var responseStream = request.GetResponse().GetResponseStream();
				var content = "";

				using (var reader = new StreamReader(responseStream, Encoding.GetEncoding(1251))) {
					content = reader.ReadToEnd();
				}

				int b = 0;*/
			}
		}

		public string AccessToken;
	}
}
