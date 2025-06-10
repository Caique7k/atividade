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
            listViewItens.Items.Clear();
            listViewPedidos.Items.Clear();

            string caminho = "pedidos.csv";
            if (!File.Exists(caminho))
            {
                MessageBox.Show("Arquivo de pedidos não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var linha in File.ReadLines(caminho))
            {
                var colunas = linha.Split(',');
                if(colunas.Length >= 4 && colunas[1] == cpf) 
                {
                    string idPedido = colunas[0].Trim();
                    string totalPedido = colunas[3].Trim();

                    var item = new ListViewItem(idPedido);
                    item.SubItems.Add($"{TOTAL}");
                    item.Tag = linha;
                    listViewPedidos.Items.Add(item);
                }
                
            }
        }

        private void listViewPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
