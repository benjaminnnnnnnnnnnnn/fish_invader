namespace FishInvader
{
    partial class AirSpace
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
            this.components = new System.ComponentModel.Container();
            this.ticker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ticker
            // 
            this.ticker.Enabled = true;
            this.ticker.Interval = 1;
            ticker.Tick += NewFrame;
            // 
            // AirSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::fish_invader.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 598);
            this.DoubleBuffered = true;
            this.Name = "AirSpace";
            this.Text = "AirSpace";
            this.Load += new System.EventHandler(this.AirSpace_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ticker;
    }
}