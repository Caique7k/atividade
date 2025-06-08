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
        private UsuarioSelecionado usuarioSelecionadoAtual;
        public string Usuario { get; set; }
        public FormCadastroUsuarios(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;

            CarregarDados();
            txtSenha.UseSystemPasswordChar = true;
            listBox1.DoubleClick += listBox1_DoubleClick;

        }
        public class UsuarioSelecionado
        {
            public string Nome { get; set; }
            public string Senha { get; set; }
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
            catch (Exception ex)
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
                        if (button1.Text == "Atualizar" && listBox1.SelectedItem != null)
                        {
                            try
                            {

                                string linhaSelecionada = listBox1.SelectedItem.ToString();
                                string usuarioOriginal = linhaSelecionada.Split('-')[0].Trim();

                                var linhas = File.ReadAllLines(caminhoCSV).ToList();

                                for (int i = 0; i < linhas.Count; i++)
                                {
                                    var dados = linhas[i].Split(',');
                                    if (dados[0].Trim().Equals(usuarioOriginal, StringComparison.OrdinalIgnoreCase))
                                    {
                                        linhas[i] = $"{usuario},{senha}";
                                        break;
                                    }
                                }

                                File.WriteAllLines(caminhoCSV, linhas);

                                MessageBox.Show("Usuário atualizado com sucesso!");


                                txtUsuario.Clear();
                                txtSenha.Clear();
                                button1.Text = "Cadastrar";
                                CarregarDados();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                var linhas = File.ReadAllLines(caminhoCSV);
                                foreach (var linha in linhas)
                                {
                                    var dados = linha.Split(',');
                                    if (dados.Length >= 2 && dados[0].Trim().Equals(usuario, StringComparison.OrdinalIgnoreCase))
                                    {
                                        MessageBox.Show("Usuário já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                using (var writer = new StreamWriter(caminhoCSV, true))
                                {
                                    writer.WriteLine($"{usuario},{senha}");
                                    MessageBox.Show("Usuário cadastrado com sucesso!");
                                    listBox1.Items.Add($"{usuario} - {senha}");
                                    txtUsuario.Clear();
                                    txtSenha.Clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                    return;
                }
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string linhaSelecionada = listBox1.SelectedItem.ToString();
                var partes = linhaSelecionada.Split('-');

               

                if (partes.Length >= 2)
                {
                    txtUsuario.Text = partes[0].Trim();
                    txtSenha.Text = partes[1].Trim();

                    usuarioSelecionadoAtual = new UsuarioSelecionado
                    {
                        Nome = partes[0].Trim(),
                        Senha = partes[1].Trim()
                    };

                    button1.Text = "Atualizar";
                }
                else
                {
                    MessageBox.Show("Seleção inválida. Por favor, selecione um usuário válido.");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionadoAtual == null )
            {
                MessageBox.Show("Nenhum usuário selecionado para exclusão.");
                return;
            }
            else
            {
                var confirmar = MessageBox.Show($"Deseja realmente excluir o usuário '{usuarioSelecionadoAtual.Nome}'?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmar == DialogResult.Yes)
                {
                    try
                    {
                        string caminhoCSV = "usuarios.csv";
                        var linhas = File.ReadAllLines(caminhoCSV).ToList();
                        bool removido = false;

                        for (int i = 0; i < linhas.Count; i++)
                        {
                            var dados = linhas[i].Split(',');
                            if (dados.Length >= 2 && dados[0].Trim().Equals(usuarioSelecionadoAtual.Nome, StringComparison.OrdinalIgnoreCase))
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
                            CarregarDados();
                            txtUsuario.Clear();
                            txtSenha.Clear();
                            button1.Text = "Cadastrar";
                            usuarioSelecionadoAtual = null;
                        }
                        else
                        {
                            MessageBox.Show("Usuário não encontrado para exclusão.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir usuário: " + ex.Message);
                    }
                }
            }
        }
    }

}
