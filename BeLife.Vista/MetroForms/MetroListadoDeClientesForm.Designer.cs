namespace BeLife.Vista.MetroForms
{
    partial class MetroListadoDeClientesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroListadoDeClientesForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cancelarMetroButton = new MetroFramework.Controls.MetroButton();
            this.aceptarMetroButton = new MetroFramework.Controls.MetroButton();
            this.formularioTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listadoDataGridView = new MetroFramework.Controls.MetroGrid();
            this.formularioMetroContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoLabel = new MetroFramework.Controls.MetroLabel();
            this.textoMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.ayudaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.filtroMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.filtrosTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.formularioPictureBox = new System.Windows.Forms.PictureBox();
            this.filtrosLabel = new MetroFramework.Controls.MetroLabel();
            this.filtrosComboBox = new MetroFramework.Controls.MetroComboBox();
            this.valorFiltroLabel = new MetroFramework.Controls.MetroLabel();
            this.valorFiltroTextBox = new MetroFramework.Controls.MetroTextBox();
            this.buscarButton = new MetroFramework.Controls.MetroButton();
            this.valorFiltroComboBox = new MetroFramework.Controls.MetroComboBox();
            this.formularioMetroToolTip = new MetroFramework.Components.MetroToolTip();
            this.formularioMetroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.formularioMetroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.formularioTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).BeginInit();
            this.formularioMetroContextMenu.SuspendLayout();
            this.filtroMetroPanel.SuspendLayout();
            this.filtrosTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formularioPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelarMetroButton
            // 
            resources.ApplyResources(this.cancelarMetroButton, "cancelarMetroButton");
            this.cancelarMetroButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.cancelarMetroButton.Name = "cancelarMetroButton";
            this.cancelarMetroButton.UseSelectable = true;
            this.cancelarMetroButton.UseStyleColors = true;
            this.cancelarMetroButton.Click += new System.EventHandler(this.cancelarMetroButton_Click);
            // 
            // aceptarMetroButton
            // 
            resources.ApplyResources(this.aceptarMetroButton, "aceptarMetroButton");
            this.aceptarMetroButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptarMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.aceptarMetroButton.Name = "aceptarMetroButton";
            this.aceptarMetroButton.UseSelectable = true;
            this.aceptarMetroButton.UseStyleColors = true;
            this.aceptarMetroButton.Click += new System.EventHandler(this.aceptarMetroButton_Click);
            // 
            // formularioTableLayoutPanel
            // 
            resources.ApplyResources(this.formularioTableLayoutPanel, "formularioTableLayoutPanel");
            this.formularioTableLayoutPanel.Controls.Add(this.listadoDataGridView, 1, 1);
            this.formularioTableLayoutPanel.Controls.Add(this.listadoLabel, 1, 0);
            this.formularioTableLayoutPanel.Controls.Add(this.textoMetroLabel, 0, 3);
            this.formularioTableLayoutPanel.Controls.Add(this.aceptarMetroButton, 1, 2);
            this.formularioTableLayoutPanel.Controls.Add(this.cancelarMetroButton, 2, 2);
            this.formularioTableLayoutPanel.Controls.Add(this.ayudaMetroLabel, 2, 0);
            this.formularioTableLayoutPanel.Controls.Add(this.filtroMetroPanel, 0, 0);
            this.formularioTableLayoutPanel.Name = "formularioTableLayoutPanel";
            // 
            // listadoDataGridView
            // 
            this.listadoDataGridView.AllowUserToAddRows = false;
            this.listadoDataGridView.AllowUserToDeleteRows = false;
            this.listadoDataGridView.AllowUserToOrderColumns = true;
            this.listadoDataGridView.AllowUserToResizeColumns = false;
            this.listadoDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.listadoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.listadoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listadoDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listadoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listadoDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listadoDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(65)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listadoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.listadoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoDataGridView.ContextMenuStrip = this.formularioMetroContextMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(65)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listadoDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.listadoDataGridView, "listadoDataGridView");
            this.listadoDataGridView.EnableHeadersVisualStyles = false;
            this.listadoDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listadoDataGridView.HighLightPercentage = 0F;
            this.listadoDataGridView.MultiSelect = false;
            this.listadoDataGridView.Name = "listadoDataGridView";
            this.listadoDataGridView.ReadOnly = true;
            this.listadoDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(65)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listadoDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listadoDataGridView.RowHeadersVisible = false;
            this.listadoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.listadoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.listadoDataGridView.RowTemplate.Height = 23;
            this.listadoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoDataGridView.ShowCellToolTips = false;
            this.listadoDataGridView.ShowEditingIcon = false;
            this.listadoDataGridView.ShowRowErrors = false;
            this.listadoDataGridView.Style = MetroFramework.MetroColorStyle.Purple;
            this.listadoDataGridView.UseCustomBackColor = true;
            this.listadoDataGridView.UseCustomForeColor = true;
            this.listadoDataGridView.SelectionChanged += new System.EventHandler(this.listadoDataGridView_SelectionChanged);
            this.listadoDataGridView.DoubleClick += new System.EventHandler(this.listadoDataGridView_DoubleClick);
            // 
            // formularioMetroContextMenu
            // 
            this.formularioMetroContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.formularioMetroContextMenu.DropShadowEnabled = false;
            resources.ApplyResources(this.formularioMetroContextMenu, "formularioMetroContextMenu");
            this.formularioMetroContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.formularioMetroContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.formularioMetroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.toolStripSeparator,
            this.editarToolStripMenuItem});
            this.formularioMetroContextMenu.Name = "formularioMetroContextMenu";
            this.formularioMetroContextMenu.ShowItemToolTips = false;
            this.formularioMetroContextMenu.Style = MetroFramework.MetroColorStyle.Purple;
            this.formularioMetroContextMenu.UseCustomBackColor = true;
            this.formularioMetroContextMenu.UseStyleColors = true;
            // 
            // nuevoToolStripMenuItem
            // 
            resources.ApplyResources(this.nuevoToolStripMenuItem, "nuevoToolStripMenuItem");
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // editarToolStripMenuItem
            // 
            resources.ApplyResources(this.editarToolStripMenuItem, "editarToolStripMenuItem");
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // listadoLabel
            // 
            resources.ApplyResources(this.listadoLabel, "listadoLabel");
            this.listadoLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.listadoLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.listadoLabel.Name = "listadoLabel";
            this.listadoLabel.WrapToLine = true;
            // 
            // textoMetroLabel
            // 
            resources.ApplyResources(this.textoMetroLabel, "textoMetroLabel");
            this.formularioTableLayoutPanel.SetColumnSpan(this.textoMetroLabel, 3);
            this.textoMetroLabel.Name = "textoMetroLabel";
            this.textoMetroLabel.Style = MetroFramework.MetroColorStyle.Black;
            // 
            // ayudaMetroLabel
            // 
            this.ayudaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            resources.ApplyResources(this.ayudaMetroLabel, "ayudaMetroLabel");
            this.ayudaMetroLabel.Name = "ayudaMetroLabel";
            this.formularioTableLayoutPanel.SetRowSpan(this.ayudaMetroLabel, 2);
            this.ayudaMetroLabel.WrapToLine = true;
            // 
            // filtroMetroPanel
            // 
            this.filtroMetroPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filtroMetroPanel.Controls.Add(this.filtrosTableLayoutPanel);
            this.filtroMetroPanel.Controls.Add(this.valorFiltroComboBox);
            resources.ApplyResources(this.filtroMetroPanel, "filtroMetroPanel");
            this.filtroMetroPanel.HorizontalScrollbarBarColor = true;
            this.filtroMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.filtroMetroPanel.HorizontalScrollbarSize = 10;
            this.filtroMetroPanel.Name = "filtroMetroPanel";
            this.formularioTableLayoutPanel.SetRowSpan(this.filtroMetroPanel, 3);
            this.filtroMetroPanel.VerticalScrollbarBarColor = true;
            this.filtroMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.filtroMetroPanel.VerticalScrollbarSize = 10;
            // 
            // filtrosTableLayoutPanel
            // 
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.filtrosTableLayoutPanel, true);
            resources.ApplyResources(this.filtrosTableLayoutPanel, "filtrosTableLayoutPanel");
            this.filtrosTableLayoutPanel.Controls.Add(this.formularioPictureBox, 0, 5);
            this.filtrosTableLayoutPanel.Controls.Add(this.filtrosLabel, 0, 0);
            this.filtrosTableLayoutPanel.Controls.Add(this.filtrosComboBox, 0, 1);
            this.filtrosTableLayoutPanel.Controls.Add(this.valorFiltroLabel, 0, 2);
            this.filtrosTableLayoutPanel.Controls.Add(this.valorFiltroTextBox, 0, 3);
            this.filtrosTableLayoutPanel.Controls.Add(this.buscarButton, 0, 4);
            this.filtrosTableLayoutPanel.Name = "filtrosTableLayoutPanel";
            // 
            // formularioPictureBox
            // 
            resources.ApplyResources(this.formularioPictureBox, "formularioPictureBox");
            this.formularioPictureBox.Image = global::BeLife.Vista.Properties.Resources.listaDeClientes;
            this.formularioPictureBox.Name = "formularioPictureBox";
            this.formularioPictureBox.TabStop = false;
            // 
            // filtrosLabel
            // 
            resources.ApplyResources(this.filtrosLabel, "filtrosLabel");
            this.filtrosLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.filtrosLabel.Name = "filtrosLabel";
            this.filtrosLabel.WrapToLine = true;
            // 
            // filtrosComboBox
            // 
            resources.ApplyResources(this.filtrosComboBox, "filtrosComboBox");
            this.filtrosComboBox.FormattingEnabled = true;
            this.filtrosComboBox.Name = "filtrosComboBox";
            this.filtrosComboBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.filtrosComboBox.UseSelectable = true;
            this.filtrosComboBox.SelectedIndexChanged += new System.EventHandler(this.filtrosComboBox_SelectedIndexChanged);
            // 
            // valorFiltroLabel
            // 
            resources.ApplyResources(this.valorFiltroLabel, "valorFiltroLabel");
            this.valorFiltroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.valorFiltroLabel.Name = "valorFiltroLabel";
            this.valorFiltroLabel.WrapToLine = true;
            // 
            // valorFiltroTextBox
            // 
            this.valorFiltroTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.valorFiltroTextBox.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.valorFiltroTextBox.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.valorFiltroTextBox.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.valorFiltroTextBox.CustomButton.Name = "";
            this.valorFiltroTextBox.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.valorFiltroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.valorFiltroTextBox.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.valorFiltroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.valorFiltroTextBox.CustomButton.UseSelectable = true;
            this.valorFiltroTextBox.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            resources.ApplyResources(this.valorFiltroTextBox, "valorFiltroTextBox");
            this.valorFiltroTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.valorFiltroTextBox.Lines = new string[0];
            this.valorFiltroTextBox.MaxLength = 10;
            this.valorFiltroTextBox.Name = "valorFiltroTextBox";
            this.valorFiltroTextBox.PasswordChar = '\0';
            this.valorFiltroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.valorFiltroTextBox.SelectedText = "";
            this.valorFiltroTextBox.SelectionLength = 0;
            this.valorFiltroTextBox.SelectionStart = 0;
            this.valorFiltroTextBox.ShortcutsEnabled = true;
            this.valorFiltroTextBox.ShowClearButton = true;
            this.valorFiltroTextBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.valorFiltroTextBox.UseSelectable = true;
            this.valorFiltroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.valorFiltroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buscarButton
            // 
            resources.ApplyResources(this.buscarButton, "buscarButton");
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.UseSelectable = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // valorFiltroComboBox
            // 
            this.valorFiltroComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.valorFiltroComboBox, "valorFiltroComboBox");
            this.valorFiltroComboBox.Name = "valorFiltroComboBox";
            this.valorFiltroComboBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.valorFiltroComboBox.UseSelectable = true;
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
            // MetroListadoDeClientesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(3);
            this.BackMaxSize = 50;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.Controls.Add(this.formularioTableLayoutPanel);
            this.Name = "MetroListadoDeClientesForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Load += new System.EventHandler(this.MetroListadoDeClientesForm_Load);
            this.formularioTableLayoutPanel.ResumeLayout(false);
            this.formularioTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).EndInit();
            this.formularioMetroContextMenu.ResumeLayout(false);
            this.filtroMetroPanel.ResumeLayout(false);
            this.filtrosTableLayoutPanel.ResumeLayout(false);
            this.filtrosTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formularioPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton cancelarMetroButton;
        private MetroFramework.Controls.MetroButton aceptarMetroButton;
        private System.Windows.Forms.TableLayoutPanel formularioTableLayoutPanel;
        private MetroFramework.Controls.MetroLabel textoMetroLabel;
        private MetroFramework.Controls.MetroLabel ayudaMetroLabel;
        private MetroFramework.Controls.MetroPanel filtroMetroPanel;
        private MetroFramework.Controls.MetroLabel listadoLabel;
        private MetroFramework.Controls.MetroButton buscarButton;
        private MetroFramework.Controls.MetroComboBox valorFiltroComboBox;
        private MetroFramework.Controls.MetroTextBox valorFiltroTextBox;
        private MetroFramework.Controls.MetroLabel valorFiltroLabel;
        private MetroFramework.Controls.MetroComboBox filtrosComboBox;
        private MetroFramework.Controls.MetroLabel filtrosLabel;
        private MetroFramework.Components.MetroToolTip formularioMetroToolTip;
        private MetroFramework.Components.MetroStyleExtender formularioMetroStyleExtender;
        private MetroFramework.Controls.MetroGrid listadoDataGridView;
        private MetroFramework.Controls.MetroContextMenu formularioMetroContextMenu;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.TableLayoutPanel filtrosTableLayoutPanel;
        private System.Windows.Forms.PictureBox formularioPictureBox;
        private MetroFramework.Components.MetroStyleManager formularioMetroStyleManager;
    }
}