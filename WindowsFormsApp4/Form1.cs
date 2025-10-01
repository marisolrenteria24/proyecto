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

        private void button2_Click(object sender, EventArgs e) //Boton de guardar producto
        {
            string Name = textBox1.Text;
            string Code = textBox2.Text;
            int amount = int.Parse(textBox3.Text);

            foreach (Product p in products)
            {
                if (Name == p.Name || Code == p.Code) //verifica que en exista el producto en la lista de productos
                {
                    MessageBox.Show("El producto o código del producto ya están registrados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            Product.Productos.Add(new Product{Name = textBox1.Text, Code = textBox2.Text, Price = double.Parse(textBox3.Text)}); //Crea el objeto producto y lo agrega a la lista

            MessageBox.Show("Producto guardado correctamente", "Nuevo mensaje");
            listBox1.DataSource = null;
            listBox1.DataSource = Product.Productos; //Despliega la lista de productos existentes segun lista global
            textBox1.Clear(); //Limpia los textbox para agregar otro producto rápidamente
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e) //Boton para abrir la vista de cajero
        {
            Form2 f2 = new Form2(); //Declaramos un nuevo form
            
            f2.Show(); //se muestra el formulario 2
            this.Hide(); //se oculta el formulario 1

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) //Evento de cargar el formulario
        {
            listBox1.DataSource = null; 
            listBox1.DataSource = Product.Productos; //Se despliega la lista de productos al cargar el formulario / util cuando se va a cambiar de formulario
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
