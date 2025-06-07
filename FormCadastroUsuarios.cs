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

            txtSenha.UseSystemPasswordChar = true;
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
                            dataGridView1.Rows.Add(usuario, senha);
                            this.Close();
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
