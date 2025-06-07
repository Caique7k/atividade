namespace atividade
{
    partial class FormNovaSenha
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
            button1 = new Button();
            txtNovaSenha = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 16);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "NOVA SENHA";
            // 
            // button1
            // 
            button1.Location = new Point(198, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "SALVAR";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.Location = new Point(86, 12);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.Size = new Size(100, 23);
            txtNovaSenha.TabIndex = 2;
            // 
            // FormNovaSenha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 55);
            Controls.Add(txtNovaSenha);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "FormNovaSenha";
            Text = "FormNovaSenha";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox txtNovaSenha;
    }
}