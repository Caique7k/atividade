namespace atividade
{
    partial class FormMenu
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            cadastroDeToolStripMenuItem = new ToolStripMenuItem();
            cadastroDeProdutosToolStripMenuItem = new ToolStripMenuItem();
            cadastroDePedidosToolStripMenuItem = new ToolStripMenuItem();
            cadastroDeUsuáriosToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastroDeToolStripMenuItem, cadastroDeProdutosToolStripMenuItem, cadastroDePedidosToolStripMenuItem, cadastroDeUsuáriosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(526, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastroDeToolStripMenuItem
            // 
            cadastroDeToolStripMenuItem.Name = "cadastroDeToolStripMenuItem";
            cadastroDeToolStripMenuItem.Size = new Size(127, 20);
            cadastroDeToolStripMenuItem.Text = "Cadastro de Clientes";
            cadastroDeToolStripMenuItem.Click += cadastroDeToolStripMenuItem_Click;
            // 
            // cadastroDeProdutosToolStripMenuItem
            // 
            cadastroDeProdutosToolStripMenuItem.Name = "cadastroDeProdutosToolStripMenuItem";
            cadastroDeProdutosToolStripMenuItem.Size = new Size(133, 20);
            cadastroDeProdutosToolStripMenuItem.Text = "Cadastro de Produtos";
            cadastroDeProdutosToolStripMenuItem.Click += cadastroDeProdutosToolStripMenuItem_Click;
            // 
            // cadastroDePedidosToolStripMenuItem
            // 
            cadastroDePedidosToolStripMenuItem.Name = "cadastroDePedidosToolStripMenuItem";
            cadastroDePedidosToolStripMenuItem.Size = new Size(127, 20);
            cadastroDePedidosToolStripMenuItem.Text = "Cadastro de Pedidos";
            cadastroDePedidosToolStripMenuItem.Click += cadastroDePedidosToolStripMenuItem_Click;
            // 
            // cadastroDeUsuáriosToolStripMenuItem
            // 
            cadastroDeUsuáriosToolStripMenuItem.Name = "cadastroDeUsuáriosToolStripMenuItem";
            cadastroDeUsuáriosToolStripMenuItem.Size = new Size(130, 20);
            cadastroDeUsuáriosToolStripMenuItem.Text = "Cadastro de Usuários";
            cadastroDeUsuáriosToolStripMenuItem.Click += cadastroDeUsuáriosToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(201, 41);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 77);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenu";
            Text = "FormMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastroDeToolStripMenuItem;
        private ToolStripMenuItem cadastroDeProdutosToolStripMenuItem;
        private ToolStripMenuItem cadastroDePedidosToolStripMenuItem;
        private ToolStripMenuItem cadastroDeUsuáriosToolStripMenuItem;
        private Label label1;
    }
}