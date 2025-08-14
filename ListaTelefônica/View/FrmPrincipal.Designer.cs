namespace ListaTelefônica.View
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(12, 69);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(776, 312);
            this.dgvLista.TabIndex = 0;
            // 
            // btAdicionar
            // 
            this.btAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btAdicionar.Location = new System.Drawing.Point(12, 391);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(135, 51);
            this.btAdicionar.TabIndex = 5;
            this.btAdicionar.Text = "&Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // btEditar
            // 
            this.btEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btEditar.Location = new System.Drawing.Point(153, 391);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(135, 51);
            this.btEditar.TabIndex = 6;
            this.btEditar.Text = "&Editar";
            this.btEditar.UseVisualStyleBackColor = true;
            // 
            // btRemover
            // 
            this.btRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btRemover.Location = new System.Drawing.Point(653, 391);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(135, 51);
            this.btRemover.TabIndex = 7;
            this.btRemover.Text = "&Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btBuscar.Location = new System.Drawing.Point(580, 9);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(208, 51);
            this.btBuscar.TabIndex = 8;
            this.btBuscar.Text = "&Buscar Contato";
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtBusca.Location = new System.Drawing.Point(12, 12);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(562, 45);
            this.txtBusca.TabIndex = 9;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btRemover);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.dgvLista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.Text = "Lista Telefônica";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.TextBox txtBusca;
    }
}