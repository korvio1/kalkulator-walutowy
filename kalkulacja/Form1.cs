using System;
using System.Windows.Forms;

namespace Kalkulacja
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, decimal> PLNConversionRates = new Dictionary<string, decimal>
        {
            {"USD", 0.24m},
            {"EUR", 0.22m},
            {"RUB", 24.30m},
            {"THB", 8.34m}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = Convert.ToDecimal(txtAmount.Text);
                string fromCurrency = GetSelectedFromCurrency();
                string toCurrency = GetSelectedToCurrency();

                decimal result = ConvertCurrency(amount, fromCurrency, toCurrency);
                lblResult.Text = $"{amount} {fromCurrency} = {result:F2} {toCurrency}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d: {ex.Message}");
            }
        }

        private string GetSelectedFromCurrency()
        {
            if (rbtnFromPLN.Checked) return "PLN";
            if (rbtnFromUSD.Checked) return "USD";
            if (rbtnFromEUR.Checked) return "EUR";
            if (rbtnFromRUB.Checked) return "RUB";
            if (rbtnFromTHB.Checked) return "THB";
            return "PLN";
        }

        private string GetSelectedToCurrency()
        {
            if (rbtnToPLN.Checked) return "PLN";
            if (rbtnToUSD.Checked) return "USD";
            if (rbtnToEUR.Checked) return "EUR";
            if (rbtnToRUB.Checked) return "RUB";
            if (rbtnToTHB.Checked) return "THB";
            return "PLN";
        }

        private decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            if (fromCurrency != "PLN")
                amount = ConvertToPLN(amount, fromCurrency);

            if (toCurrency != "PLN")
                amount = ConvertFromPLN(amount, toCurrency);

            return amount;
        }

        private decimal ConvertToPLN(decimal amount, string fromCurrency)
        {
            return fromCurrency == "PLN" ? amount : amount / PLNConversionRates[fromCurrency];
        }

        private decimal ConvertFromPLN(decimal amount, string toCurrency)
        {
            return toCurrency == "PLN" ? amount : amount * PLNConversionRates[toCurrency];
        }
    }
}
