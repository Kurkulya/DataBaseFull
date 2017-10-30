namespace DataBaseWF
{
    partial class SinglePerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePerson));
            this.dataGridSingle = new System.Windows.Forms.DataGridView();
            this.fnTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.lnTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.lnLabel = new System.Windows.Forms.Label();
            this.fnLabel = new System.Windows.Forms.Label();
            this.mainIdLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CreatePhoneButton = new System.Windows.Forms.Button();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSingle)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridSingle
            // 
            this.dataGridSingle.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridSingle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSingle.Location = new System.Drawing.Point(4, 47);
            this.dataGridSingle.Name = "dataGridSingle";
            this.dataGridSingle.Size = new System.Drawing.Size(214, 289);
            this.dataGridSingle.TabIndex = 0;
            // 
            // fnTextBox
            // 
            this.fnTextBox.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fnTextBox.Location = new System.Drawing.Point(6, 46);
            this.fnTextBox.Name = "fnTextBox";
            this.fnTextBox.Size = new System.Drawing.Size(100, 23);
            this.fnTextBox.TabIndex = 2;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageTextBox.Location = new System.Drawing.Point(30, 124);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(47, 23);
            this.ageTextBox.TabIndex = 3;
            // 
            // lnTextBox
            // 
            this.lnTextBox.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnTextBox.Location = new System.Drawing.Point(6, 85);
            this.lnTextBox.Name = "lnTextBox";
            this.lnTextBox.Size = new System.Drawing.Size(100, 23);
            this.lnTextBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ageTextBox);
            this.panel1.Controls.Add(this.lnTextBox);
            this.panel1.Controls.Add(this.fnTextBox);
            this.panel1.Location = new System.Drawing.Point(218, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 289);
            this.panel1.TabIndex = 5;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.SystemColors.Control;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(6, 4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 36);
            this.updateButton.TabIndex = 13;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(30, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Age";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Last Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "First Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ageLabel
            // 
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.ageLabel.Location = new System.Drawing.Point(260, 7);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(64, 37);
            this.ageLabel.TabIndex = 12;
            this.ageLabel.Text = "Age";
            this.ageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnLabel
            // 
            this.lnLabel.BackColor = System.Drawing.Color.Transparent;
            this.lnLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.lnLabel.Location = new System.Drawing.Point(150, 7);
            this.lnLabel.Name = "lnLabel";
            this.lnLabel.Size = new System.Drawing.Size(110, 37);
            this.lnLabel.TabIndex = 11;
            this.lnLabel.Text = "Last Name";
            this.lnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fnLabel
            // 
            this.fnLabel.BackColor = System.Drawing.Color.Transparent;
            this.fnLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fnLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.fnLabel.Location = new System.Drawing.Point(53, 7);
            this.fnLabel.Name = "fnLabel";
            this.fnLabel.Size = new System.Drawing.Size(104, 37);
            this.fnLabel.TabIndex = 10;
            this.fnLabel.Text = "First Name";
            this.fnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainIdLabel
            // 
            this.mainIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainIdLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainIdLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.mainIdLabel.Location = new System.Drawing.Point(12, 7);
            this.mainIdLabel.Name = "mainIdLabel";
            this.mainIdLabel.Size = new System.Drawing.Size(44, 37);
            this.mainIdLabel.TabIndex = 9;
            this.mainIdLabel.Text = "Id";
            this.mainIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.CreatePhoneButton);
            this.panel2.Controls.Add(this.phoneTextBox);
            this.panel2.Location = new System.Drawing.Point(3, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 65);
            this.panel2.TabIndex = 13;
            // 
            // CreatePhoneButton
            // 
            this.CreatePhoneButton.BackColor = System.Drawing.SystemColors.Control;
            this.CreatePhoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePhoneButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePhoneButton.Location = new System.Drawing.Point(3, 28);
            this.CreatePhoneButton.Name = "CreatePhoneButton";
            this.CreatePhoneButton.Size = new System.Drawing.Size(100, 34);
            this.CreatePhoneButton.TabIndex = 14;
            this.CreatePhoneButton.Text = "Add Phone";
            this.CreatePhoneButton.UseVisualStyleBackColor = false;
            this.CreatePhoneButton.Click += new System.EventHandler(this.CreatePhoneButton_Click);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextBox.Location = new System.Drawing.Point(3, 3);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 23);
            this.phoneTextBox.TabIndex = 3;
            // 
            // SinglePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(342, 345);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.lnLabel);
            this.Controls.Add(this.fnLabel);
            this.Controls.Add(this.mainIdLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridSingle);
            this.Name = "SinglePerson";
            this.Text = "SinglePerson";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSingle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSingle;
        private System.Windows.Forms.TextBox fnTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox lnTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label lnLabel;
        private System.Windows.Forms.Label fnLabel;
        private System.Windows.Forms.Label mainIdLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CreatePhoneButton;
        private System.Windows.Forms.TextBox phoneTextBox;
    }
}