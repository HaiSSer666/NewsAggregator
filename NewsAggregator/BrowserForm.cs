using System;
using System.Windows.Forms;

namespace NewsAggregator
{
    public partial class BrowserForm : Form
    {
        public BrowserForm(Uri uri)
        {
            InitializeComponent();
            this.webBrowser.Navigate(uri);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine(e.Url);
            callback();
        }
    }
}
