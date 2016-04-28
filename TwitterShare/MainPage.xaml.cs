using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwitterShare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataRequested;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Text = "TestMessage";
            ButtonClickCounter++;
            textBox.Text = "Button was clicked " + ButtonClickCounter + " times.";
            //System.Diagnostics.Debug.WriteLine("Clicked " + ButtonClickCounter + " times.");
            DataTransferManager.ShowShareUI();
        }
        static int ButtonClickCounter = 0;

        private static int DataRequestedCount = 0;

        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequestedCount++;
            textBox1.Text = "Data Requested " + DataRequestedCount + " times.";
            // System.Diagnostics.Debug.WriteLine("Data Requested " + DataRequestedCount + " times.");
            try
            {
                // TODO: Garth: Be more defensive
                DataRequest request = e.Request;
                request.Data.Properties.Title = "Share with your friends";
                request.Data.Properties.Description = "Hey Read This!";
                request.Data.SetText("Hey Read This!");            }
            catch (Exception)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }
        }
    }
}
