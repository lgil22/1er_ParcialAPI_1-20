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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
