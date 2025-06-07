namespace atividade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtSenha.UseSystemPasswordChar = true;
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) ||  string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ValidarCSV(usuario, senha);
            }
        }

        private bool ValidarCSV(string usuario, string senha)
        {
            try
            {
                string caminhoCSV = "usuarios.csv";
                if (!File.Exists(caminhoCSV))
                {
                    MessageBox.Show("Arquivo de usu�rios n�o encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                using (var reader = new StreamReader(caminhoCSV))
                {
                    while (!reader.EndOfStream)
                    {
                        var linha = reader.ReadLine();
                        var colunas = linha.Split(',');
                        if (colunas.Length >= 2 && colunas[0].Trim() == usuario && colunas[1].Trim() == senha) // Verifica se o usu�rio e senha � a mesma que o CSV
                        {
                            FormMenu formMenu = new FormMenu(usuario);
                            formMenu.Show();
                            this.Close();
                            return true;
                        }
                    }
                }
                MessageBox.Show("Usu�rio ou senha inv�lidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao validar usu�rio: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
