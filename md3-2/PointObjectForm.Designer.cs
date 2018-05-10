namespace md3_2
{
    partial class PointObjectForm
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
            this.pointList = new System.Windows.Forms.ListView();
            this.idHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mapIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xPosHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yPosHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pFlagHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // pointList
            // 
            this.pointList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idHeader,
            this.typeHeader,
            this.mapIdHeader,
            this.xPosHeader,
            this.yPosHeader,
            this.pFlagHeader});
            this.pointList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointList.Location = new System.Drawing.Point(0, 0);
            this.pointList.Name = "pointList";
            this.pointList.Size = new System.Drawing.Size(800, 450);
            this.pointList.TabIndex = 1;
            this.pointList.UseCompatibleStateImageBehavior = false;
            this.pointList.View = System.Windows.Forms.View.Details;
            // 
            // idHeader
            // 
            this.idHeader.Text = "ID";
            this.idHeader.Width = 80;
            // 
            // typeHeader
            // 
            this.typeHeader.Text = "Type";
            this.typeHeader.Width = 140;
            // 
            // mapIdHeader
            // 
            this.mapIdHeader.Text = "Map ID";
            this.mapIdHeader.Width = 100;
            // 
            // xPosHeader
            // 
            this.xPosHeader.Text = "X";
            this.xPosHeader.Width = 100;
            // 
            // yPosHeader
            // 
            this.yPosHeader.Text = "Y";
            this.yPosHeader.Width = 100;
            // 
            // pFlagHeader
            // 
            this.pFlagHeader.Text = "PFlag";
            // 
            // PointObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pointList);
            this.Name = "PointObjectForm";
            this.Text = "Point Object Data";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader idHeader;
        private System.Windows.Forms.ColumnHeader typeHeader;
        private System.Windows.Forms.ColumnHeader mapIdHeader;
        private System.Windows.Forms.ColumnHeader xPosHeader;
        private System.Windows.Forms.ColumnHeader yPosHeader;
        private System.Windows.Forms.ColumnHeader pFlagHeader;
        public System.Windows.Forms.ListView pointList;
    }
}