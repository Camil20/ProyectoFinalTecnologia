
namespace NoticiasWinForms
{
    partial class ConsultarCategorias
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dtgConsultarCtg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarCtg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(223, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "CONSULTAR  CATEGORÍAS";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(25, 119);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(590, 23);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dtgConsultarCtg
            // 
            this.dtgConsultarCtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsultarCtg.Location = new System.Drawing.Point(25, 148);
            this.dtgConsultarCtg.Name = "dtgConsultarCtg";
            this.dtgConsultarCtg.RowTemplate.Height = 25;
            this.dtgConsultarCtg.Size = new System.Drawing.Size(751, 276);
            this.dtgConsultarCtg.TabIndex = 3;
            // 
            // ConsultarCategoriascs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dtgConsultarCtg);
            this.Name = "ConsultarCategoriascs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultarCategoriascs";
            this.Load += new System.EventHandler(this.ConsultarCategoriascs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarCtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dtgConsultarCtg;
    }
}