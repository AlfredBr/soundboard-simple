namespace SoundBoard
{
    partial class SoundboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundboardForm));
            this._mp3Label = new System.Windows.Forms.Label();
            this._ttsPanel = new System.Windows.Forms.Panel();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._ttsLabel = new System.Windows.Forms.Label();
            this._mp3Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mp3Label
            // 
            this._mp3Label.AutoSize = true;
            this._mp3Label.Dock = System.Windows.Forms.DockStyle.Top;
            this._mp3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._mp3Label.Location = new System.Drawing.Point(6, 6);
            this._mp3Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._mp3Label.Name = "_mp3Label";
            this._mp3Label.Size = new System.Drawing.Size(254, 37);
            this._mp3Label.TabIndex = 19;
            this._mp3Label.Text = "Play MP3 Sound";
            // 
            // _ttsPanel
            // 
            this._ttsPanel.AutoScroll = true;
            this._ttsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ttsPanel.Location = new System.Drawing.Point(6, 43);
            this._ttsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._ttsPanel.Name = "_ttsPanel";
            this._ttsPanel.Size = new System.Drawing.Size(1086, 471);
            this._ttsPanel.TabIndex = 20;
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._splitContainer.Name = "_splitContainer";
            this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._ttsPanel);
            this._splitContainer.Panel1.Controls.Add(this._ttsLabel);
            this._splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._mp3Panel);
            this._splitContainer.Panel2.Controls.Add(this._mp3Label);
            this._splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._splitContainer.Size = new System.Drawing.Size(1098, 1042);
            this._splitContainer.SplitterDistance = 520;
            this._splitContainer.SplitterWidth = 6;
            this._splitContainer.TabIndex = 21;
            this._splitContainer.TabStop = false;
            // 
            // _ttsLabel
            // 
            this._ttsLabel.AutoSize = true;
            this._ttsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._ttsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ttsLabel.Location = new System.Drawing.Point(6, 6);
            this._ttsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._ttsLabel.Name = "_ttsLabel";
            this._ttsLabel.Size = new System.Drawing.Size(230, 37);
            this._ttsLabel.TabIndex = 21;
            this._ttsLabel.Text = "Text to Speech";
            // 
            // _mp3Panel
            // 
            this._mp3Panel.AutoScroll = true;
            this._mp3Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mp3Panel.Location = new System.Drawing.Point(6, 43);
            this._mp3Panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._mp3Panel.Name = "_mp3Panel";
            this._mp3Panel.Size = new System.Drawing.Size(1086, 467);
            this._mp3Panel.TabIndex = 20;
            // 
            // SoundboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 1042);
            this.Controls.Add(this._splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoundboardForm";
            this.Text = "Caden\'s Soundboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel1.PerformLayout();
            this._splitContainer.Panel2.ResumeLayout(false);
            this._splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label _mp3Label;
        private System.Windows.Forms.Panel _ttsPanel;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.Label _ttsLabel;
        private System.Windows.Forms.Panel _mp3Panel;
    }
}

