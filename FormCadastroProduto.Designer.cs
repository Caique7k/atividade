namespace atividade
{
    partial class FormCadastroProduto
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtboxNome = new TextBox();
            txtboxPreco = new TextBox();
            txtboxDesc = new TextBox();
            txtboxIDProd = new TextBox();
            btnSALVAR = new Button();
            btnEXCLUIR = new Button();
            btnCANCELAR = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 0;
            label1.Text = "ID DO PRODUTO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 1;
            label2.Text = "NOME DO PRODUTO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "PREÇO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 100);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 3;
            label4.Text = "DESCRIÇÃO";
            // 
            // txtboxNome
            // 
            txtboxNome.Location = new Point(134, 39);
            txtboxNome.Name = "txtboxNome";
            txtboxNome.Size = new Size(160, 23);
            txtboxNome.TabIndex = 4;
            // 
            // txtboxPreco
            // 
            txtboxPreco.Location = new Point(62, 68);
            txtboxPreco.Name = "txtboxPreco";
            txtboxPreco.Size = new Size(100, 23);
            txtboxPreco.TabIndex = 5;
            // 
            // txtboxDesc
            // 
            txtboxDesc.Location = new Point(12, 118);
            txtboxDesc.Multiline = true;
            txtboxDesc.Name = "txtboxDesc";
            txtboxDesc.Size = new Size(282, 57);
            txtboxDesc.TabIndex = 6;
            // 
            // txtboxIDProd
            // 
            txtboxIDProd.Location = new Point(112, 6);
            txtboxIDProd.Name = "txtboxIDProd";
            txtboxIDProd.Size = new Size(100, 23);
            txtboxIDProd.TabIndex = 7;
            // 
            // btnSALVAR
            // 
            btnSALVAR.Location = new Point(112, 190);
            btnSALVAR.Name = "btnSALVAR";
            btnSALVAR.Size = new Size(75, 23);
            btnSALVAR.TabIndex = 8;
            btnSALVAR.Text = "SALVAR";
            btnSALVAR.UseVisualStyleBackColor = true;
            btnSALVAR.Click += btnSALVAR_Click;
            // 
            // btnEXCLUIR
            // 
            btnEXCLUIR.Location = new Point(219, 190);
            btnEXCLUIR.Name = "btnEXCLUIR";
            btnEXCLUIR.Size = new Size(75, 23);
            btnEXCLUIR.TabIndex = 9;
            btnEXCLUIR.Text = "EXCLUIR";
            btnEXCLUIR.UseVisualStyleBackColor = true;
            btnEXCLUIR.Click += btnEXCLUIR_Click;
            // 
            // btnCANCELAR
            // 
            btnCANCELAR.Location = new Point(12, 190);
            btnCANCELAR.Name = "btnCANCELAR";
            btnCANCELAR.Size = new Size(75, 23);
            btnCANCELAR.TabIndex = 10;
            btnCANCELAR.Text = "CANCELAR";
            btnCANCELAR.UseVisualStyleBackColor = true;
            btnCANCELAR.Click += btnCANCELAR_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 230);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(282, 94);
            listBox1.TabIndex = 11;
            // 
            // FormCadastroProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 345);
            Controls.Add(listBox1);
            Controls.Add(btnCANCELAR);
            Controls.Add(btnEXCLUIR);
            Controls.Add(btnSALVAR);
            Controls.Add(txtboxIDProd);
            Controls.Add(txtboxDesc);
            Controls.Add(txtboxPreco);
            Controls.Add(txtboxNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCadastroProduto";
            Text = "FormCadastroProduto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtboxNome;
        private TextBox txtboxPreco;
        private TextBox txtboxDesc;
        private TextBox txtboxIDProd;
        private Button btnSALVAR;
        private Button btnEXCLUIR;
        private Button btnCANCELAR;
        private ListBox listBox1;
    }
}