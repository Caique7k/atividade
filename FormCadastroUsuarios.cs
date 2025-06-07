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
    }

}
