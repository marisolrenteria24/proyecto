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
    public partial class Form2 : Form
    {
        public List<Product> ListaExterna { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach(Product p in ListaExterna)
            {
                listBox1.DataSource = (ListaExterna);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Product p in ListaExterna)
            {
                if (textBox1.Text != p.Name)
                {
                    MessageBox.Show("El producto no está registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
        }
    }
}
