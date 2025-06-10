namespace atividade
{
    partial class FormProcurarPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnBuscar = new Button();
            txtboxCPF = new TextBox();
            listViewPedidos = new ListView();
            ID = new ColumnHeader();
            TOTAL = new ColumnHeader();
            listViewItens = new ListView();
            PRODUTOS = new ColumnHeader();
            PREÇO = new ColumnHeader();
            label2 = new Label();
            label3 = new Label();
            btnLimpar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "DIGITE O CPF:";
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Location = new Point(216, 6);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtboxCPF
            // 
            txtboxCPF.Location = new Point(98, 6);
            txtboxCPF.Name = "txtboxCPF";
            txtboxCPF.Size = new Size(100, 23);
            txtboxCPF.TabIndex = 2;
            // 
            // listViewPedidos
            // 
            listViewPedidos.Columns.AddRange(new ColumnHeader[] { ID, TOTAL });
            listViewPedidos.Location = new Point(12, 68);
            listViewPedidos.Name = "listViewPedidos";
            listViewPedidos.Size = new Size(279, 97);
            listViewPedidos.TabIndex = 3;
            listViewPedidos.UseCompatibleStateImageBehavior = false;
            listViewPedidos.View = View.Details;
            listViewPedidos.SelectedIndexChanged += listViewPedidos_SelectedIndexChanged;
            // 
            // ID
            // 
            ID.Text = "ID";
            // 
            // TOTAL
            // 
            TOTAL.Text = "TOTAL";
            // 
            // listViewItens
            // 
            listViewItens.Columns.AddRange(new ColumnHeader[] { PRODUTOS, PREÇO });
            listViewItens.Location = new Point(12, 200);
            listViewItens.Name = "listViewItens";
            listViewItens.Size = new Size(279, 97);
            listViewItens.TabIndex = 4;
            listViewItens.UseCompatibleStateImageBehavior = false;
            listViewItens.View = View.Details;
            // 
            // PRODUTOS
            // 
            PRODUTOS.Text = "PRODUTOS";
            // 
            // PREÇO
            // 
            PREÇO.Text = "PREÇO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "PEDIDOS: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 182);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 6;
            label3.Text = "ITENS";
            // 
            // btnLimpar
            // 
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.Location = new Point(216, 39);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 7;
            btnLimpar.Text = "LIMPAR";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // FormProcurarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 322);
            Controls.Add(btnLimpar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listViewItens);
            Controls.Add(listViewPedidos);
            Controls.Add(txtboxCPF);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Name = "FormProcurarPedido";
            Text = "FormProcurarPedido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnBuscar;
        private TextBox txtboxCPF;
        private ListView listViewPedidos;
        private ListView listViewItens;
        private Label label2;
        private Label label3;
        private ColumnHeader ID;
        private ColumnHeader TOTAL;
        private ColumnHeader PRODUTOS;
        private ColumnHeader PREÇO;
        private Button btnLimpar;
    }
}