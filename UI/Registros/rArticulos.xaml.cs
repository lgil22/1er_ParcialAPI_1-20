using System;
using System.Windows;
using System.Windows.Controls;
using _1er_ParcialAPI_1_20.Entidades;
using _1er_ParcialAPI_1_20.BLL;
using _1er_ParcialAPI_1_20.UI.Registros;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _1er_ParcialAPI_1_20.UI.Registros
{
    /// <summary>
    /// Interaction logic for rArticulos.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            DescripTextBox.Text = string.Empty;
            ExistTextBox.Text = "0";
            CostoTextBox.Text = "0";
            ValinvetTextBox.Text = "0";
        }

        private void Llenaclase()
        {
            Articulos articulos = new Articulos();
            articulos.ProductoId = Convert.ToInt32(IdTextBox.Text);
            articulos.Descripcion = DescripTextBox.Text;
            articulos.Existencia = Convert.ToInt32(ExistTextBox.Text);
            articulos.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulos.ValorInventario = Convert.ToInt32(ValinvetTextBox.Text);

            //return articulos;
        }

        private void LlenaCampo(Articulos articulos)
        {
            IdTextBox.Text = Convert.ToString(articulos.ProductoId);
            DescripTextBox.Text = articulos.Descripcion;
            ExistTextBox.Text = Convert.ToString( articulos.Existencia);
            CostoTextBox.Text = Convert.ToString(articulos.Costo);
            ValinvetTextBox.Text = Convert.ToString(articulos.ValorInventario);

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos personas = ArticulosBLL.Buscar((int)IdTextBox.Text.ToInt());
            return (personas != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (DescripTextBox.Text == string.Empty)
            {
                MessageBox.Show(DescripTextBox.Text, "El campo Descripcion no puede estar vacio ");
                DescripTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ExistTextBox.Text))
            {
                MessageBox.Show(ExistTextBox.Text, "El campo Existencia no puede estar vacio");
                ExistTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show(CostoTextBox.Text, "El campo Costo no puede estar vacio");
                CostoTextBox.Focus();
                paso = false;
            }

            Articulos articulos = ArticulosBLL.Buscar((int)IdTextBox.Text.ToInt());
            return paso;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
