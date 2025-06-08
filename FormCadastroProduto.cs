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
    public partial class FormCadastroProduto : Form
    {
        private Produtoselecionado produtoselecionado;
        public FormCadastroProduto()
        {
            InitializeComponent();
            CarregaDados();

            listBox1.DoubleClick += listBox1_DoubleClick;
        }
        public class Produtoselecionado
        {
            public string IDProd { get; set; }
        }

        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregaDados()
        {
            string caminho = "cadastroProdutos.csv";
            if (!File.Exists(caminho))
            {
                MessageBox.Show("Arquivo de cadastro não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                listBox1.Items.Clear();
                using (FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            var colunas = linha.Split(',');
                            if (colunas.Length >= 4)
                            {
                                listBox1.Items.Add($"{colunas[0].Trim()} - {colunas[1].Trim()} - {colunas[2].Trim()} - {colunas[3].Trim()}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSALVAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxIDProd.Text) || string.IsNullOrEmpty(txtboxNome.Text) || string.IsNullOrEmpty(txtboxPreco.Text) || string.IsNullOrWhiteSpace(txtboxDesc.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string caminho = "cadastroProdutos.csv";
                string idProd = txtboxIDProd.Text.Trim();
                try
                {
                    var linhas = File.ReadAllLines(caminho);
                    foreach (var linha in linhas)
                    {
                        var dados = linha.Split(',');
                        if (dados.Length >= 2 && dados[0].Trim().Equals(idProd, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Id do produto já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    using (FileStream fs = new FileStream(caminho, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine($"{txtboxIDProd.Text.Trim()},{txtboxNome.Text.Trim()},{txtboxPreco.Text.Trim()},{txtboxDesc.Text.Trim()}");
                    }
                    MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregaDados();
                    txtboxIDProd.Clear();
                    txtboxNome.Clear();
                    txtboxPreco.Clear();
                    txtboxDesc.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var item = listBox1.SelectedItem.ToString();
                var partes = item.Split('-');
                if (partes.Length >= 4)
                {
                    produtoselecionado = new Produtoselecionado
                    {
                        IDProd = partes[0].Trim()
                    };
                    txtboxIDProd.Text = produtoselecionado.IDProd;
                    txtboxNome.Text = partes[1].Trim();
                    txtboxPreco.Text = partes[2].Trim();
                    txtboxDesc.Text = partes[3].Trim();
                }
            }
        }
    }
}
