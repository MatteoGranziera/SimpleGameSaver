namespace SimpleGameSaver
{
    partial class frmDebug
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
            this.rtxtDebug = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtDebug
            // 
            this.rtxtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtDebug.Location = new System.Drawing.Point(12, 12);
            this.rtxtDebug.Name = "rtxtDebug";
            this.rtxtDebug.Size = new System.Drawing.Size(606, 329);
            this.rtxtDebug.TabIndex = 0;
            this.rtxtDebug.Text = "";
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 353);
            this.Controls.Add(this.rtxtDebug);
            this.Name = "frmDebug";
            this.Text = "Debug Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtDebug;

    }
}