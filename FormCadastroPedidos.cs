using System;
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
        private string cpfCliente;
        public FormCadastroPedidos()
        {
            InitializeComponent();
            BuscarProdutos();
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
                    comboBoxProdutos.SelectedItem = null; 
                    numericUpDown1.Value = 0; 
                    lblTotalPedido.Text += $"{item.NomeProduto} (Qtd: {item.Quantidade}, Preço: {item.PrecoUnitario:C}, TOTAL: {item.Total:C})\n";
                    lblTotal.Text = $"Total do Pedido: {produtosSelecionados.Sum(p => decimal.Parse(p.Split(',')[3]) * int.Parse(p.Split(',')[2])):C}";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao adicionar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
