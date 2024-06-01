namespace MMSDotNetCore.WindowFormApp
{
    partial class FrmBlog
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
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            label4 = new Label();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(276, 68);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(293, 31);
            txtTitle.TabIndex = 0;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(276, 119);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(293, 31);
            txtAuthor.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(276, 173);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(293, 31);
            txtContent.TabIndex = 10;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 119);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 4;
            label2.Text = " Author : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 173);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 5;
            label3.Text = "Content :";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(276, 232);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(87, 37);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(369, 232);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 37);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(114, 68);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 11;
            label4.Text = "Title :";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(369, 232);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(102, 37);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(label4);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
        private Button btnSave;
        private Label label4;
        private Button btnUpdate;
    }
}
