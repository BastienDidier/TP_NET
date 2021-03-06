﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class Client : Form
    {
        private RemotingObjects.IRemoteObject remoteObject;
        public Client()
        {
            try
            {
                TcpChannel channel = new TcpChannel();
                System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, true);
                remoteObject = (RemotingObjects.IRemoteObject)Activator.GetObject(typeof(RemotingObjects.IRemoteObject), "tcp://localhost:12000/HostObject");

            }
            catch
            {
                MessageBox.Show("Error connecting to the server");
            }

            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(remoteObject != null)
            {
                String result = remoteObject.sayHello(textBox1.Text);
                MessageBox.Show("Result: " + result);

            }
            else
            {
                MessageBox.Show("Error remote object not available");
            }
        }
    }
}
