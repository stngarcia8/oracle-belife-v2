namespace BeLife.Vista.Controles.MsgBox
{
    partial class MsgBoxControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBoxControl));
            this.panelbody = new System.Windows.Forms.Panel();
            this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.iconLabel = new System.Windows.Forms.Label();
            this.formularioImageList = new System.Windows.Forms.ImageList(this.components);
            this.panelbody.SuspendLayout();
            this.tlpBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.DarkGray;
            this.panelbody.Controls.Add(this.tlpBody);
            this.panelbody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbody.Location = new System.Drawing.Point(0, 0);
            this.panelbody.Margin = new System.Windows.Forms.Padding(0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(804, 211);
            this.panelbody.TabIndex = 3;
            // 
            // tlpBody
            // 
            this.tlpBody.ColumnCount = 3;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBody.Controls.Add(this.messageLabel, 1, 2);
            this.tlpBody.Controls.Add(this.titleLabel, 1, 1);
            this.tlpBody.Controls.Add(this.pnlBottom, 1, 3);
            this.tlpBody.Controls.Add(this.iconLabel, 0, 1);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(0, 0);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 4;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpBody.Size = new System.Drawing.Size(804, 211);
            this.tlpBody.TabIndex = 6;
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLabel.BackColor = System.Drawing.Color.Transparent;
            this.messageLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.messageLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.messageLabel.Location = new System.Drawing.Point(83, 30);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(640, 141);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Mensaje a mostrar...";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.titleLabel.Location = new System.Drawing.Point(80, 5);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(319, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Aqui va el titulo del mensaje!!!";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.metroButton2);
            this.pnlBottom.Controls.Add(this.metroButton1);
            this.pnlBottom.Controls.Add(this.metroButton3);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(80, 171);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(643, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(455, 1);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(90, 26);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "button 2";
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(357, 1);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(90, 26);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "button 1";
            this.metroButton1.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.Location = new System.Drawing.Point(553, 1);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(90, 26);
            this.metroButton3.TabIndex = 5;
            this.metroButton3.Text = "button 3";
            this.metroButton3.UseSelectable = true;
            // 
            // iconLabel
            // 
            this.iconLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.iconLabel.ImageIndex = 0;
            this.iconLabel.ImageList = this.formularioImageList;
            this.iconLabel.Location = new System.Drawing.Point(27, 5);
            this.iconLabel.Name = "iconLabel";
            this.tlpBody.SetRowSpan(this.iconLabel, 2);
            this.iconLabel.Size = new System.Drawing.Size(50, 166);
            this.iconLabel.TabIndex = 3;
            // 
            // formularioImageList
            // 
            this.formularioImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("formularioImageList.ImageStream")));
            this.formularioImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.formularioImageList.Images.SetKeyName(0, "messageBoxError.png");
            this.formularioImageList.Images.SetKeyName(1, "messageBoxInfo.png");
            this.formularioImageList.Images.SetKeyName(2, "messageBoxQuestion.png");
            this.formularioImageList.Images.SetKeyName(3, "messageBoxWarning.png");
            // 
            // MsgBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 211);
            this.ControlBox = false;
            this.Controls.Add(this.panelbody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MsgBoxControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.panelbody.ResumeLayout(false);
            this.tlpBody.ResumeLayout(false);
            this.tlpBody.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.TableLayoutPanel tlpBody;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel pnlBottom;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton3;
        private System.Windows.Forms.ImageList formularioImageList;
        private System.Windows.Forms.Label iconLabel;
    }
}