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
    public partial class FormMenu : Form
    {
        public string Usuario { get; set; }
        public FormMenu(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
            label1.Text = "Bem-vindo, " + Usuario + "!"; 
        }
    }
}
