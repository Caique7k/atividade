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
    public partial class FormProcurarPedido : Form
    {

        public FormProcurarPedido()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cpf = txtboxCPF.Text.Trim();
            if (string.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("Por favor, insira um CPF válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            carregarPedido(cpf);

        }
        private void carregarPedido(string cpf)
        {

        }
    }
}
