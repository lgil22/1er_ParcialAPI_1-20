﻿using System;
using System.Windows;
using System.Windows.Controls;
using _1er_ParcialAPI_1_20.Entidades;
using _1er_ParcialAPI_1_20.BLL;
using _1er_ParcialAPI_1_20.UI.Registros;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using _1er_ParcialAPI_1_20.UI;
using System.Linq;


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

        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();
            articulos.ProductoId = Convert.ToInt32(IdTextBox.Text);
            articulos.Descripcion = DescripTextBox.Text;
            articulos.Existencia = Convert.ToDecimal(ExistTextBox.Text);
            articulos.Costo = Convert.ToDecimal(CostoTextBox.Text);
            articulos.ValorInventario = Convert.ToDecimal(ValinvetTextBox.Text);
            return articulos;
        }

        private void LlenaCampo(Articulos articulos)
        {
            IdTextBox.Text = Convert.ToString(articulos.ProductoId);
            DescripTextBox.Text = articulos.Descripcion;
            ExistTextBox.Text = Convert.ToString(articulos.Existencia);
            CostoTextBox.Text = Convert.ToString(articulos.Costo);
            ValinvetTextBox.Text = Convert.ToString(articulos.ValorInventario);

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos articulos = ArticulosBLL.Buscar((int)IdTextBox.Text.ToInt());
            return (articulos != null);
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
            int id;
            Articulos articulos = new Articulos();
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            articulos = ArticulosBLL.Buscar(id);

            if (articulos != null)
            {
                MessageBox.Show("Articulo Encontrado");
                LlenaCampo(articulos);
            }

            else
            {
                MessageBox.Show("Articulo no Encontrado");
            }

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos;
            bool paso = false;

            if (!Validar())
                return;

            articulos = LlenaClase();

            if (IdTextBox.Text.ToInt() == 0)

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = ArticulosBLL.Guardar(articulos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un articulo que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ArticulosBLL.Modificar(articulos);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            if (ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(IdTextBox.Text, "No se puede eliminar una articulo que no existe");
        }

        private void ExistTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
             try
             {
                decimal costo = Convert.ToDecimal(CostoTextBox.Text);
                decimal existe = Convert.ToDecimal(ExistTextBox.Text);
                decimal resultado = costo * existe;
                ValinvetTextBox.Text = resultado.ToString();

                ///ValinvetTextBox.Text = (decimal.Parse(ExistTextBox.Text) * decimal.Parse(CostoTextBox.Text)).ToString();
            }
            catch
             {

             }

        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           try
            {

                decimal costo = Convert.ToDecimal(CostoTextBox.Text);
                decimal existe = Convert.ToDecimal(ExistTextBox.Text);
                decimal resultado = costo * existe;
                ValinvetTextBox.Text = resultado.ToString();

               // ValinvetTextBox.Text = (decimal.Parse(ExistTextBox.Text) * decimal.Parse(CostoTextBox.Text)).ToString();
            }
            catch
            {

            }

        }
    }
}
