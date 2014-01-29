using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;

namespace Agent
{
    public partial class Service1 : ServiceBase
    {
        private BackgroundWorker backgroundworker;
        const int wolPort = 9;

        public Service1()
        {
            InitializeComponent();
            backgroundworker = new BackgroundWorker();
            backgroundworker.WorkerSupportsCancellation = true;
            backgroundworker.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        protected override void OnStart(string[] args)
        {
            backgroundworker.RunWorkerAsync();
        }

        protected override void OnStop()
        {
            backgroundworker.CancelAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            UdpClient udpReceiver = new UdpClient(wolPort);
            UdpClient udpSender = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

            Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();
            DateTime lastTime;
            string mac;

            udpSender.Connect("255.255.255.255", wolPort);
            udpSender.EnableBroadcast = true;

            while (worker.CancellationPending == false)
            {
                try
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref ep);

                    // verify that WOL packet

                    System.Diagnostics.Debug.WriteLine("received");

                    if (validPacket(receiveBytes))
                    {
                        // we have a valid packet

                        mac = BitConverter.ToString(receiveBytes, 6, 6);

                        if (list.TryGetValue(mac, out lastTime))
                        {
                            if ((DateTime.UtcNow - lastTime).TotalSeconds > 2)
                            {
                                list.Remove(mac);
                                list.Add(key: mac, value: DateTime.UtcNow);
                                System.Diagnostics.Debug.WriteLine("sent " + mac);
                                udpSender.Send(receiveBytes, receiveBytes.Length);
                            }
                        }
                        else
                        {
                            list.Add(key: mac, value: DateTime.UtcNow);
                            System.Diagnostics.Debug.WriteLine("sent " + mac);
                            udpSender.Send(receiveBytes, receiveBytes.Length);
                        }
                    }
                }

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }

            e.Cancel = true;
            return;
        
        }

        static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            IStructuralEquatable eqa1 = a1;
            return eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }

        private bool validPacket(byte[] receiveBytes)
        {
            if (receiveBytes.Length < 102)
                return false;

            for (int i = 0; i < 5; i++)
                if (receiveBytes[i] != 0xff) return false;

            for (int i = 1; i < 15; i++)
                for (int j = 0; j < 5; j++)
                    if (receiveBytes[6 + j] != receiveBytes[6 + j + (i * 6)]) return false;

            return true;
        }

    }

}
