namespace TricksterMap.Create
{
    partial class CreatePointObject
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
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtMapId = new System.Windows.Forms.TextBox();
            this.lblMapId = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(139, 53);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(161, 24);
            this.cmbType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(27, 56);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(27, 28);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 17);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(139, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(161, 22);
            this.txtId.TabIndex = 5;
            // 
            // txtMapId
            // 
            this.txtMapId.Location = new System.Drawing.Point(139, 83);
            this.txtMapId.Name = "txtMapId";
            this.txtMapId.Size = new System.Drawing.Size(161, 22);
            this.txtMapId.TabIndex = 7;
            // 
            // lblMapId
            // 
            this.lblMapId.AutoSize = true;
            this.lblMapId.Location = new System.Drawing.Point(27, 86);
            this.lblMapId.Name = "lblMapId";
            this.lblMapId.Size = new System.Drawing.Size(52, 17);
            this.lblMapId.TabIndex = 6;
            this.lblMapId.Text = "Map ID";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(139, 111);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(161, 22);
            this.txtX.TabIndex = 9;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(27, 114);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 17);
            this.lblX.TabIndex = 8;
            this.lblX.Text = "X";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(139, 139);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(161, 22);
            this.txtY.TabIndex = 11;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(27, 142);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 17);
            this.lblY.TabIndex = 10;
            this.lblY.Text = "Y";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(225, 188);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 28);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.CreateAndExit);
            // 
            // CreatePointObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 232);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.txtMapId);
            this.Controls.Add(this.lblMapId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(344, 279);
            this.MinimumSize = new System.Drawing.Size(344, 279);
            this.Name = "CreatePointObject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Point Object";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreatePointObject_FormClosing);
            this.Load += new System.EventHandler(this.CreatePointObject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblMapId;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        public System.Windows.Forms.ComboBox cmbType;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtMapId;
        public System.Windows.Forms.TextBox txtX;
        public System.Windows.Forms.TextBox txtY;
        public System.Windows.Forms.Button btnCreate;
    }
}