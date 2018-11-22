﻿using PalcoNet.Registro_de_Usuario;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Login : Form
    {

        private LoginDAO dao;

        public Login()
        {
            InitializeComponent();
            dao = new LoginDAO();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Decimal idUsuario = dao.esUsuarioActivo(usuario.Text, pass.Text);
            if (idUsuario <0 )
            {
                System.Windows.Forms.MessageBox.Show("Credenciales incorrectas para el usuario "+usuario.Text+ ".\nEs posible que el usuario no exista o la contraseña sea incorrecta.\nPor favor, intente de nuevo.");
                pass.Text = ""; //Por las dudas
                pass.Focus();
                return;
            }
            Globales.idUsuarioOnline = idUsuario; //evaluar si es necesario
            this.Hide();
            new SeleccionRol(idUsuario).ShowDialog();
            this.Show();
        }
    }
}
