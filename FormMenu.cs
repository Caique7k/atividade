﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atividade
{
    public partial class FormMenu : Form
    {
        public string Usuario { get; set; }
        public FormMenu(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
            label1.Text = "Bem-vindo, " + Usuario + "!";
        }

        private void cadastroDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroCliente formCadastroCliente = new FormCadastroCliente();
            formCadastroCliente.Show();
        }

        private void cadastroDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroProduto formCadastroProduto = new FormCadastroProduto();
            formCadastroProduto.Show();
        }

        private void cadastroDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroPedidos formCadastroPedido = new FormCadastroPedidos();
            formCadastroPedido.Show();
        }

        private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Usuario == "ADMIN")
            {
                FormCadastroUsuarios formCadastroUsuarios = new FormCadastroUsuarios(Usuario);
                formCadastroUsuarios.Show();
            }
            else
            {
                MessageBox.Show("Apenas usuários administradores podem acessar.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMudarSenha_Click(object sender, EventArgs e)
        {
            FormNovaSenha formNovaSenha = new FormNovaSenha(Usuario);
            formNovaSenha.Show();

        }
    }
}
