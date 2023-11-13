namespace Proyecto
{
    partial class MenuReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuReportes));
            this.PerfilBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PerfilBT
            // 
            this.PerfilBT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PerfilBT.BackColor = System.Drawing.Color.Lime;
            this.PerfilBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PerfilBT.FlatAppearance.BorderSize = 0;
            this.PerfilBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PerfilBT.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerfilBT.Image = ((System.Drawing.Image)(resources.GetObject("PerfilBT.Image")));
            this.PerfilBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PerfilBT.Location = new System.Drawing.Point(134, 100);
            this.PerfilBT.Name = "PerfilBT";
            this.PerfilBT.Size = new System.Drawing.Size(308, 99);
            this.PerfilBT.TabIndex = 6;
            this.PerfilBT.Tag = "Clientes";
            this.PerfilBT.Text = "Clientes Mensuales Registrados";
            this.PerfilBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PerfilBT.UseVisualStyleBackColor = false;
            this.PerfilBT.Click += new System.EventHandler(this.menu);
            // 
            // MenuReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 540);
            this.Controls.Add(this.PerfilBT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuReportes";
            this.Text = "MenuReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PerfilBT;
    }
}