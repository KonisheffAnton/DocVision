using MailSaver.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace MailSaver
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:44368/api/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
            ClearFields();
        }

        private void MailLoaderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.GetAllMailsAsync();
        }

        private async void GetAllMailsAsync()
        {
            var response = await client.GetAsync("GetAllMailsAsync");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mailList = JsonConvert.DeserializeObject<List<MailModel>>(content);
                dgMails.ItemsSource = mailList;
            }
            else
            {
                lblMessage.Content = "Failed to retrieve mail data.";
            }
        }

        private async void SaveMailAsync(MailModel mailmodel)
        {
            try
            {
                var response = await client.PostAsJsonAsync("CreateMail", mailmodel);
                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Content = "Mail Created";
                }
                else
                {
                    lblMessage.Content = "Api Error Creating mail";
                }
            }
            catch
            {
                lblMessage.Content = "WPF Error Creating mail";
            }
        }

        private async void UpdateMailAsync(MailModel mailmodel)
        {
            try
            {
                var response = await client.PutAsJsonAsync("UpdateMailAsync", mailmodel);
                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Content = "Mail Updated";
                    GetAllMailsAsync();
                }
                else
                {
                    lblMessage.Content = "Api Error Updating mail";
                }
            }
            catch
            {
                lblMessage.Content = "WPF Error Updating mail";
            }
        }

        private async void DeleteMailAsync(MailModel mailModel)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, "DeleteMail");
                request.Content = new StringContent(JsonConvert.SerializeObject(mailModel), Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Content = "Mail Deleted";
                }
                else
                {
                    lblMessage.Content = "Api Error deleting mail";
                }
            }
            catch
            {
                lblMessage.Content = "WPF Error deleting mail";
            }
        }

        private void btnDeleteMail_Click(object sender, RoutedEventArgs e)
        {
            MailModel mailModel = ((FrameworkElement)sender).DataContext as MailModel;
            this.DeleteMailAsync(mailModel);
        }

        private void btnSaveMail_Click(object sender, RoutedEventArgs e)
        {
            var mailModel = new MailModel()
            {
                Name = txtMailName.Text,
                Sender = txtSender.Text,
                Addressee = txtReciever.Text,
                Data = dpMailDate.SelectedDate,
                Content = txtMailContent.Text
            };

            if (string.IsNullOrEmpty(txtMailId.Text))
            {
                mailModel.Id = Guid.NewGuid();
                this.SaveMailAsync(mailModel);
            }
            else
            {
                mailModel.Id = Guid.Parse(txtMailId.Text.Trim());
                this.UpdateMailAsync(mailModel);
            }

            ClearFields();
        }

        void btnEditMail_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();

            MailModel mail = ((FrameworkElement)sender).DataContext as MailModel;

            txtMailId.Text = mail.Id.ToString();
            txtMailName.Text = mail.Name;
            txtSender.Text = mail.Sender;
            txtReciever.Text = mail.Addressee;
            dpMailDate.SelectedDate = mail.Data;
            txtMailContent.Text = mail.Content;
        }

        private void ClearFields()
        {
            txtMailId.Text = "";
            txtMailName.Text = "";
            txtSender.Text = "";
            txtReciever.Text = "";
            dpMailDate.SelectedDate = DateTime.Today;
            txtMailContent.Text = "";
        }

    }
}
