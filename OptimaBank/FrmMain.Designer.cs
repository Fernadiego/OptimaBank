
namespace OptimaBank
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            menuStrip1 = new MenuStrip();
            sesionToolStripMenuItem = new ToolStripMenuItem();
            iniciarToolStripMenuItem = new ToolStripMenuItem();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripDropDownButton = new ToolStripDropDownButton();
            francesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            inglesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            espanolToolStripMenuItem = new ToolStripMenuItem();
            tssMensaje = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // sesionToolStripMenuItem
            // 
            sesionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarToolStripMenuItem, cerrarToolStripMenuItem });
            sesionToolStripMenuItem.Name = "sesionToolStripMenuItem";
            sesionToolStripMenuItem.Size = new Size(53, 20);
            sesionToolStripMenuItem.Tag = "MENU_SESSION";
            sesionToolStripMenuItem.Text = "Sesión";
            // 
            // iniciarToolStripMenuItem
            // 
            iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            iniciarToolStripMenuItem.Size = new Size(106, 22);
            iniciarToolStripMenuItem.Tag = "MENU_INICIAR";
            iniciarToolStripMenuItem.Text = "Iniciar";
            iniciarToolStripMenuItem.Click += iniciarToolStripMenuItem_Click;
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(106, 22);
            cerrarToolStripMenuItem.Tag = "MENU_CERRAR";
            cerrarToolStripMenuItem.Text = "Cerrar";
            cerrarToolStripMenuItem.Click += cerrarToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton, tssMensaje });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton
            // 
            toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { francesToolStripMenuItem, toolStripSeparator1, inglesToolStripMenuItem, toolStripSeparator2, espanolToolStripMenuItem });
            toolStripDropDownButton.Image = (Image)resources.GetObject("toolStripDropDownButton.Image");
            toolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton.Name = "toolStripDropDownButton";
            toolStripDropDownButton.Size = new Size(29, 20);
            toolStripDropDownButton.Text = "toolStripDropDownButton1";
            // 
            // francesToolStripMenuItem
            // 
            francesToolStripMenuItem.Image = (Image)resources.GetObject("francesToolStripMenuItem.Image");
            francesToolStripMenuItem.Name = "francesToolStripMenuItem";
            francesToolStripMenuItem.Size = new Size(229, 22);
            francesToolStripMenuItem.Text = "POR - Portugués Brasil";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(226, 6);
            // 
            // inglesToolStripMenuItem
            // 
            inglesToolStripMenuItem.Image = (Image)resources.GetObject("inglesToolStripMenuItem.Image");
            inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            inglesToolStripMenuItem.Size = new Size(229, 22);
            inglesToolStripMenuItem.Text = "ENG - Inglés United Kingdom";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(226, 6);
            // 
            // espanolToolStripMenuItem
            // 
            espanolToolStripMenuItem.Checked = true;
            espanolToolStripMenuItem.CheckState = CheckState.Checked;
            espanolToolStripMenuItem.Image = (Image)resources.GetObject("espanolToolStripMenuItem.Image");
            espanolToolStripMenuItem.Name = "espanolToolStripMenuItem";
            espanolToolStripMenuItem.Size = new Size(229, 22);
            espanolToolStripMenuItem.Text = "ESP - Español Argentina";
            // 
            // tssMensaje
            // 
            tssMensaje.Name = "tssMensaje";
            tssMensaje.Size = new Size(0, 17);
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Tag = "LABEL_TITULO";
            Text = "Optima Bank - Software de Gestión Bancaria";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem sesionToolStripMenuItem;
        private ToolStripMenuItem iniciarToolStripMenuItem;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripDropDownButton toolStripDropDownButton;
        private ToolStripMenuItem francesToolStripMenuItem;
        private ToolStripMenuItem inglesToolStripMenuItem;
        private ToolStripMenuItem espanolToolStripMenuItem;
        private ToolStripStatusLabel tssMensaje;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
    }
}