﻿using Domain.Models;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Forms
{
    /// <summary>
    /// Lógica de interacción para TipoUsuarioForm.xaml
    /// </summary>
    public partial class TipoUsuarioForm : UserControl
    {
        private TipoUsuarioModel tipoUsuario = new TipoUsuarioModel();
        bool isModifying = false;
        string idTipoUsuario;
        public string message;
        public TipoUsuarioForm()
        {
            InitializeComponent();
            FillTipoUsuarioCombox();
        }
        private void FillTipoUsuarioCombox()
        {
            TipoUsuarioCombox.Items.Add("A");
            TipoUsuarioCombox.Items.Add("E");
        }
        public void SetData(string id, string nombre, string tipoUsuario)
        {
            isModifying = true;
            idTipoUsuario = id;
            NombreTextBox.Text = nombre;
            TipoUsuarioCombox.SelectedItem = tipoUsuario;
            
        }
        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isModifying == true)
            {
                tipoUsuario.EntityState = EntityState.Modified;
                tipoUsuario.Id = idTipoUsuario;
            }
            else
                tipoUsuario.EntityState = EntityState.Added;

            tipoUsuario.Nombre = NombreTextBox.Text;
            tipoUsuario.TipoUsuario = TipoUsuarioCombox.SelectedItem.ToString();

            bool validation = new Helps.DataValidation(tipoUsuario).Validate();

            if (validation == true)
            {
                string result = tipoUsuario.Savechanges();
                MessageBox.Show(result);
                //message = result;
                //DialogResult = true;
            }
        }
    }
}
