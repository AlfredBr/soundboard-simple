namespace SoundBoard
{
    partial class TtsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._textBox = new System.Windows.Forms.TextBox();
            this._button = new System.Windows.Forms.Button();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this._n = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _textBox
            // 
            this._textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBox.Location = new System.Drawing.Point(39, 2);
            this._textBox.Margin = new System.Windows.Forms.Padding(2);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(73, 29);
            this._textBox.TabIndex = 0;
            // 
            // _button
            // 
            this._button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._button.Location = new System.Drawing.Point(166, 2);
            this._button.Margin = new System.Windows.Forms.Padding(2);
            this._button.Name = "_button";
            this._button.Size = new System.Drawing.Size(82, 30);
            this._button.TabIndex = 2;
            this._button.Text = "Say It!";
            this._button.UseVisualStyleBackColor = true;
            this._button.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // _comboBox
            // 
            this._comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comboBox.FormattingEnabled = true;
            this._comboBox.Location = new System.Drawing.Point(117, 3);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(44, 28);
            this._comboBox.TabIndex = 1;
            this._comboBox.TabStop = false;
            // 
            // _n
            // 
            this._n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._n.Location = new System.Drawing.Point(3, 3);
            this._n.Name = "_n";
            this._n.Size = new System.Drawing.Size(31, 26);
            this._n.TabIndex = 4;
            this._n.Text = "1";
            this._n.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TtsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._n);
            this.Controls.Add(this._comboBox);
            this.Controls.Add(this._button);
            this.Controls.Add(this._textBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TtsControl";
            this.Size = new System.Drawing.Size(250, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.Button _button;
        private System.Windows.Forms.ComboBox _comboBox;
        private System.Windows.Forms.Label _n;
    }
}
