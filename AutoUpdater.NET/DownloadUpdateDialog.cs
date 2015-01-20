/*
 *   WakeOnLAN - Wake On LAN
 *    Copyright (C) 2004-2015 Aquila Technology, LLC. <webmaster@aquilatech.com>
 *
 *    This file is part of WakeOnLAN.
 *
 *    WakeOnLAN is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *    WakeOnLAN is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *    GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License
 *    along with WakeOnLAN.  If not, see <http://www.gnu.org/licenses/>.
 */

/*
 *    This module originated from https://autoupdaterdotnet.codeplex.com/
 */

using System;
using System.ComponentModel;
using System.Net.Cache;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace AutoUpdaterDotNET
{
    internal partial class DownloadUpdateDialog : Form
    {
        private readonly string _downloadURL;

        private string _tempPath;

        public DownloadUpdateDialog(string downloadURL)
        {
            InitializeComponent();

            _downloadURL = downloadURL;
        }

        private void DownloadUpdateDialogLoad(object sender, EventArgs e)
        {
            var webClient = new WebClient();

            var uri = new Uri(_downloadURL);

            _tempPath = string.Format(@"{0}{1}", Path.GetTempPath(), GetFileName(_downloadURL));

            webClient.DownloadProgressChanged += OnDownloadProgressChanged;

            webClient.DownloadFileCompleted += OnDownloadComplete;

            webClient.DownloadFileAsync(uri, _tempPath);
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            var processStartInfo = new ProcessStartInfo {FileName = _tempPath, UseShellExecute = true};
            Process.Start(processStartInfo);
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        private static string GetFileName(string url)
        {
            var fileName = string.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            httpWebRequest.UserAgent = "AutoUpdater";
            httpWebRequest.Method = "HEAD";
            httpWebRequest.AllowAutoRedirect = true;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode.Equals(HttpStatusCode.Redirect) || httpWebResponse.StatusCode.Equals(HttpStatusCode.Moved) || httpWebResponse.StatusCode.Equals(HttpStatusCode.MovedPermanently))
            {
                if (httpWebResponse.Headers["Location"] != null)
                {
                    var location = httpWebResponse.Headers["Location"];
                    fileName = GetFileName(location);
                    return fileName;
                }
            }
            if (httpWebResponse.Headers["content-disposition"] != null)
            {
                var contentDisposition = httpWebResponse.Headers["content-disposition"];
                if (!string.IsNullOrEmpty(contentDisposition))
                {
                    const string lookForFileName = "filename=";
                    var index = contentDisposition.IndexOf(lookForFileName, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                        fileName = contentDisposition.Substring(index + lookForFileName.Length);
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Substring(1, fileName.Length - 2);
                    }
                }
            }
            if (string.IsNullOrEmpty(fileName))
            {
                var uri = new Uri(url);

                fileName = Path.GetFileName(uri.LocalPath);
                //
                // for sourceforge, change "download" to actual executable filename
                //
                if (fileName == "download")
                {
                    fileName = Path.GetFileName(url.Substring(0, url.LastIndexOf('/')));
                }
            }
            return fileName;
        }

    }
}
