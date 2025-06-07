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
    public partial class FormCadastroUsuarios : Form
    {
        public string Usuario { get; set; }
        public FormCadastroUsuarios(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;

            CarregarDados();
            txtSenha.UseSystemPasswordChar = true;
        }

        public void CarregarDados()
        {
            try
            {
                string caminhoCSV = "usuarios.csv";
                if (!File.Exists(caminhoCSV))
                {
                    MessageBox.Show("Arquivo de usuários não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (colunas.Length >= 2)
                            {
                                listBox1.Items.Add($"{colunas[0].Trim()} - {colunas[1].Trim()}");
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = checkBox1.Checked;
            txtSenha.UseSystemPasswordChar = !mostrar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }
            else
            {
                try
                {

                    string caminhoCSV = "usuarios.csv";
                    if (!File.Exists(caminhoCSV))
                    {
                        MessageBox.Show("Arquivo de usuários não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        using (var writer = new StreamWriter(caminhoCSV, true))
                        {
                            writer.WriteLine($"{usuario},{senha}");
                            MessageBox.Show("Usuário cadastrado com sucesso!");
                            listBox1.Items.Add($"{usuario} - {senha}");
                        }
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                    return;
                }
            }
        }

       
    }

}
