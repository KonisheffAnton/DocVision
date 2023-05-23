using MailSaver.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            this.GetAllMails();
        }

        private async void GetAllMails()
        {
            var response = await client.GetAsync("GetAllMails");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mailList = JsonConvert.DeserializeObject<List<MailModel>>(content);
                dgMails.ItemsSource = mailList;
            }
            else
            {
                lblMessage.Content = "Error retrieving mails";
            }
        }

        private async void SaveMail(MailModel mailmodel)
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

        private async void UpdateMail(MailModel mailmodel)
        {
            try
            {
                var response = await client.PutAsJsonAsync("UpdateMail/" + mailmodel.Id, mailmodel);
                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Content = "Mail Updated";
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

        private async void DeleteMailAsync(Guid? mailId)
        {
            try
            {
                var response = await client.DeleteAsync("DeleteMail/" + mailId.ToString());
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
            MailModel mail = ((FrameworkElement)sender).DataContext as MailModel;
            this.DeleteMailAsync(mail.Id);
        }

        private void btnSaveMail_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();

            var mail = new MailModel()
            {
                Name = txtMailName.Text,
                Sender = txtSender.Text,
                Addressee = txtReciever.Text,
                Data = dpMailDate.SelectedDate,
                Content = txtMailContent.Text
            };

            if (string.IsNullOrEmpty(txtMailId.Text))
            {
                mail.Id = Guid.NewGuid();
                this.SaveMail(mail);
            }
            else
            {
                mail.Id = Guid.Parse(txtMailId.Text.Trim());
                this.UpdateMail(mail);
            }

            ClearFields();
        }

        void btnEditMail_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();

            MailModel mail = ((FrameworkElement)sender).DataContext as MailModel;

            txtMailId.Text = mail.Id.ToString();
            txtSender.Text = mail.Sender;
            txtReciever.Text = mail.Addressee;
            dpMailDate.SelectedDate = mail.Data;
            txtMailContent.Text = mail.Content;
        }

        private void ClearFields()
        {
            txtMailId.Text = "";
            txtSender.Text = "";
            txtReciever.Text = "";
            dpMailDate.SelectedDate = DateTime.Today;
            txtMailContent.Text = "";
        }

    }
}
