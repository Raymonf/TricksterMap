namespace TricksterMap
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
            this.type2Picture = new System.Windows.Forms.PictureBox();
            this.type3Picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.collisionPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.type2Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.type3Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // collisionPicture
            // 
            this.collisionPicture.BackColor = System.Drawing.Color.Transparent;
            this.collisionPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.collisionPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collisionPicture.Location = new System.Drawing.Point(0, 0);
            this.collisionPicture.Name = "collisionPicture";
            this.collisionPicture.Size = new System.Drawing.Size(800, 450);
            this.collisionPicture.TabIndex = 0;
            this.collisionPicture.TabStop = false;
            // 
            // type2Picture
            // 
            this.type2Picture.BackColor = System.Drawing.Color.Transparent;
            this.type2Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.type2Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type2Picture.Location = new System.Drawing.Point(0, 0);
            this.type2Picture.Name = "type2Picture";
            this.type2Picture.Size = new System.Drawing.Size(800, 450);
            this.type2Picture.TabIndex = 1;
            this.type2Picture.TabStop = false;
            // 
            // type3Picture
            // 
            this.type3Picture.BackColor = System.Drawing.Color.Transparent;
            this.type3Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.type3Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type3Picture.Location = new System.Drawing.Point(0, 0);
            this.type3Picture.Name = "type3Picture";
            this.type3Picture.Size = new System.Drawing.Size(800, 450);
            this.type3Picture.TabIndex = 2;
            this.type3Picture.TabStop = false;
            // 
            // ConfigLayerCollisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.type3Picture);
            this.Controls.Add(this.type2Picture);
            this.Controls.Add(this.collisionPicture);
            this.Name = "ConfigLayerCollisionForm";
            this.Text = "Config Layer - Collision Data";
            this.Load += new System.EventHandler(this.ConfigLayerCollisionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.collisionPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.type2Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.type3Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox collisionPicture;
        public System.Windows.Forms.PictureBox type2Picture;
        public System.Windows.Forms.PictureBox type3Picture;
    }
}