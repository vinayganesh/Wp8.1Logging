using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WriteToText.Resources;
using Windows.Storage;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Foundation.Diagnostics;
using System.Runtime.CompilerServices;

namespace WriteToText
{
    public partial class MainPage : PhoneApplicationPage
    {
        StorageFolder folder;
        StorageFile TimeLogFile;
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public MainPage()
        {
            InitializeComponent();

        }

        protected async override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            folder = KnownFolders.PicturesLibrary;
            TimeLogFile = await folder.CreateFileAsync("TimeLog.txt", CreationCollisionOption.OpenIfExists);
        }

        public async void WriteToLog()
        {
            await Windows.Storage.FileIO.WriteTextAsync(TimeLogFile, "Start Logging " + DateTime.Now.ToString() + Environment.NewLine);

            string[] a = { "windows", "phone", "8.1", "owns", "all" };

            for(int i = 0; i < a.Length; i ++)
            {
                await Windows.Storage.FileIO.AppendTextAsync(TimeLogFile, a[i] + " - " + DateTime.Now.ToString() + Environment.NewLine);
            }

            await Windows.Storage.FileIO.AppendTextAsync(TimeLogFile, "End Logging " + DateTime.Now.ToString() + Environment.NewLine);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteToLog();
        }

       public async void appendToLog(string text)
        {
            await Windows.Storage.FileIO.AppendTextAsync(TimeLogFile, text +" - " + DateTime.Now.ToString() + Environment.NewLine);
        }

       public async void writeToLog(string text)
       {
           await Windows.Storage.FileIO.WriteTextAsync(TimeLogFile, text + " - " + DateTime.Now.ToString() + Environment.NewLine);
       }

       private void btnLogException_Click(object sender, RoutedEventArgs e)
       {
           try
           {
               int a = 10;
               int b = 0;

               int c = a / b;
           }
           catch (Exception ex)
           {
               appendToLog(ex.Message);
           }
           

       }

       // Write data to a file
       public async void WriteTimestamp()
       {
          StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.log", CreationCollisionOption.ReplaceExisting);
          await FileIO.WriteTextAsync(sampleFile, DateTime.Now.ToString());
          MessageBox.Show("Done Writing");
       }

       // Read data from a file
       public async Task ReadTimestamp()
       {
           try
           {
               StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.log");
               String timestamp = await FileIO.ReadTextAsync(sampleFile);
               MessageBox.Show(timestamp);
               // Data is contained in timestamp
           }
           catch (Exception)
           {
               // Timestamp not found
           }
       }

       private void btnToLocalFolder_Click(object sender, RoutedEventArgs e)
       {
           WriteTimestamp();
       }

       private async void btnReadLocalFolder_Copy_Click(object sender, RoutedEventArgs e)
       {
           await ReadTimestamp();
       }

       public void sendError([CallerMemberName] string callerName = "")
       {
           MessageBox.Show("called by" + callerName);
       }

       private void btnTrace_Click(object sender, RoutedEventArgs e)
       {
           sendError();
       }

    }
}