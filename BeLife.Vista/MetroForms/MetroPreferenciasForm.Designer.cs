namespace BeLife.Vista.MetroForms
{
    partial class MetroPreferenciasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroPreferenciasForm));
            this.formularioTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.botonesMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.botonesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.visualizacionMetroButton = new MetroFramework.Controls.MetroButton();
            this.idiomasMetroButton = new MetroFramework.Controls.MetroButton();
            this.ayudaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.aceptarMetroButton = new MetroFramework.Controls.MetroButton();
            this.cancelarMetroButton = new MetroFramework.Controls.MetroButton();
            this.opcionesMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.idiomaMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.idiomasTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.referenciaActualMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.idiomaActualMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.idiomaActualMetroTextBox = new MetroFramework.Controls.MetroTextBox();
            this.nuevaNomenclaturaMetroTextBox = new MetroFramework.Controls.MetroTextBox();
            this.nomenclaturaActualMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.nuevaNomenclaturaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.nomenclaturaActualMetroTextBox = new MetroFramework.Controls.MetroTextBox();
            this.nuevoIdiomaMetroComboBox = new MetroFramework.Controls.MetroComboBox();
            this.nuevaReferenciaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.nuevoIdiomaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.visualizacionMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.visualizacionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.temaActualMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.mostrarTemaPictureBox = new System.Windows.Forms.PictureBox();
            this.seleccioneTemaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.mostrarAyudaMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.mostrarAyudaMetroToggle = new MetroFramework.Controls.MetroToggle();
            this.temaMetroComboBox = new MetroFramework.Controls.MetroComboBox();
            this.formularioMetroToolTip = new MetroFramework.Components.MetroToolTip();
            this.formularioMetroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.formularioMetroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.formularioTableLayoutPanel.SuspendLayout();
            this.botonesMetroPanel.SuspendLayout();
            this.botonesTableLayoutPanel.SuspendLayout();
            this.opcionesMetroPanel.SuspendLayout();
            this.idiomaMetroPanel.SuspendLayout();
            this.idiomasTableLayoutPanel.SuspendLayout();
            this.visualizacionMetroPanel.SuspendLayout();
            this.visualizacionTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarTemaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // formularioTableLayoutPanel
            // 
            resources.ApplyResources(this.formularioTableLayoutPanel, "formularioTableLayoutPanel");
            this.formularioTableLayoutPanel.Controls.Add(this.botonesMetroPanel, 0, 0);
            this.formularioTableLayoutPanel.Controls.Add(this.ayudaMetroLabel, 2, 0);
            this.formularioTableLayoutPanel.Controls.Add(this.aceptarMetroButton, 1, 1);
            this.formularioTableLayoutPanel.Controls.Add(this.cancelarMetroButton, 2, 1);
            this.formularioTableLayoutPanel.Controls.Add(this.opcionesMetroPanel, 1, 0);
            this.formularioTableLayoutPanel.Name = "formularioTableLayoutPanel";
            // 
            // botonesMetroPanel
            // 
            this.botonesMetroPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botonesMetroPanel.Controls.Add(this.botonesTableLayoutPanel);
            resources.ApplyResources(this.botonesMetroPanel, "botonesMetroPanel");
            this.botonesMetroPanel.HorizontalScrollbarBarColor = true;
            this.botonesMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.botonesMetroPanel.HorizontalScrollbarSize = 10;
            this.botonesMetroPanel.Name = "botonesMetroPanel";
            this.formularioTableLayoutPanel.SetRowSpan(this.botonesMetroPanel, 2);
            this.botonesMetroPanel.Style = MetroFramework.MetroColorStyle.Silver;
            this.botonesMetroPanel.UseStyleColors = true;
            this.botonesMetroPanel.VerticalScrollbarBarColor = true;
            this.botonesMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.botonesMetroPanel.VerticalScrollbarSize = 10;
            // 
            // botonesTableLayoutPanel
            // 
            resources.ApplyResources(this.botonesTableLayoutPanel, "botonesTableLayoutPanel");
            this.botonesTableLayoutPanel.Controls.Add(this.visualizacionMetroButton, 0, 0);
            this.botonesTableLayoutPanel.Controls.Add(this.idiomasMetroButton, 0, 1);
            this.botonesTableLayoutPanel.Name = "botonesTableLayoutPanel";
            // 
            // visualizacionMetroButton
            // 
            this.visualizacionMetroButton.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.visualizacionMetroButton, "visualizacionMetroButton");
            this.visualizacionMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.visualizacionMetroButton.Name = "visualizacionMetroButton";
            this.visualizacionMetroButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.visualizacionMetroButton.UseSelectable = true;
            this.visualizacionMetroButton.Click += new System.EventHandler(this.colorMetroButton_Click);
            // 
            // idiomasMetroButton
            // 
            this.idiomasMetroButton.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.idiomasMetroButton, "idiomasMetroButton");
            this.idiomasMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.idiomasMetroButton.Name = "idiomasMetroButton";
            this.idiomasMetroButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.idiomasMetroButton.UseSelectable = true;
            this.idiomasMetroButton.Click += new System.EventHandler(this.idiomasMetroButton_Click);
            // 
            // ayudaMetroLabel
            // 
            resources.ApplyResources(this.ayudaMetroLabel, "ayudaMetroLabel");
            this.ayudaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.ayudaMetroLabel.Name = "ayudaMetroLabel";
            this.ayudaMetroLabel.WrapToLine = true;
            // 
            // aceptarMetroButton
            // 
            resources.ApplyResources(this.aceptarMetroButton, "aceptarMetroButton");
            this.aceptarMetroButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptarMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.aceptarMetroButton.Name = "aceptarMetroButton";
            this.aceptarMetroButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.aceptarMetroButton.UseSelectable = true;
            this.aceptarMetroButton.Click += new System.EventHandler(this.aceptarMetroButton_Click);
            // 
            // cancelarMetroButton
            // 
            resources.ApplyResources(this.cancelarMetroButton, "cancelarMetroButton");
            this.cancelarMetroButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarMetroButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.cancelarMetroButton.Name = "cancelarMetroButton";
            this.cancelarMetroButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.cancelarMetroButton.UseSelectable = true;
            this.cancelarMetroButton.Click += new System.EventHandler(this.cancelarMetroButton_Click);
            // 
            // opcionesMetroPanel
            // 
            this.opcionesMetroPanel.Controls.Add(this.idiomaMetroPanel);
            this.opcionesMetroPanel.Controls.Add(this.visualizacionMetroPanel);
            resources.ApplyResources(this.opcionesMetroPanel, "opcionesMetroPanel");
            this.opcionesMetroPanel.HorizontalScrollbarBarColor = true;
            this.opcionesMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.opcionesMetroPanel.HorizontalScrollbarSize = 10;
            this.opcionesMetroPanel.Name = "opcionesMetroPanel";
            this.opcionesMetroPanel.VerticalScrollbarBarColor = true;
            this.opcionesMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.opcionesMetroPanel.VerticalScrollbarSize = 10;
            // 
            // idiomaMetroPanel
            // 
            this.idiomaMetroPanel.Controls.Add(this.idiomasTableLayoutPanel);
            resources.ApplyResources(this.idiomaMetroPanel, "idiomaMetroPanel");
            this.idiomaMetroPanel.HorizontalScrollbarBarColor = true;
            this.idiomaMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.idiomaMetroPanel.HorizontalScrollbarSize = 10;
            this.idiomaMetroPanel.Name = "idiomaMetroPanel";
            this.idiomaMetroPanel.VerticalScrollbarBarColor = true;
            this.idiomaMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.idiomaMetroPanel.VerticalScrollbarSize = 10;
            // 
            // idiomasTableLayoutPanel
            // 
            resources.ApplyResources(this.idiomasTableLayoutPanel, "idiomasTableLayoutPanel");
            this.idiomasTableLayoutPanel.Controls.Add(this.referenciaActualMetroLabel, 0, 0);
            this.idiomasTableLayoutPanel.Controls.Add(this.idiomaActualMetroLabel, 0, 1);
            this.idiomasTableLayoutPanel.Controls.Add(this.idiomaActualMetroTextBox, 1, 1);
            this.idiomasTableLayoutPanel.Controls.Add(this.nuevaNomenclaturaMetroTextBox, 1, 5);
            this.idiomasTableLayoutPanel.Controls.Add(this.nomenclaturaActualMetroLabel, 0, 2);
            this.idiomasTableLayoutPanel.Controls.Add(this.nuevaNomenclaturaMetroLabel, 0, 5);
            this.idiomasTableLayoutPanel.Controls.Add(this.nomenclaturaActualMetroTextBox, 1, 2);
            this.idiomasTableLayoutPanel.Controls.Add(this.nuevoIdiomaMetroComboBox, 1, 4);
            this.idiomasTableLayoutPanel.Controls.Add(this.nuevaReferenciaMetroLabel, 0, 3);
            this.idiomasTableLayoutPanel.Controls.Add(this.nuevoIdiomaMetroLabel, 0, 4);
            this.idiomasTableLayoutPanel.Name = "idiomasTableLayoutPanel";
            // 
            // referenciaActualMetroLabel
            // 
            resources.ApplyResources(this.referenciaActualMetroLabel, "referenciaActualMetroLabel");
            this.idiomasTableLayoutPanel.SetColumnSpan(this.referenciaActualMetroLabel, 3);
            this.referenciaActualMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.referenciaActualMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.referenciaActualMetroLabel.Name = "referenciaActualMetroLabel";
            this.referenciaActualMetroLabel.WrapToLine = true;
            // 
            // idiomaActualMetroLabel
            // 
            resources.ApplyResources(this.idiomaActualMetroLabel, "idiomaActualMetroLabel");
            this.idiomaActualMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.idiomaActualMetroLabel.Name = "idiomaActualMetroLabel";
            this.idiomaActualMetroLabel.WrapToLine = true;
            // 
            // idiomaActualMetroTextBox
            // 
            resources.ApplyResources(this.idiomaActualMetroTextBox, "idiomaActualMetroTextBox");
            // 
            // 
            // 
            this.idiomaActualMetroTextBox.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.idiomaActualMetroTextBox.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.idiomaActualMetroTextBox.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.idiomaActualMetroTextBox.CustomButton.Name = "";
            this.idiomaActualMetroTextBox.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.idiomaActualMetroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.idiomaActualMetroTextBox.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.idiomaActualMetroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.idiomaActualMetroTextBox.CustomButton.UseSelectable = true;
            this.idiomaActualMetroTextBox.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.idiomaActualMetroTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.idiomaActualMetroTextBox.Lines = new string[0];
            this.idiomaActualMetroTextBox.MaxLength = 32767;
            this.idiomaActualMetroTextBox.Name = "idiomaActualMetroTextBox";
            this.idiomaActualMetroTextBox.PasswordChar = '\0';
            this.idiomaActualMetroTextBox.ReadOnly = true;
            this.idiomaActualMetroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.idiomaActualMetroTextBox.SelectedText = "";
            this.idiomaActualMetroTextBox.SelectionLength = 0;
            this.idiomaActualMetroTextBox.SelectionStart = 0;
            this.idiomaActualMetroTextBox.ShortcutsEnabled = true;
            this.idiomaActualMetroTextBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.idiomaActualMetroTextBox.UseSelectable = true;
            this.idiomaActualMetroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.idiomaActualMetroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // nuevaNomenclaturaMetroTextBox
            // 
            resources.ApplyResources(this.nuevaNomenclaturaMetroTextBox, "nuevaNomenclaturaMetroTextBox");
            // 
            // 
            // 
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.nuevaNomenclaturaMetroTextBox.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Name = "";
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nuevaNomenclaturaMetroTextBox.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nuevaNomenclaturaMetroTextBox.CustomButton.UseSelectable = true;
            this.nuevaNomenclaturaMetroTextBox.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.nuevaNomenclaturaMetroTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.nuevaNomenclaturaMetroTextBox.Lines = new string[0];
            this.nuevaNomenclaturaMetroTextBox.MaxLength = 32767;
            this.nuevaNomenclaturaMetroTextBox.Name = "nuevaNomenclaturaMetroTextBox";
            this.nuevaNomenclaturaMetroTextBox.PasswordChar = '\0';
            this.nuevaNomenclaturaMetroTextBox.ReadOnly = true;
            this.nuevaNomenclaturaMetroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nuevaNomenclaturaMetroTextBox.SelectedText = "";
            this.nuevaNomenclaturaMetroTextBox.SelectionLength = 0;
            this.nuevaNomenclaturaMetroTextBox.SelectionStart = 0;
            this.nuevaNomenclaturaMetroTextBox.ShortcutsEnabled = true;
            this.nuevaNomenclaturaMetroTextBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.nuevaNomenclaturaMetroTextBox.UseSelectable = true;
            this.nuevaNomenclaturaMetroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nuevaNomenclaturaMetroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // nomenclaturaActualMetroLabel
            // 
            resources.ApplyResources(this.nomenclaturaActualMetroLabel, "nomenclaturaActualMetroLabel");
            this.nomenclaturaActualMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.nomenclaturaActualMetroLabel.Name = "nomenclaturaActualMetroLabel";
            this.nomenclaturaActualMetroLabel.WrapToLine = true;
            // 
            // nuevaNomenclaturaMetroLabel
            // 
            resources.ApplyResources(this.nuevaNomenclaturaMetroLabel, "nuevaNomenclaturaMetroLabel");
            this.nuevaNomenclaturaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.nuevaNomenclaturaMetroLabel.Name = "nuevaNomenclaturaMetroLabel";
            this.nuevaNomenclaturaMetroLabel.WrapToLine = true;
            // 
            // nomenclaturaActualMetroTextBox
            // 
            resources.ApplyResources(this.nomenclaturaActualMetroTextBox, "nomenclaturaActualMetroTextBox");
            // 
            // 
            // 
            this.nomenclaturaActualMetroTextBox.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.nomenclaturaActualMetroTextBox.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
            this.nomenclaturaActualMetroTextBox.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.nomenclaturaActualMetroTextBox.CustomButton.Name = "";
            this.nomenclaturaActualMetroTextBox.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.nomenclaturaActualMetroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nomenclaturaActualMetroTextBox.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            this.nomenclaturaActualMetroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nomenclaturaActualMetroTextBox.CustomButton.UseSelectable = true;
            this.nomenclaturaActualMetroTextBox.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
            this.nomenclaturaActualMetroTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.nomenclaturaActualMetroTextBox.Lines = new string[0];
            this.nomenclaturaActualMetroTextBox.MaxLength = 32767;
            this.nomenclaturaActualMetroTextBox.Name = "nomenclaturaActualMetroTextBox";
            this.nomenclaturaActualMetroTextBox.PasswordChar = '\0';
            this.nomenclaturaActualMetroTextBox.ReadOnly = true;
            this.nomenclaturaActualMetroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nomenclaturaActualMetroTextBox.SelectedText = "";
            this.nomenclaturaActualMetroTextBox.SelectionLength = 0;
            this.nomenclaturaActualMetroTextBox.SelectionStart = 0;
            this.nomenclaturaActualMetroTextBox.ShortcutsEnabled = true;
            this.nomenclaturaActualMetroTextBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.nomenclaturaActualMetroTextBox.UseSelectable = true;
            this.nomenclaturaActualMetroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nomenclaturaActualMetroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // nuevoIdiomaMetroComboBox
            // 
            resources.ApplyResources(this.nuevoIdiomaMetroComboBox, "nuevoIdiomaMetroComboBox");
            this.nuevoIdiomaMetroComboBox.FormattingEnabled = true;
            this.nuevoIdiomaMetroComboBox.Name = "nuevoIdiomaMetroComboBox";
            this.nuevoIdiomaMetroComboBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.nuevoIdiomaMetroComboBox.UseSelectable = true;
            this.nuevoIdiomaMetroComboBox.SelectedIndexChanged += new System.EventHandler(this.nuevoIdiomaMetroComboBox_SelectedIndexChanged);
            // 
            // nuevaReferenciaMetroLabel
            // 
            resources.ApplyResources(this.nuevaReferenciaMetroLabel, "nuevaReferenciaMetroLabel");
            this.idiomasTableLayoutPanel.SetColumnSpan(this.nuevaReferenciaMetroLabel, 3);
            this.nuevaReferenciaMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.nuevaReferenciaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.nuevaReferenciaMetroLabel.Name = "nuevaReferenciaMetroLabel";
            this.nuevaReferenciaMetroLabel.WrapToLine = true;
            // 
            // nuevoIdiomaMetroLabel
            // 
            resources.ApplyResources(this.nuevoIdiomaMetroLabel, "nuevoIdiomaMetroLabel");
            this.nuevoIdiomaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.nuevoIdiomaMetroLabel.Name = "nuevoIdiomaMetroLabel";
            this.nuevoIdiomaMetroLabel.WrapToLine = true;
            // 
            // visualizacionMetroPanel
            // 
            this.visualizacionMetroPanel.Controls.Add(this.visualizacionTableLayoutPanel);
            resources.ApplyResources(this.visualizacionMetroPanel, "visualizacionMetroPanel");
            this.visualizacionMetroPanel.HorizontalScrollbarBarColor = true;
            this.visualizacionMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.visualizacionMetroPanel.HorizontalScrollbarSize = 10;
            this.visualizacionMetroPanel.Name = "visualizacionMetroPanel";
            this.visualizacionMetroPanel.VerticalScrollbarBarColor = true;
            this.visualizacionMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.visualizacionMetroPanel.VerticalScrollbarSize = 10;
            // 
            // visualizacionTableLayoutPanel
            // 
            resources.ApplyResources(this.visualizacionTableLayoutPanel, "visualizacionTableLayoutPanel");
            this.visualizacionTableLayoutPanel.Controls.Add(this.temaActualMetroLabel, 0, 0);
            this.visualizacionTableLayoutPanel.Controls.Add(this.mostrarTemaPictureBox, 0, 1);
            this.visualizacionTableLayoutPanel.Controls.Add(this.seleccioneTemaMetroLabel, 0, 2);
            this.visualizacionTableLayoutPanel.Controls.Add(this.mostrarAyudaMetroLabel, 1, 3);
            this.visualizacionTableLayoutPanel.Controls.Add(this.mostrarAyudaMetroToggle, 0, 3);
            this.visualizacionTableLayoutPanel.Controls.Add(this.temaMetroComboBox, 1, 2);
            this.visualizacionTableLayoutPanel.Name = "visualizacionTableLayoutPanel";
            // 
            // temaActualMetroLabel
            // 
            resources.ApplyResources(this.temaActualMetroLabel, "temaActualMetroLabel");
            this.visualizacionTableLayoutPanel.SetColumnSpan(this.temaActualMetroLabel, 2);
            this.temaActualMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.temaActualMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.temaActualMetroLabel.Name = "temaActualMetroLabel";
            this.temaActualMetroLabel.WrapToLine = true;
            // 
            // mostrarTemaPictureBox
            // 
            resources.ApplyResources(this.mostrarTemaPictureBox, "mostrarTemaPictureBox");
            this.mostrarTemaPictureBox.Image = global::BeLife.Vista.Properties.Resources.beLifeOscuro;
            this.mostrarTemaPictureBox.Name = "mostrarTemaPictureBox";
            this.mostrarTemaPictureBox.TabStop = false;
            // 
            // seleccioneTemaMetroLabel
            // 
            resources.ApplyResources(this.seleccioneTemaMetroLabel, "seleccioneTemaMetroLabel");
            this.seleccioneTemaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.seleccioneTemaMetroLabel.Name = "seleccioneTemaMetroLabel";
            this.seleccioneTemaMetroLabel.WrapToLine = true;
            // 
            // mostrarAyudaMetroLabel
            // 
            resources.ApplyResources(this.mostrarAyudaMetroLabel, "mostrarAyudaMetroLabel");
            this.mostrarAyudaMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mostrarAyudaMetroLabel.Name = "mostrarAyudaMetroLabel";
            this.mostrarAyudaMetroLabel.UseStyleColors = true;
            this.mostrarAyudaMetroLabel.WrapToLine = true;
            // 
            // mostrarAyudaMetroToggle
            // 
            resources.ApplyResources(this.mostrarAyudaMetroToggle, "mostrarAyudaMetroToggle");
            this.mostrarAyudaMetroToggle.Checked = true;
            this.mostrarAyudaMetroToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mostrarAyudaMetroToggle.DisplayFocus = true;
            this.mostrarAyudaMetroToggle.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.mostrarAyudaMetroToggle.Name = "mostrarAyudaMetroToggle";
            this.mostrarAyudaMetroToggle.Style = MetroFramework.MetroColorStyle.Purple;
            this.mostrarAyudaMetroToggle.UseSelectable = true;
            this.mostrarAyudaMetroToggle.Click += new System.EventHandler(this.mostrarAyudaMetroToggle_Click);
            // 
            // temaMetroComboBox
            // 
            this.temaMetroComboBox.DisplayFocus = true;
            resources.ApplyResources(this.temaMetroComboBox, "temaMetroComboBox");
            this.temaMetroComboBox.FormattingEnabled = true;
            this.temaMetroComboBox.Name = "temaMetroComboBox";
            this.temaMetroComboBox.Style = MetroFramework.MetroColorStyle.Purple;
            this.temaMetroComboBox.UseSelectable = true;
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
            // MetroPreferenciasForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::BeLife.Vista.Properties.Resources.preferenciass;
            this.BackImagePadding = new System.Windows.Forms.Padding(3);
            this.BackMaxSize = 60;
            this.ControlBox = false;
            this.Controls.Add(this.formularioTableLayoutPanel);
            this.Name = "MetroPreferenciasForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Load += new System.EventHandler(this.MetroPreferenciasForm_Load);
            this.formularioTableLayoutPanel.ResumeLayout(false);
            this.formularioTableLayoutPanel.PerformLayout();
            this.botonesMetroPanel.ResumeLayout(false);
            this.botonesTableLayoutPanel.ResumeLayout(false);
            this.opcionesMetroPanel.ResumeLayout(false);
            this.idiomaMetroPanel.ResumeLayout(false);
            this.idiomasTableLayoutPanel.ResumeLayout(false);
            this.idiomasTableLayoutPanel.PerformLayout();
            this.visualizacionMetroPanel.ResumeLayout(false);
            this.visualizacionTableLayoutPanel.ResumeLayout(false);
            this.visualizacionTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarTemaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formularioTableLayoutPanel;
        private MetroFramework.Controls.MetroPanel botonesMetroPanel;
        private MetroFramework.Controls.MetroButton idiomasMetroButton;
        private MetroFramework.Controls.MetroButton visualizacionMetroButton;
        private MetroFramework.Controls.MetroLabel ayudaMetroLabel;
        private MetroFramework.Controls.MetroButton aceptarMetroButton;
        private MetroFramework.Controls.MetroButton cancelarMetroButton;
        private MetroFramework.Controls.MetroPanel opcionesMetroPanel;
        private MetroFramework.Controls.MetroPanel visualizacionMetroPanel;
        private MetroFramework.Controls.MetroPanel idiomaMetroPanel;
        private MetroFramework.Controls.MetroLabel temaActualMetroLabel;
        private MetroFramework.Controls.MetroLabel seleccioneTemaMetroLabel;
        private MetroFramework.Controls.MetroLabel mostrarAyudaMetroLabel;
        private System.Windows.Forms.PictureBox mostrarTemaPictureBox;
        private MetroFramework.Controls.MetroToggle mostrarAyudaMetroToggle;
        private MetroFramework.Controls.MetroComboBox temaMetroComboBox;
        private MetroFramework.Controls.MetroLabel idiomaActualMetroLabel;
        private MetroFramework.Controls.MetroLabel referenciaActualMetroLabel;
        private MetroFramework.Controls.MetroLabel nomenclaturaActualMetroLabel;
        private MetroFramework.Controls.MetroTextBox idiomaActualMetroTextBox;
        private MetroFramework.Controls.MetroTextBox nomenclaturaActualMetroTextBox;
        private MetroFramework.Controls.MetroLabel nuevaReferenciaMetroLabel;
        private MetroFramework.Controls.MetroTextBox nuevaNomenclaturaMetroTextBox;
        private MetroFramework.Controls.MetroLabel nuevaNomenclaturaMetroLabel;
        private MetroFramework.Controls.MetroComboBox nuevoIdiomaMetroComboBox;
        private MetroFramework.Controls.MetroLabel nuevoIdiomaMetroLabel;
        private MetroFramework.Components.MetroToolTip formularioMetroToolTip;
        private MetroFramework.Components.MetroStyleExtender formularioMetroStyleExtender;
        private System.Windows.Forms.TableLayoutPanel botonesTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel visualizacionTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel idiomasTableLayoutPanel;
        private MetroFramework.Components.MetroStyleManager formularioMetroStyleManager;
    }
}