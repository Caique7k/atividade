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
        public FormCadastroPedidos()
        {
            InitializeComponent();
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
