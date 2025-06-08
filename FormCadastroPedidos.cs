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
    }
}
