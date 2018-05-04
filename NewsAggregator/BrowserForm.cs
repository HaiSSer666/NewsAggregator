using System;
using System.Windows.Forms;

namespace NewsAggregator
{
    public delegate void WebBrowserCallback(Uri uri);

    public partial class BrowserForm : Form
    {
        public WebBrowserCallback webBrowserCallback;

        public BrowserForm(Uri uri)
        {
            InitializeComponent();
            this.webBrowser.Navigate(uri);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowserCallback(e.Url);//FaceBookmanager.GetToken(e.Url)
        }
    }
}
