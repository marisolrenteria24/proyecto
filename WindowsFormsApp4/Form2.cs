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
        
      
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e) //boton para cambiar de formulario a la vista de administrador
        {
            Form Form1 = new Form1(); // Se declara el formulario 1 para poder abrirlo
            Form1.Show(); //Muestra el formulario 1
            this.Close();//Cierra el formulario 2
        }

        private void Form2_Load(object sender, EventArgs e) //Evento de cargar formulario 2
        {
         
                listBox1.DataSource = Product.Productos; //Despliega la lista de productos al cargar el formulario
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidad; //Variable para saber la cantidad de cuantos se vendieron
            bool existe = Product.Productos.Any(p => p.Name == textBox1.Text); //variable que verifica en toda la lista si existe el producto / funcion lambda con la condicion para verificar si el texto está en algun objeto
            if (!existe)
            {
                MessageBox.Show("El producto no está registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Mensaje por si no existe el objeto
                return; //return pa que el programa no se apendeje y registre el producto aunque no exista
            }
            else //en caso de que si exita
            {
                if (comboBox1.SelectedIndex == -1) // verifica si no se seleccionó algo del combobox
                {
                    MessageBox.Show("Seleccione la cantidad", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Mensaje de cantidad no seleccionada
                    return; // lo mismo que el return anterior
                }
               
                var producto = Product.Productos.First(p => p.Name == textBox1.Text); //busca el primer objeto en la lista cuyo nombre coincida con lo que se escribio en el textbox y lo guarda en la variable producto (es un objeto) y se puede manipular mucho más ez

               
                string selected = comboBox1.SelectedItem.ToString(); //los combobox son estupidos y no se puede usar el parse directamente, y para poder acceder a ellos como un numero, primero tengo que convertirlo a string
                cantidad = int.Parse(selected); //y luego a int
                producto.Sold = cantidad + producto.Sold; // contador para la cantidad de productos que se han vendido individualmente

                double total = producto.Price * cantidad; // calcula el total de la compra individual para poder mostrarlo en un lindo mensaje
                MessageBox.Show($"Compra realizada\n\n Total : {total}","Mensaje",MessageBoxButtons.OK); 
                Product.total_glb += total; //Variable que va contando el total vendido en todo el día
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int vendido = 0; 
            Product masvendido = null; // se declara un objeto nulo para poder darle valor más adelante

            foreach (Product p in Product.Productos) 
            {
                if(p.Sold > vendido) // condicion para sacar el producto más vendido
                {
                    vendido = p.Sold; //ahora este objeto es el más vendido de la lista
                    masvendido = p; //se asigna el objeto más vendido al objeto que previamente declaramos para poder acceder más facil a ese
                }

            }
            MessageBox.Show($"Venta total del día: {Product.total_glb}\n\nEl producto más vendido es: {masvendido.Name}", "Corte",MessageBoxButtons.OK); 
        }
    }
}
