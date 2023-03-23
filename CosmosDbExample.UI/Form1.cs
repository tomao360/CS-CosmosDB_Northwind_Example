using CosmosDbExample.BusinessLogic;

namespace CosmosDbExample.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            await MainManager.Instance.products.CreatDbAndInsertData();
            MessageBox.Show("The import finished sucessfully");
        }

        private async void btnPriceCheaper_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var productsList = await MainManager.Instance.products.SelectProductsByPrice(textBoxPrice.Text);
            foreach (var product in productsList)
            {
                listBox1.Items.Add(product.ProductName + Environment.NewLine);
            }
            textBoxPrice.Text = "";
        }

        private async void btnSupplier_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var productsList = await MainManager.Instance.products.SelectProductsBySupplier(textBoxSupplier.Text);
            foreach (var product in productsList)
            {
                listBox1.Items.Add(product.ProductName + Environment.NewLine);
            }
            textBoxSupplier.Text = "";
        }

        private async void btnProductName_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var productsList = await MainManager.Instance.products.SelectProductsByStartName(textBoxProductName.Text);
            foreach (var product in productsList)
            {
                listBox1.Items.Add(($"ID: {product.ProductID}, Product Name: {product.ProductName}  {Environment.NewLine}"));
            }
            textBoxProductName.Text = "";
        }
    }
}