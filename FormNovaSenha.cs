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
    public partial class FormNovaSenha : Form
    {
        public string Usuario { get; set; }
        public FormNovaSenha(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
        }
    }
}
