namespace Colourised.UI.WinForms
{
    partial class MainWindow
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
            this.deviceContainer = new System.Windows.Forms.SplitContainer();
            this.deviceList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.deviceContainer)).BeginInit();
            this.deviceContainer.Panel1.SuspendLayout();
            this.deviceContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceContainer
            // 
            this.deviceContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceContainer.Location = new System.Drawing.Point(0, 0);
            this.deviceContainer.Name = "deviceContainer";
            // 
            // deviceContainer.Panel1
            // 
            this.deviceContainer.Panel1.Controls.Add(this.deviceList);
            this.deviceContainer.Size = new System.Drawing.Size(284, 261);
            this.deviceContainer.SplitterDistance = 94;
            this.deviceContainer.TabIndex = 0;
            // 
            // deviceList
            // 
            this.deviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(0, 0);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(94, 261);
            this.deviceList.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.deviceContainer);
            this.Name = "MainWindow";
            this.Text = "Colourised";
            this.deviceContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deviceContainer)).EndInit();
            this.deviceContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer deviceContainer;
        private System.Windows.Forms.ListBox deviceList;
    }
}

