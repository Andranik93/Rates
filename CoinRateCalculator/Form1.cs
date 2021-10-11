using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinRateCalculator
{
    public partial class Form1 : Form
    {
        HttpClient _client;
        string _baseUrl = string.Empty;
        public Form1()
        {
            InitializeComponent();
            _baseUrl = "http://api.exchangeratesapi.io";
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseUrl);        
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;
            try
            {
                decimal.TryParse(AmountBox.Text, out decimal amount);
                await Converts(amount, BoxFrom.Text, BoxTo.Text);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        private async Task Converts(decimal amount, string from, string to)
        {
            string request = $"/v1/convert?access_key=3bd914a770a42ab15d5a78638be5c109&from={from}&to={to}&amount={amount}";

            using (var response = await _client.GetAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                {
                    lblErrorMessage.Text = response.ReasonPhrase;
                }

                var jsonStr = await response.Content.ReadAsStringAsync();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
