using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;

namespace atividade
{
    public partial class FormCadastroCliente : Form
    {
        private ClienteSelecionado clienteSelecionadoAtual;
        public class Endereco
        {
            public string Cep { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string Uf { get; set; }
            public string Ibge { get; set; }
            public string Gia { get; set; }
            public string Ddd { get; set; }
            public string Siafi { get; set; }
        }
        public class ClienteSelecionado
        {
            public string cpf { get; set; }
        }
        public FormCadastroCliente()
        {
            InitializeComponent();
            carregaDados();
            txtboxBAIRRO.ReadOnly = true;
            txtboxCIDADE.ReadOnly = true;
            txtboxLOGRADOURO.ReadOnly = true;
            txtboxESTADO.ReadOnly = true;


            listBox1.DoubleClick += listBox1_DoubleClick;


        }

        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void carregaDados()
        {
            string caminhoCSV = "cadastroClientes.csv";
            if (!File.Exists(caminhoCSV))
            {
                MessageBox.Show("Arquivo de cadastro não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                listBox1.Items.Clear();
                using (StreamReader sr = new StreamReader(caminhoCSV))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            var colunas = linha.Split(',');
                            if (colunas.Length >= 11)
                            {
                                listBox1.Items.Add($"{colunas[0].Trim()} - {colunas[1].Trim()} - {colunas[2].Trim()} - {colunas[3].Trim()} - {colunas[4].Trim()} - {colunas[5].Trim()} - {colunas[6].Trim()} - {colunas[7].Trim()} - {colunas[8].Trim()} - {colunas[9].Trim()} - {colunas[10].Trim()}");
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


        private async void btnBuscarCep_Click(object sender, EventArgs e)
        {
            string cep = txtboxCEP.Text.Trim();
            if (string.IsNullOrEmpty(cep) || cep.Length != 8)
            {
                MessageBox.Show("Por favor, insira um CEP válido com 8 dígitos.");
                return;
            }
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://viacep.com.br/ws/{cep}/json/";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Endereco endereco = JsonSerializer.Deserialize<Endereco>(jsonResponse, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (endereco != null)
                        {
                            txtboxLOGRADOURO.Text = endereco.Logradouro;
                            txtboxBAIRRO.Text = endereco.Bairro;
                            txtboxCIDADE.Text = endereco.Localidade;
                            txtboxESTADO.Text = endereco.Uf;

                            txtboxBAIRRO.ReadOnly = false;
                            txtboxCIDADE.ReadOnly = false;
                            txtboxLOGRADOURO.ReadOnly = false;
                            txtboxESTADO.ReadOnly = false;

                            txtboxNUMERO.Focus();
                        }
                        else
                        {
                            MessageBox.Show("CEP não encontrado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao buscar CEP. Verifique o CEP informado.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message);
            }
        }

        private void btnSALVAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxNOME.Text) || string.IsNullOrEmpty(txtboxCPF.Text) || string.IsNullOrEmpty(txtboxEMAIL.Text) || string.IsNullOrEmpty(txtboxCEP.Text) || string.IsNullOrEmpty(txtboxLOGRADOURO.Text) || string.IsNullOrEmpty(txtboxNUMERO.Text) || string.IsNullOrEmpty(txtboxBAIRRO.Text) || string.IsNullOrEmpty(txtboxCIDADE.Text) || string.IsNullOrEmpty(txtboxESTADO.Text) || string.IsNullOrEmpty(txtboxTELEFONE.Text) || string.IsNullOrEmpty(txtboxWHATSAPP.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }
            else
            {
                try
                {
                    string caminhoCSV = "cadastroClientes.csv";

                    if (btnSALVAR.Text == "Atualizar" && clienteSelecionadoAtual != null)
                    {
                        try
                        {
                            string linhaSelecionada = listBox1.SelectedItem.ToString();
                            string clienteOriginal = linhaSelecionada.Split('-')[0].Trim();

                            string cpf = txtboxCPF.Text.Trim();
                            using (StreamReader sr = new StreamReader(caminhoCSV))
                            {
                                string linha;
                                while ((linha = sr.ReadLine()) != null)
                                {
                                    var colunas = linha.Split(',');
                                    if (colunas.Length > 1 && colunas[1].Trim() == cpf)
                                    {
                                        MessageBox.Show("CPF já cadastrado.");
                                        return;
                                    }
                                }

                            }

                            string[] linhas = File.ReadAllLines(caminhoCSV);
                            for (int i = 0; i < linhas.Length; i++)
                            {
                                var colunas = linhas[i].Split(',');
                                if (colunas.Length > 1 && colunas[1].Trim() == clienteSelecionadoAtual.cpf)
                                {
                                    linhas[i] = $"{txtboxNOME.Text.Trim()},{txtboxCPF.Text.Trim()},{txtboxEMAIL.Text.Trim()},{txtboxCEP.Text.Trim()},{txtboxLOGRADOURO.Text.Trim()},{txtboxNUMERO.Text.Trim()},{txtboxBAIRRO.Text.Trim()},{txtboxCIDADE.Text.Trim()},{txtboxESTADO.Text.Trim()},{txtboxTELEFONE.Text.Trim()},{txtboxWHATSAPP.Text.Trim()}";
                                    break;
                                }
                            }
                            File.WriteAllLines(caminhoCSV, linhas);
                            MessageBox.Show("Dados atualizados com sucesso!");
                            carregaDados();
                            txtboxNOME.Clear();
                            txtboxCPF.Clear();
                            txtboxEMAIL.Clear();
                            txtboxCEP.Clear();
                            txtboxLOGRADOURO.Clear();
                            txtboxNUMERO.Clear();
                            txtboxBAIRRO.Clear();
                            txtboxCIDADE.Clear();
                            txtboxESTADO.Clear();
                            txtboxTELEFONE.Clear();
                            txtboxWHATSAPP.Clear();
                            clienteSelecionadoAtual = null;
                            btnSALVAR.Text = "Salvar";
                            listBox1.SelectedItem = null;
                            txtboxNOME.Focus();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao atualizar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            string caminho = "cadastroClientes.csv";
                            if (!File.Exists(caminho))
                            {
                                MessageBox.Show("Arquivo de cadastro não encontrado. Criando novo arquivo.");
                                return;
                            }
                            else
                            {
                                string cpf = txtboxCPF.Text.Trim();
                                using (StreamReader sr = new StreamReader(caminho))
                                {
                                    string linha;
                                    while ((linha = sr.ReadLine()) != null)
                                    {
                                        var colunas = linha.Split(',');
                                        if (colunas.Length > 1 && colunas[1].Trim() == cpf)
                                        {
                                            MessageBox.Show("CPF já cadastrado.");
                                            return;
                                        }
                                    }

                                }
                                using (StreamWriter sw = new StreamWriter(caminho, true))
                                {
                                    string linha = $"{txtboxNOME.Text.Trim()},{txtboxCPF.Text.Trim()},{txtboxEMAIL.Text.Trim()},{txtboxCEP.Text.Trim()},{txtboxLOGRADOURO.Text.Trim()},{txtboxNUMERO.Text.Trim()},{txtboxBAIRRO.Text.Trim()},{txtboxCIDADE.Text.Trim()},{txtboxESTADO.Text.Trim()},{txtboxTELEFONE.Text.Trim()},{txtboxWHATSAPP.Text.Trim()}";
                                    sw.WriteLine(linha);
                                    MessageBox.Show("Dados salvos com sucesso!");
                                }
                                carregaDados();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar os dados. Verifique as informações e tente novamente.");
                }
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                string[] dados = listBox1.SelectedItem.ToString().Split('-');
                if (dados.Length >= 11)
                {
                    txtboxNOME.Text = dados[0].Trim();
                    txtboxCPF.Text = dados[1].Trim();
                    txtboxEMAIL.Text = dados[2].Trim();
                    txtboxCEP.Text = dados[3].Trim();
                    txtboxLOGRADOURO.Text = dados[4].Trim();
                    txtboxNUMERO.Text = dados[5].Trim();
                    txtboxBAIRRO.Text = dados[6].Trim();
                    txtboxCIDADE.Text = dados[7].Trim();
                    txtboxESTADO.Text = dados[8].Trim();
                    txtboxTELEFONE.Text = dados[9].Trim();
                    txtboxWHATSAPP.Text = dados[10].Trim();
                    clienteSelecionadoAtual = new ClienteSelecionado
                    {
                        cpf = txtboxCPF.Text.Trim()
                    };
                    btnSALVAR.Text = "Atualizar";
                }
                else
                {
                    MessageBox.Show("Selecione um cliente da lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (clienteSelecionadoAtual == null)
            {
                MessageBox.Show("Nenhum cliente selecionado para exclusão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                var confirmar = MessageBox.Show($"Deseja realmente excluir o cliente '{clienteSelecionadoAtual.cpf}'?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmar == DialogResult.Yes)
                {
                    try
                    {
                        string caminhoCSV = "cadastroClientes.csv";
                        var linhas = File.ReadAllLines(caminhoCSV).ToList();
                        bool removido = false;

                        for (int i = 0; i < linhas.Count; i++)
                        {
                            var dados = linhas[i].Split(',');
                            if (dados.Length > 1 && dados[1].Trim() == clienteSelecionadoAtual.cpf)
                            {
                                linhas.RemoveAt(i);
                                removido = true;
                                break;
                            }
                        }

                        if (removido)
                        {
                            File.WriteAllLines(caminhoCSV, linhas);
                            MessageBox.Show("Usuário excluído com sucesso.");
                            carregaDados();
                            txtboxNOME.Clear();
                            txtboxCPF.Clear();
                            txtboxEMAIL.Clear();
                            txtboxCEP.Clear();
                            txtboxLOGRADOURO.Clear();
                            txtboxNUMERO.Clear();
                            txtboxBAIRRO.Clear();
                            txtboxCIDADE.Clear();
                            txtboxESTADO.Clear();
                            txtboxTELEFONE.Clear();
                            txtboxWHATSAPP.Clear();

                            btnSALVAR.Text = "Salvar";
                            clienteSelecionadoAtual = null;
                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado para exclusão.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
                    }
                }
            }
        }
    }
}

