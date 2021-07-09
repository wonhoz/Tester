using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BlobTester
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string sasToken = "?sv=2020-02-10&ss=bfqt&srt=sco&sp=rwdlacuptfx&se=2021-12-30T20:51:11Z&st=2021-06-01T12:51:11Z&spr=https&sig=UfhLomrkzqSgC%2BAqFZLLn0yW5K2gV%2BVxME0vs%2BQXyUs%3D";


        public MainWindow()
        {
            InitializeComponent();
        }

        public void SystemLog(string logtext)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                SystemLogTextBox.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff ") + logtext + "\n");
                SystemLogTextBox.ScrollToEnd();
            }));
        }


        private CloudBlockBlob GetBlob(CloudStorageAccount account)
        {
            CloudBlobClient blobClient = account.CreateCloudBlobClient();

            string containerName = "btscontainer";
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync().Wait();

            string blobName = "1.3.12.2.1107.5.3.49.23056.11.201508111005100156.dcm";
            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

            return blob;
        }

        private async Task TransferLocalFileToAzureBlob(CloudStorageAccount account)
        {
            string localFilePath = @"D:\images\1.3.12.2.1107.5.3.49.23056.11.201508111005100156.dcm";
            CloudBlockBlob blob = GetBlob(account);
            SystemLog("Transfer started...");
            await Microsoft.Azure.Storage.DataMovement.TransferManager.UploadAsync(localFilePath, blob);
            SystemLog("Transfer operation complete.");
        }

        private async void TransferLocalFileToAzureBlobAsync(CloudStorageAccount account)
        {
            await TransferLocalFileToAzureBlob(account);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            StorageCredentials storageCredentials   = new StorageCredentials(sasToken);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, "gowixstorage", endpointSuffix: null, useHttps: true);

            TransferLocalFileToAzureBlobAsync(cloudStorageAccount);
        }
    }
}
