/*
 *   WakeOnLAN - Wake On LAN
 *    Copyright (C) 2004-2016 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AutoUpdaterDotNET
{
    public class AutoUpdateEventArgs : EventArgs
    {
        public enum StatusCodes
        {
            idle,
            checking,
            updateAvailable,
            noUpdateAvailable,
            delayed,
            error
        }

        public StatusCodes Status;
        public string Text;
    }

    /// <summary>
    /// Main class that lets you auto update applications by setting some static fields and executing its Start method.
    /// </summary>
    public static class AutoUpdater
    {
        internal static String DialogTitle;
        internal static String ChangeLogURL;
        internal static String DownloadURL;
        internal static String RegistryLocation;
        internal static String AppTitle;
        internal static Version CurrentVersion;
        internal static Version InstalledVersion;

        public delegate void UpdateStatusHandler(object sender, AutoUpdateEventArgs e);
        public static event UpdateStatusHandler UpdateStatus;

        public static void OnUpdateStatus(AutoUpdateEventArgs e)
        {
            if (UpdateStatus != null)
                UpdateStatus(null, e);  // this, e
        }

        /// <summary>
        /// URL of the xml file that contains information about latest version of the application.
        /// </summary>
        /// 
        public static String AppCastURL;

        /// <summary>
        /// Opens the download url in default browser if true. Very useful if you have portable application.
        /// </summary>
        public static bool OpenDownloadPage = false;

        /// <summary>
        /// Sets the current culture of the auto update notification window. Set this value if your application supports functionalty to change the languge of the application.
        /// </summary>
        public static CultureInfo CurrentCulture;

        /// <summary>
        /// If this is true users see dialog where they can set remind later interval otherwise it will take the interval from RemindLaterAt and RemindLaterTimeSpan fields.
        /// </summary>
        public static Boolean LetUserSelectRemindLater = true;

        /// <summary>
        /// Remind Later interval after user should be reminded of update.
        /// </summary>
        public static int RemindLaterAt = 2;

        /// <summary>
        /// Set if RemindLaterAt interval should be in Minutes, Hours or Days.
        /// </summary>
        public static RemindLaterFormat RemindLaterTimeSpan = RemindLaterFormat.Days;

        /// <summary>
        /// Read this webpage to get extended version information.
        /// </summary>
        public static String versionURL;
        public static String versionResult;

        public enum RemindLaterFormat
        {
            Minutes,
            Hours,
            Days
        }

        /// <summary>
        /// Start checking for new version of application and display dialog to the user if update is available.
        /// </summary>
        /// <param name="days">Number of days to wait between automatic checks.</param>
        public static void Start(int days)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorkerDoWork;
            backgroundWorker.RunWorkerAsync(days);
        }

        private static void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int compareResult;
            AutoUpdateEventArgs args = new AutoUpdateEventArgs();

            Thread.CurrentThread.CurrentUICulture = CurrentCulture;
            var mainAssembly = Assembly.GetEntryAssembly();
            var companyAttribute = (AssemblyCompanyAttribute)GetAttribute(mainAssembly, typeof(AssemblyCompanyAttribute));
            var titleAttribute = (AssemblyTitleAttribute)GetAttribute(mainAssembly, typeof(AssemblyTitleAttribute));
            AppTitle = titleAttribute != null ? titleAttribute.Title : mainAssembly.GetName().Name;
            var appCompany = companyAttribute != null ? companyAttribute.Company : "";
            int days = (int)e.Argument;

            RegistryLocation = string.Format(@"Software\{0}\{1}\AutoUpdater", appCompany, AppTitle);

            RegistryKey updateKey = Registry.CurrentUser.OpenSubKey(RegistryLocation, true) ??
                                    Registry.CurrentUser.CreateSubKey(RegistryLocation);

            object remindLaterTime = updateKey.GetValue("remindlater");
            if (remindLaterTime == null && days > 0)
            {
                string lastcheck = updateKey.GetValue("lastcheck", "").ToString();
                if (!String.IsNullOrEmpty(lastcheck))
                {
                    try
                    {
                        DateTime lastcheckDate = Convert.ToDateTime(lastcheck, CultureInfo.InvariantCulture);
                        compareResult = DateTime.Compare(DateTime.Now, lastcheckDate.AddDays(days));

                        if (compareResult < 0)
                        {
                            args.Status = AutoUpdateEventArgs.StatusCodes.delayed;
                            args.Text = string.Format(Strings.sLastCheck, lastcheckDate.ToString("D", CurrentCulture));
                            OnUpdateStatus(args);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            if (remindLaterTime != null && days > 0)
            {
                try
                {
                    DateTime remindLater = Convert.ToDateTime(remindLaterTime.ToString(), CultureInfo.InvariantCulture);

                    compareResult = DateTime.Compare(DateTime.Now, remindLater);

                    if (compareResult < 0)
                    {
                        var updateForm = new UpdateForm(true);
                        updateForm.SetTimer(remindLater);
                        return;
                    }
                }
                catch (Exception)
                {
                }
            }

            if (remindLaterTime != null)
                updateKey.DeleteValue("remindlater");

            InstalledVersion = mainAssembly.GetName().Version;

            args.Status = AutoUpdateEventArgs.StatusCodes.checking;
            args.Text = Strings.sCheckingForUpdates;
            OnUpdateStatus(args);
            WebRequest webRequest = WebRequest.Create(AppCastURL);
            webRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            WebResponse webResponse;

            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch (Exception ex)
            {
                args.Status = AutoUpdateEventArgs.StatusCodes.error;
                args.Text = ex.Message;
                OnUpdateStatus(args);
                return;
            }

            Stream appCastStream = webResponse.GetResponseStream();

            var receivedAppCastDocument = new XmlDocument();

            if (appCastStream != null) receivedAppCastDocument.Load(appCastStream);
            else return;

            XmlNodeList appCastItems = receivedAppCastDocument.SelectNodes("channel/item");

            if (appCastItems != null)
            {
                foreach (XmlNode item in appCastItems)
                {
                    XmlNode appCastVersion = item.SelectSingleNode("version");
                    if (appCastVersion != null)
                    {
                        String appVersion = appCastVersion.InnerText;
                        var version = new Version(appVersion);
                        if (version <= InstalledVersion)
                            continue;
                        CurrentVersion = version;
                    }
                    else
                        continue;

                    XmlNode appCastTitle = item.SelectSingleNode("title");

                    DialogTitle = appCastTitle != null ? appCastTitle.InnerText : "";

                    XmlNode appCastChangeLog = item.SelectSingleNode("changelog");

                    ChangeLogURL = appCastChangeLog != null ? appCastChangeLog.InnerText : "";

                    XmlNode appCastUrl = item.SelectSingleNode("url");

                    DownloadURL = appCastUrl != null ? appCastUrl.InnerText : "";
                }
            }

            object skip = updateKey.GetValue("skip");
            object applicationVersion = updateKey.GetValue("version");
            if (skip != null && applicationVersion != null)
            {
                string skipValue = skip.ToString();
                var skipVersion = new Version(applicationVersion.ToString());
                if (skipValue.Equals("1") && CurrentVersion <= skipVersion)
                {
                    args.Status = AutoUpdateEventArgs.StatusCodes.noUpdateAvailable;
                    args.Text = Strings.sSkipping;
                    OnUpdateStatus(args);
                    return;
                }
                if (CurrentVersion > skipVersion)
                {
                    RegistryKey updateKeyWrite = Registry.CurrentUser.CreateSubKey(RegistryLocation);
                    if (updateKeyWrite != null)
                    {
                        updateKeyWrite.SetValue("version", CurrentVersion.ToString());
                        updateKeyWrite.SetValue("skip", 0);
                    }
                }
            }

            updateKey.SetValue("lastcheck", DateTime.Now.ToString(CultureInfo.InvariantCulture));
            updateKey.Close();
            RunBrowserThread(versionURL);

#if DEBUG
            if (days == -1)
            {
                args.Status = AutoUpdateEventArgs.StatusCodes.updateAvailable;
                args.Text = Strings.sUpdateAvailable;
                OnUpdateStatus(args);

                var thread = new Thread(ShowUI);
                thread.CurrentCulture = thread.CurrentUICulture = CurrentCulture ?? Application.CurrentCulture;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
#endif

            if (CurrentVersion == null)
            {
                args.Status = AutoUpdateEventArgs.StatusCodes.noUpdateAvailable;
                args.Text = Strings.sLatestVersion;
                OnUpdateStatus(args);
                return;
            }

            if (CurrentVersion <= InstalledVersion) return;
            args.Status = AutoUpdateEventArgs.StatusCodes.updateAvailable;
            args.Text = Strings.sUpdateAvailable;
            OnUpdateStatus(args);

            if (days == 0)
            {
                var thread = new Thread(ShowUI);
                thread.CurrentCulture = thread.CurrentUICulture = CurrentCulture ?? Application.CurrentCulture;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private static void RunBrowserThread(String url)
        {
            var th = new Thread(() =>
            {
                var br = new WebBrowser();
                br.DocumentCompleted += browser_DocumentCompleted;

                /*
                // Convert the string into a byte array
                ASCIIEncoding Encode = new ASCIIEncoding();
                byte[] postData = Encode.GetBytes("version=1.2");

                // The same Header that its sent when you submit a form.
                String postHeaders = "User-Agent: Mozilla; WOL 1.1\r\nContent-Type: application/x-www-form-urlencoded\r\n";

                br.Navigate(url, null, postData, postHeaders);
                */
                br.Navigate(url);
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        static void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
            if (br.Url == e.Url)
            {
                System.Diagnostics.Debug.WriteLine("Navigated to {0}\r\n{1}", e.Url, br.DocumentText);
                versionResult = br.DocumentText;
                Application.ExitThread();   // Stops the thread
            }
        }

        private static void ShowUI()
        {
            var updateForm = new UpdateForm();

            updateForm.ShowDialog();
        }

        private static Attribute GetAttribute(Assembly assembly, Type attributeType)
        {
            var attributes = assembly.GetCustomAttributes(attributeType, false);
            if (attributes.Length == 0)
            {
                return null;
            }
            return (Attribute)attributes[0];
        }
    }
}
