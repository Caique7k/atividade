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
    public partial class FormCadastroPedidos : Form
    {

        private string pedidoSelecionado;
        private string cpfCliente;
        public FormCadastroPedidos()
        {
            InitializeComponent();
            BuscarProdutos();
            CarregarPedidos();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;


        }

        private List<string> produtosSelecionados = new List<string>();

        public class ItemPedido
        {
            public string CodigoProduto { get; set; }
            public string NomeProduto { get; set; }
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }
            public decimal Total => Quantidade * PrecoUnitario;

        }

        public class PedidoSelecionado
        {
            public string idPedido { get; set; }
        }
        private void CarregarPedidos()
        {
            try
            {
                string caminhoCSV = "pedidos.csv";
                if (!File.Exists(caminhoCSV))
                {
                    MessageBox.Show("Arquivo de pedidos não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var reader = new StreamReader(caminhoCSV))
                {
                    listBox1.Items.Clear();
                    while (!reader.EndOfStream)
                    {
                        var linha = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            var colunas = linha.Split(',');
                            if (colunas.Length >= 4)
                            {
                                string idPedido = colunas[0].Trim();
                                string cpfCliente = colunas[1].Trim();
                                string itensPedido = colunas[2].Trim();
                                string totalPedido = colunas[3].Trim();
                                listBox1.Items.Add($"ID: {idPedido} - CPF: {cpfCliente} - Itens: {itensPedido} - Total: {totalPedido}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pedidos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarProdutos()
        {
            try
            {
                string caminhoCSV = "cadastroProdutos.csv";
                if (!File.Exists(caminhoCSV))
                {
                    MessageBox.Show("Arquivo de produtos não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var reader = new StreamReader(caminhoCSV))
                {
                    comboBoxProdutos.Items.Clear();
                    while (!reader.EndOfStream)
                    {
                        var linha = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            var colunas = linha.Split(',');
                            if (colunas.Length >= 2)
                            {
                                string nomeProduto = colunas[1].Trim();
                                string precoProduto = colunas[2].Trim();
                                comboBoxProdutos.Items.Add($"{nomeProduto}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBucarCpf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxCpfCliente.Text))
            {

                MessageBox.Show("Por favor, preencha o campo CPF.");
                return;
            }
            else
            {
                string caminho = "cadastroClientes.csv";
                string cpfDigitado = txtBoxCpfCliente.Text.Trim();
                if (!File.Exists(caminho))
                {
                    MessageBox.Show("Arquivo de cadastro de clientes não encontrado.");
                    return;
                }
                else
                {
                    try
                    {
                        bool encontrado = false;
                        using (StreamReader sr = new StreamReader(caminho))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                var dados = linha.Split(',');

                                if (dados.Length >= 2)
                                {
                                    string nome = dados[0].Trim();
                                    string cpf = dados[1].Trim();

                                    if (cpf == cpfDigitado)
                                    {
                                        lblCliente.Text = "Cliente: " + nome;
                                        encontrado = true;
                                        cpfCliente = cpf;
                                        break;

                                    }
                                }
                            }
                        }

                        if (!encontrado)
                        {
                            MessageBox.Show("CPF não encontrado.");
                            lblCliente.Text = "Cliente: não encontrado";
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao buscar CPF: {ex.Message}");
                        return;
                    }
                }
            }
        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            if (comboBoxProdutos.SelectedItem == null && numericUpDown1.Value == 0)
            {
                MessageBox.Show("Por favor, selecione um produto e uma quantidade.");
                return;
            }
            else
            {
                string nomeProduto = comboBoxProdutos.SelectedItem.ToString();
                int quantidade = (int)numericUpDown1.Value;
                decimal precoUnitario = 0;
                string caminhoCSV = "cadastroProdutos.csv";
                string codigoProduto = "";
                string precoProduto = "";

                try
                {


                    using (StreamReader sr = new StreamReader(caminhoCSV))
                    {
                        while (!sr.EndOfStream)
                        {
                            var linha = sr.ReadLine();
                            var colunas = linha.Split(',');
                            if (colunas[1].Trim() == nomeProduto)
                            {
                                codigoProduto = colunas[0].Trim(); // Código do produto
                                precoProduto = colunas[2].Trim(); // Preço do produto
                                break;
                            }
                        }
                    }
                    bool produtoExistente = produtosSelecionados.Any(p => p.StartsWith(codigoProduto + ","));

                    if (produtoExistente)
                    {
                        MessageBox.Show("Produto já adicionado ao pedido. Por favor, selecione outro produto.", "Produto Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal precoDecimal = decimal.Parse(precoProduto);

                    var item = new ItemPedido
                    {
                        CodigoProduto = codigoProduto,
                        NomeProduto = nomeProduto,
                        Quantidade = quantidade,
                        PrecoUnitario = precoDecimal
                    };
                    produtosSelecionados.Add($"{item.CodigoProduto},{item.NomeProduto},{item.Quantidade},{item.PrecoUnitario}");
                    MessageBox.Show($"Produto adicionado: {item.NomeProduto}, Quantidade: {item.Quantidade}, Preço Unitário: {item.PrecoUnitario:C}, TOTAL: {item.Total:C}", "Produto Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblTotalPedido.Text += $"{item.NomeProduto} (Qtd: {item.Quantidade}, Preço: {item.PrecoUnitario:C}, TOTAL: {item.Total:C})\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao adicionar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxIdPedido.Text) || string.IsNullOrEmpty(txtBoxCpfCliente.Text) || comboBoxProdutos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }
            else
            {
                try
                {
                    string caminhoCSV = "pedidos.csv";
                    var linhas = File.ReadAllLines(caminhoCSV);
                    string idProd = txtboxIdPedido.Text.Trim();
                    foreach (var linha in linhas)
                    {
                        var colunas = linha.Split(',');
                        if (colunas.Length >= 4 && colunas[0].Trim().Equals(idProd, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("ID do pedido já existe. Por favor, insira um ID único.");
                            return;
                        }

                    }

                    if (lblCliente.Text == "Cliente: não encontrado")
                    {
                        MessageBox.Show("Por favor, busque um cliente válido antes de finalizar o pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string idPedido = txtboxIdPedido.Text.Trim();

                        var nomeProdutos = produtosSelecionados.Select(p => p.Split(',')[1]).ToList();
                        string itensPedido = string.Join(";", nomeProdutos);
                        decimal totalItensPedido = produtosSelecionados.Sum(p => decimal.Parse(p.Split(',')[3]) * int.Parse(p.Split(',')[2]));
                        using (StreamWriter sw = new StreamWriter(caminhoCSV, true))
                        {
                            sw.WriteLine($"{idPedido},{cpfCliente},\"{itensPedido}\",{totalItensPedido.ToString("F2")}");

                        }
                        CarregarPedidos();

                        MessageBox.Show($"Pedido {idPedido} finalizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtboxIdPedido.Clear();
                        txtBoxCpfCliente.Clear();
                        lblTotal.Text = "";
                        lblTotalPedido.Text = "";
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao finalizar pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                string linhaSelecionada = listBox1.SelectedItem.ToString();
                var partes = linhaSelecionada.Split('-');
                if (partes.Length >= 4)
                {
                    pedidoSelecionado = partes[0].Replace("ID: ", "").Trim();

                }
                else
                {
                    MessageBox.Show("Selecione um pedido válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (pedidoSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um pedido para excluir.");
                return;
            }
            else
            {
                var confirmar = MessageBox.Show($"Deseja realmente excluir o pedido '{pedidoSelecionado}'?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    try
                    {
                        string caminhoCSV = "pedidos.csv";
                        if (!File.Exists(caminhoCSV))
                        {
                            MessageBox.Show("Arquivo de pedidos não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var linhas = File.ReadAllLines(caminhoCSV).Where(l => !l.StartsWith(pedidoSelecionado + ",")).ToList();
                            File.WriteAllLines(caminhoCSV, linhas);
                            CarregarPedidos();
                            MessageBox.Show($"Pedido {pedidoSelecionado} excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pedidoSelecionado = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            FormProcurarPedido formProcurarPedido = new FormProcurarPedido();
            formProcurarPedido.ShowDialog();
        }
    }
}
