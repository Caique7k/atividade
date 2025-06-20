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
    public partial class FormProcurarPedido : Form
    {

        public FormProcurarPedido()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cpf = txtboxCPF.Text.Trim();
            if (string.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("Por favor, insira um CPF válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nomeCliente = buscaCliente(cpf);

            if (nomeCliente == null)
            {
                MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                carregarPedido(cpf);
            }


        }
        private void carregarPedido(string cpf)
        {
            listViewItens.Items.Clear();
            listViewPedidos.Items.Clear();

            string caminho = "pedidos.csv";
            if (!File.Exists(caminho))
            {
                MessageBox.Show("Arquivo de pedidos não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var linha in File.ReadLines(caminho))
            {
                var colunas = linha.Split(',');
                if (colunas.Length >= 4 && colunas[1] == cpf)
                {
                    string idPedido = colunas[0].Trim();
                    string totalPedido = colunas[3].Trim();

                    var item = new ListViewItem(idPedido);
                    item.SubItems.Add($"{TOTAL}");
                    item.Tag = linha;
                    listViewPedidos.Items.Add(item);
                }

            }
        }

        private void listViewPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPedidos.SelectedItems.Count == 0)
            {
                return;
            }
            listViewItens.Items.Clear();
            var itemSelecionado = listViewPedidos.SelectedItems[0];
            var linha = itemSelecionado.Tag.ToString();
            var colunas = linha.Split(',');
            if (colunas.Length >= 4)
            {
                string produtos = colunas[2].Trim();
                string[] itens = produtos.Split(';');

                decimal totalPedido = decimal.Parse(colunas[3].Trim());
                foreach (var produto in itens)
                {
                    var item = new ListViewItem(produto.Trim());
                    item.SubItems.Add(totalPedido.ToString("C2"));
                    listViewItens.Items.Add(item);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtboxCPF.Clear();
            listViewItens.Items.Clear();
            listViewPedidos.Items.Clear();

        }
       private string buscaCliente(string cpf)
        {
            string caminho = "cadastroClientes.csv";
            if (!File.Exists(caminho))
            {
                MessageBox.Show("Arquivo de clientes não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            foreach (var linha in File.ReadAllLines(caminho))
            {
                var dados = linha.Split(',');
                if (dados.Length >= 2 && dados[1].Trim() == cpf)
                {
                    return dados[0].Trim(); 
                }
            }

            return null;
        }
    }
}
