using DropNet;
using DropNet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudKeysController
{

    public static class DropboxMgr
    {
        const string _apiKey = "1pv9j6cmhonclul";
        const string _apiSecret = "v46aehha20oum1n";
        const string _callbackURL = "https://www.dropbox.com/1/oauth/authorize_submit";
        const string _cancelCallbackURL = "https://www.dropbox.com/home";
        static public DropNetClient Client = new DropNetClient(_apiKey, _apiSecret);
        static Size _dropboxAuthFormSize = new Size(1024, 600);

        public static void init(string token, string secret)
        {
            Client.GetToken();
            Client.UserLogin = new UserLogin() { Token = token, Secret = secret };
        }

        public static DialogResult DoOAuth()
        {
            Size size = _dropboxAuthFormSize;
            using (var dialog = new Form())
            {
                WebBrowser browesr = new WebBrowser()
                {
                    Dock = DockStyle.Fill
                };
                string authUrl = Client.BuildAuthorizeUrl();
                // Event handler
                browesr.Navigated += (s, ex) =>
                {
                    var url = ex.Url.ToString();
                    if (url.Equals(_callbackURL))
                    {
                        dialog.DialogResult = DialogResult.OK;
                    }
                    else if (url.Equals(_cancelCallbackURL))
                    {
                        dialog.DialogResult = DialogResult.Cancel;
                    }
                };
                browesr.Navigate(authUrl);

                dialog.Size = size;
                dialog.Controls.Add(browesr);
                dialog.StartPosition = FormStartPosition.CenterParent;
                return dialog.ShowDialog();
            }
        }

        public static byte[] ReadFileFromCloud(string url)
        {
            byte[] bytesFromCloud = Client.GetFile(url);
            byte[] plainBytes = CryptoHelper.Decrypt(bytesFromCloud);
            return plainBytes;
        }

        public static string WriteToCloud(string path, byte[] content)
        {
            byte[] cipherBytes = CryptoHelper.Encrypt(content);
            var uploaded = Client.UploadFile("CloudKeys", path, cipherBytes); //FileInfo
            return uploaded.Path;
        }

        public static string DownloadFileFromCloud(string filename)
        {
            //var meta = Client.Search(filename);
            //string path = meta[0].Path;
            string path = filename;

            byte[] bytesFromCloud = Client.GetFile(path);
            string tempPath = System.IO.Path.GetTempPath();
            string tgtPath = tempPath + "cloudkeys_temp" + DateTime.Now.ToString("yyyyMMddhhmmss");
            System.IO.FileStream _FileStream = new System.IO.FileStream(tgtPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(bytesFromCloud, 0, bytesFromCloud.Length);
            // close file stream
            _FileStream.Close();

            return tgtPath;
        }

        public static string UploadFileToCloud(string filename, byte[] content)
        {
            var uploaded = Client.UploadFile("CloudKeys", filename, content); //FileInfo

            return uploaded.Path;
        }

        public static bool IsTokenValid()
        {
            /* Check if token is valid
             AccountInfo info;
            try
            {
                info = _client.AccountInfo();
                MessageBox.Show(info.email + "\n" + info.display_name);
            }
            catch (DropNet.Exceptions.DropboxException ex)
            {
                MessageBox.Show(ex.Response.Content);
                //_client = new DropNetClient(_apiKey, _apiSecret);
                //_client.GetToken();
                //_client.UseSandbox = true;
                _client.UserLogin = new UserLogin();
                
                //_client.UserLogin.Token = "";
                OnFileOpen(sender, e);
                return;
            }
            finally
            {

            }
              
             */
            //_client.UseSandbox = true;
            return true;
        }

    }
}
