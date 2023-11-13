namespace Proyecto
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.TiempoFechaLb = new System.Windows.Forms.Label();
            this.Wrapper = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ContactarnosBT = new ePOSOne.btnProduct.Button_WOC();
            this.CerrarSesionBT = new ePOSOne.btnProduct.Button_WOC();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Linea1 = new System.Windows.Forms.PictureBox();
            this.ReportesBT = new System.Windows.Forms.Button();
            this.EmailLb = new System.Windows.Forms.Label();
            this.NombreLB = new System.Windows.Forms.Label();
            this.TablasBT = new System.Windows.Forms.Button();
            this.PerfilBT = new System.Windows.Forms.Button();
            this.ImagenPerfilPB = new System.Windows.Forms.PictureBox();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Linea1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPerfilPB)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.buttonMinimize);
            this.panel1.Controls.Add(this.buttonMaximize);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.TiempoFechaLb);
            this.panel1.Location = new System.Drawing.Point(248, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 85);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Gold;
            this.buttonMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.BackgroundImage")));
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Location = new System.Drawing.Point(804, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(79, 85);
            this.buttonMinimize.TabIndex = 0;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMaximize.BackgroundImage")));
            this.buttonMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.ForeColor = System.Drawing.Color.Transparent;
            this.buttonMaximize.Location = new System.Drawing.Point(883, 0);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(79, 85);
            this.buttonMaximize.TabIndex = 1;
            this.buttonMaximize.UseVisualStyleBackColor = false;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Red;
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.Transparent;
            this.buttonClose.Location = new System.Drawing.Point(962, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 85);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // TiempoFechaLb
            // 
            this.TiempoFechaLb.AutoSize = true;
            this.TiempoFechaLb.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoFechaLb.Location = new System.Drawing.Point(29, 23);
            this.TiempoFechaLb.Name = "TiempoFechaLb";
            this.TiempoFechaLb.Size = new System.Drawing.Size(101, 36);
            this.TiempoFechaLb.TabIndex = 0;
            this.TiempoFechaLb.Text = "label1";
            // 
            // Wrapper
            // 
            this.Wrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Wrapper.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Wrapper.Location = new System.Drawing.Point(248, 81);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.Size = new System.Drawing.Size(1058, 752);
            this.Wrapper.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.ContactarnosBT);
            this.panel2.Controls.Add(this.CerrarSesionBT);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.Linea1);
            this.panel2.Controls.Add(this.ReportesBT);
            this.panel2.Controls.Add(this.EmailLb);
            this.panel2.Controls.Add(this.NombreLB);
            this.panel2.Controls.Add(this.TablasBT);
            this.panel2.Controls.Add(this.PerfilBT);
            this.panel2.Controls.Add(this.ImagenPerfilPB);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 824);
            this.panel2.TabIndex = 1;
            // 
            // ContactarnosBT
            // 
            this.ContactarnosBT.BorderColor = System.Drawing.Color.Transparent;
            this.ContactarnosBT.ButtonColor = System.Drawing.Color.ForestGreen;
            this.ContactarnosBT.FlatAppearance.BorderSize = 0;
            this.ContactarnosBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactarnosBT.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactarnosBT.Location = new System.Drawing.Point(33, 731);
            this.ContactarnosBT.Name = "ContactarnosBT";
            this.ContactarnosBT.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.ContactarnosBT.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.ContactarnosBT.OnHoverTextColor = System.Drawing.Color.Gray;
            this.ContactarnosBT.Size = new System.Drawing.Size(182, 64);
            this.ContactarnosBT.TabIndex = 11;
            this.ContactarnosBT.Text = "Contactarnos";
            this.ContactarnosBT.TextColor = System.Drawing.Color.White;
            this.ContactarnosBT.UseVisualStyleBackColor = true;
            this.ContactarnosBT.Click += new System.EventHandler(this.ContactarnosBT_Click);
            // 
            // CerrarSesionBT
            // 
            this.CerrarSesionBT.BorderColor = System.Drawing.Color.Transparent;
            this.CerrarSesionBT.ButtonColor = System.Drawing.Color.SteelBlue;
            this.CerrarSesionBT.FlatAppearance.BorderSize = 0;
            this.CerrarSesionBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CerrarSesionBT.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CerrarSesionBT.Location = new System.Drawing.Point(33, 637);
            this.CerrarSesionBT.Name = "CerrarSesionBT";
            this.CerrarSesionBT.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.CerrarSesionBT.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.CerrarSesionBT.OnHoverTextColor = System.Drawing.Color.Gray;
            this.CerrarSesionBT.Size = new System.Drawing.Size(182, 64);
            this.CerrarSesionBT.TabIndex = 10;
            this.CerrarSesionBT.Text = "Cerrar Sesion";
            this.CerrarSesionBT.TextColor = System.Drawing.Color.White;
            this.CerrarSesionBT.UseVisualStyleBackColor = true;
            this.CerrarSesionBT.Click += new System.EventHandler(this.CerrarSesionBT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 613);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Linea1
            // 
            this.Linea1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Linea1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Linea1.Image = ((System.Drawing.Image)(resources.GetObject("Linea1.Image")));
            this.Linea1.Location = new System.Drawing.Point(13, 316);
            this.Linea1.Name = "Linea1";
            this.Linea1.Size = new System.Drawing.Size(217, 12);
            this.Linea1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Linea1.TabIndex = 8;
            this.Linea1.TabStop = false;
            // 
            // ReportesBT
            // 
            this.ReportesBT.FlatAppearance.BorderSize = 0;
            this.ReportesBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportesBT.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportesBT.Image = ((System.Drawing.Image)(resources.GetObject("ReportesBT.Image")));
            this.ReportesBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReportesBT.Location = new System.Drawing.Point(0, 530);
            this.ReportesBT.Name = "ReportesBT";
            this.ReportesBT.Size = new System.Drawing.Size(252, 53);
            this.ReportesBT.TabIndex = 7;
            this.ReportesBT.Tag = "Reportes";
            this.ReportesBT.Text = "Reportes";
            this.ReportesBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReportesBT.UseVisualStyleBackColor = true;
            this.ReportesBT.Click += new System.EventHandler(this.menu);
            // 
            // EmailLb
            // 
            this.EmailLb.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLb.Location = new System.Drawing.Point(28, 213);
            this.EmailLb.Name = "EmailLb";
            this.EmailLb.Size = new System.Drawing.Size(187, 36);
            this.EmailLb.TabIndex = 6;
            this.EmailLb.Text = "label1";
            this.EmailLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NombreLB
            // 
            this.NombreLB.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLB.Location = new System.Drawing.Point(35, 167);
            this.NombreLB.Name = "NombreLB";
            this.NombreLB.Size = new System.Drawing.Size(180, 36);
            this.NombreLB.TabIndex = 3;
            this.NombreLB.Text = "label1";
            this.NombreLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TablasBT
            // 
            this.TablasBT.FlatAppearance.BorderSize = 0;
            this.TablasBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TablasBT.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TablasBT.Image = ((System.Drawing.Image)(resources.GetObject("TablasBT.Image")));
            this.TablasBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TablasBT.Location = new System.Drawing.Point(0, 445);
            this.TablasBT.Name = "TablasBT";
            this.TablasBT.Size = new System.Drawing.Size(252, 53);
            this.TablasBT.TabIndex = 5;
            this.TablasBT.Tag = "Tablas";
            this.TablasBT.Text = "Tablas";
            this.TablasBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TablasBT.UseVisualStyleBackColor = true;
            this.TablasBT.Click += new System.EventHandler(this.menu);
            // 
            // PerfilBT
            // 
            this.PerfilBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PerfilBT.FlatAppearance.BorderSize = 0;
            this.PerfilBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PerfilBT.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PerfilBT.Image = ((System.Drawing.Image)(resources.GetObject("PerfilBT.Image")));
            this.PerfilBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PerfilBT.Location = new System.Drawing.Point(0, 354);
            this.PerfilBT.Name = "PerfilBT";
            this.PerfilBT.Size = new System.Drawing.Size(252, 53);
            this.PerfilBT.TabIndex = 4;
            this.PerfilBT.Tag = "Perfil";
            this.PerfilBT.Text = "Perfil";
            this.PerfilBT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PerfilBT.UseVisualStyleBackColor = true;
            this.PerfilBT.Click += new System.EventHandler(this.menu);
            // 
            // ImagenPerfilPB
            // 
            this.ImagenPerfilPB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ImagenPerfilPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagenPerfilPB.Image = ((System.Drawing.Image)(resources.GetObject("ImagenPerfilPB.Image")));
            this.ImagenPerfilPB.Location = new System.Drawing.Point(46, 50);
            this.ImagenPerfilPB.Name = "ImagenPerfilPB";
            this.ImagenPerfilPB.Size = new System.Drawing.Size(151, 102);
            this.ImagenPerfilPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImagenPerfilPB.TabIndex = 3;
            this.ImagenPerfilPB.TabStop = false;
            // 
            // Temporizador
            // 
            this.Temporizador.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1286, 816);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Wrapper);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Linea1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPerfilPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ImagenPerfilPB;
        private System.Windows.Forms.Button TablasBT;
        private System.Windows.Forms.Button PerfilBT;
        private System.Windows.Forms.Timer Temporizador;
        private System.Windows.Forms.Label TiempoFechaLb;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.Label NombreLB;
        private System.Windows.Forms.Label EmailLb;
        private System.Windows.Forms.Button ReportesBT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Linea1;
        private ePOSOne.btnProduct.Button_WOC ContactarnosBT;
        private ePOSOne.btnProduct.Button_WOC CerrarSesionBT;
    }
}