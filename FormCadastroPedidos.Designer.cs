namespace atividade
{
    partial class FormCadastroPedidos
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
            txtboxIdPedido = new TextBox();
            txtBoxCpfCliente = new TextBox();
            label2 = new Label();
            lblCliente = new Label();
            btnBucarCpf = new Button();
            label3 = new Label();
            comboBoxProdutos = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            listBox1 = new ListBox();
            lblTotalPedido = new Label();
            btnFinalizar = new Button();
            btnExcluir = new Button();
            btnAddPedido = new Button();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "ID DO PEDIDO: ";
            // 
            // txtboxIdPedido
            // 
            txtboxIdPedido.Location = new Point(106, 11);
            txtboxIdPedido.Name = "txtboxIdPedido";
            txtboxIdPedido.Size = new Size(100, 23);
            txtboxIdPedido.TabIndex = 1;
            // 
            // txtBoxCpfCliente
            // 
            txtBoxCpfCliente.Location = new Point(106, 54);
            txtBoxCpfCliente.Name = "txtBoxCpfCliente";
            txtBoxCpfCliente.Size = new Size(100, 23);
            txtBoxCpfCliente.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 3;
            label2.Text = "CPF CLIENTE: ";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(221, 57);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(0, 15);
            lblCliente.TabIndex = 4;
            // 
            // btnBucarCpf
            // 
            btnBucarCpf.Cursor = Cursors.Hand;
            btnBucarCpf.Location = new Point(12, 86);
            btnBucarCpf.Name = "btnBucarCpf";
            btnBucarCpf.Size = new Size(88, 23);
            btnBucarCpf.TabIndex = 5;
            btnBucarCpf.Text = "BUSCAR CPF";
            btnBucarCpf.UseVisualStyleBackColor = true;
            btnBucarCpf.Click += btnBucarCpf_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 125);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 6;
            label3.Text = "PRODUTOS:";
            // 
            // comboBoxProdutos
            // 
            comboBoxProdutos.FormattingEnabled = true;
            comboBoxProdutos.Location = new Point(85, 122);
            comboBoxProdutos.Name = "comboBoxProdutos";
            comboBoxProdutos.Size = new Size(121, 23);
            comboBoxProdutos.TabIndex = 7;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(221, 123);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(40, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 166);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(368, 94);
            listBox1.TabIndex = 9;
            // 
            // lblTotalPedido
            // 
            lblTotalPedido.AutoSize = true;
            lblTotalPedido.Location = new Point(12, 273);
            lblTotalPedido.Name = "lblTotalPedido";
            lblTotalPedido.Size = new Size(0, 15);
            lblTotalPedido.TabIndex = 10;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Cursor = Cursors.Hand;
            btnFinalizar.Location = new Point(305, 266);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(75, 23);
            btnFinalizar.TabIndex = 11;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(305, 295);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 12;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAddPedido
            // 
            btnAddPedido.Cursor = Cursors.Hand;
            btnAddPedido.Location = new Point(276, 125);
            btnAddPedido.Name = "btnAddPedido";
            btnAddPedido.Size = new Size(143, 21);
            btnAddPedido.TabIndex = 13;
            btnAddPedido.Text = "ADICIONAR AO PEDIDO";
            btnAddPedido.UseVisualStyleBackColor = true;
            btnAddPedido.Click += btnAddPedido_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(386, 196);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 15);
            lblTotal.TabIndex = 14;
            // 
            // FormCadastroPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 333);
            Controls.Add(lblTotal);
            Controls.Add(btnAddPedido);
            Controls.Add(btnExcluir);
            Controls.Add(btnFinalizar);
            Controls.Add(lblTotalPedido);
            Controls.Add(listBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBoxProdutos);
            Controls.Add(label3);
            Controls.Add(btnBucarCpf);
            Controls.Add(lblCliente);
            Controls.Add(label2);
            Controls.Add(txtBoxCpfCliente);
            Controls.Add(txtboxIdPedido);
            Controls.Add(label1);
            Name = "FormCadastroPedidos";
            Text = "FormCadastroPedidos";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtboxIdPedido;
        private TextBox txtBoxCpfCliente;
        private Label label2;
        private Label lblCliente;
        private Button btnBucarCpf;
        private Label label3;
        private ComboBox comboBoxProdutos;
        private NumericUpDown numericUpDown1;
        private ListBox listBox1;
        private Label lblTotalPedido;
        private Button btnFinalizar;
        private Button btnExcluir;
        private Button btnAddPedido;
        private Label lblTotal;
    }
}