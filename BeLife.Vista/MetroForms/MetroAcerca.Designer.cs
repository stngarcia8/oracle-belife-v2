namespace BeLife.Vista.MetroForms
{
    partial class MetroAcerca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroAcerca));
            this.formularioFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.formularioPictureBox = new System.Windows.Forms.PictureBox();
            this.textoFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.textoMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.cerrarMetroButton = new MetroFramework.Controls.MetroButton();
            this.formularioMetroToolTip = new MetroFramework.Components.MetroToolTip();
            this.formularioMetroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.formularioMetroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.formularioFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formularioPictureBox)).BeginInit();
            this.textoFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // formularioFlowLayoutPanel
            // 
            this.formularioFlowLayoutPanel.Controls.Add(this.formularioPictureBox);
            this.formularioFlowLayoutPanel.Controls.Add(this.textoFlowLayoutPanel);
            resources.ApplyResources(this.formularioFlowLayoutPanel, "formularioFlowLayoutPanel");
            this.formularioFlowLayoutPanel.Name = "formularioFlowLayoutPanel";
            // 
            // formularioPictureBox
            // 
            this.formularioPictureBox.Image = global::BeLife.Vista.Properties.Resources.Logo_SinFondo_BeLife;
            resources.ApplyResources(this.formularioPictureBox, "formularioPictureBox");
            this.formularioPictureBox.Name = "formularioPictureBox";
            this.formularioPictureBox.TabStop = false;
            // 
            // textoFlowLayoutPanel
            // 
            this.textoFlowLayoutPanel.Controls.Add(this.textoMetroLabel);
            this.textoFlowLayoutPanel.Controls.Add(this.cerrarMetroButton);
            resources.ApplyResources(this.textoFlowLayoutPanel, "textoFlowLayoutPanel");
            this.textoFlowLayoutPanel.Name = "textoFlowLayoutPanel";
            // 
            // textoMetroLabel
            // 
            this.textoMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.textoMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            resources.ApplyResources(this.textoMetroLabel, "textoMetroLabel");
            this.textoMetroLabel.Name = "textoMetroLabel";
            this.textoMetroLabel.Style = MetroFramework.MetroColorStyle.Purple;
            this.textoMetroLabel.UseStyleColors = true;
            this.textoMetroLabel.WrapToLine = true;
            // 
            // cerrarMetroButton
            // 
            this.cerrarMetroButton.BackColor = System.Drawing.Color.MediumOrchid;
            this.cerrarMetroButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cerrarMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            resources.ApplyResources(this.cerrarMetroButton, "cerrarMetroButton");
            this.cerrarMetroButton.Name = "cerrarMetroButton";
            this.cerrarMetroButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.cerrarMetroButton.UseCustomBackColor = true;
            this.cerrarMetroButton.UseSelectable = true;
            this.cerrarMetroButton.UseStyleColors = true;
            // 
            // formularioMetroToolTip
            // 
            this.formularioMetroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.formularioMetroToolTip.StyleManager = null;
            this.formularioMetroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // formularioMetroStyleManager
            // 
            this.formularioMetroStyleManager.Owner = this;
            this.formularioMetroStyleManager.Style = MetroFramework.MetroColorStyle.Black;
            // 
            // MetroAcerca
            // 
            this.AcceptButton = this.cerrarMetroButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImagePadding = new System.Windows.Forms.Padding(3);
            this.BackMaxSize = 60;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.Controls.Add(this.formularioFlowLayoutPanel);
            this.Name = "MetroAcerca";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Load += new System.EventHandler(this.MetroAcerca_Load);
            this.formularioFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formularioPictureBox)).EndInit();
            this.textoFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel formularioFlowLayoutPanel;
        private System.Windows.Forms.PictureBox formularioPictureBox;
        private System.Windows.Forms.FlowLayoutPanel textoFlowLayoutPanel;
        private MetroFramework.Controls.MetroLabel textoMetroLabel;
        private MetroFramework.Controls.MetroButton cerrarMetroButton;
        private MetroFramework.Components.MetroToolTip formularioMetroToolTip;
        private MetroFramework.Components.MetroStyleExtender formularioMetroStyleExtender;
        private MetroFramework.Components.MetroStyleManager formularioMetroStyleManager;
    }
}