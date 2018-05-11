namespace md3_2
{
    partial class ConfigLayerCollisionForm
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
            this.collisionPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.collisionPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // collisionPicture
            // 
            this.collisionPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.collisionPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collisionPicture.Location = new System.Drawing.Point(0, 0);
            this.collisionPicture.Name = "collisionPicture";
            this.collisionPicture.Size = new System.Drawing.Size(800, 450);
            this.collisionPicture.TabIndex = 0;
            this.collisionPicture.TabStop = false;
            // 
            // ConfigLayerCollisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.collisionPicture);
            this.Name = "ConfigLayerCollisionForm";
            this.Text = "Config Layer - Collision Data";
            this.Load += new System.EventHandler(this.ConfigLayerCollisionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.collisionPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox collisionPicture;
    }
}