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

        public FormCadastroCliente()
        {
            InitializeComponent();
            txtboxBAIRRO.ReadOnly = true;
            txtboxCIDADE.ReadOnly = true;
            txtboxLOGRADOURO.ReadOnly = true;
            txtboxESTADO.ReadOnly = true;


        }

        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
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
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message);
            }
        }
    }
}
