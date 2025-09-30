using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public List<Product> products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Code = textBox2.Text;
            int amount = int.Parse(textBox3.Text);

            foreach (Product p in products)
            {
                if (Name == p.Name || Code == p.Code)
                {
                    MessageBox.Show("El producto o código del producto ya están registrados","Alerta", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

            }
            Product product = new Product(Name, Code, amount);
            products.Add(product);

            MessageBox.Show("Producto guardado correctamente", "Nuevo mensaje");
            listBox1.Items.Add(product);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ListaExterna = products; 
            f2.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
