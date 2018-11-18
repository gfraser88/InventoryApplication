using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Graeme Fraser
namespace ItemInfoStructure
{
    public partial class FrmItemInfo : Form
    {
        public FrmItemInfo()
        {
            InitializeComponent();
        }

        List<Item> items = new List<Item>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item();

                item.ItemNumber = int.Parse(txtNumber.Text);
                item.ItemPrice = double.Parse(txtPrice.Text);
                item.ItemDescription = txtDescription.Text;

                items.Add(item);

                txtNumber.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
                txtNumber.Focus();
            }

            catch(FormatException)
            {
                MessageBox.Show("Invalid Input", "Error");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            StringBuilder display = new StringBuilder();

            foreach(Item i in items)
            {
                display.Append("Item Number: " + i.ItemNumber + "\nItem Price: " + i.ItemPrice + "\nItem Description: " + i.ItemDescription + "\n\n");
            }

            MessageBox.Show(display.ToString(), Item.StoreName);
        }
    }

    public struct Item
    {
        public const string StoreName = "SportChek";
        private int number;
        private double price;
        private string description;

        public int ItemNumber
        {
            get { return number; }
            set { number = value; }
        }

        public double ItemPrice
        {
            get { return price; }
            set { price = value; }
        }

        public string ItemDescription
        {
            get { return description; }
            set { description = value; }
        }

    }
}
