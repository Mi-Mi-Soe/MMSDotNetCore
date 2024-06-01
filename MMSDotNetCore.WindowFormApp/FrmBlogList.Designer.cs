namespace MMSDotNetCore.WindowFormApp
{
    partial class FrmBlogList
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
            dgvView = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvView).BeginInit();
            SuspendLayout();
            // 
            // dgvView
            // 
            dgvView.AllowUserToAddRows = false;
            dgvView.AllowUserToDeleteRows = false;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvView.Columns.AddRange(new DataGridViewColumn[] { colID, colEdit, colDelete, colTitle, colAuthor, colContent });
            dgvView.Dock = DockStyle.Fill;
            dgvView.Location = new Point(0, 0);
            dgvView.Name = "dgvView";
            dgvView.ReadOnly = true;
            dgvView.RowHeadersWidth = 62;
            dgvView.RowTemplate.Height = 33;
            dgvView.Size = new Size(800, 450);
            dgvView.TabIndex = 0;
            dgvView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // colTitle
            // 
            colTitle.DataPropertyName = "BlogTitle";
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 8;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Resizable = DataGridViewTriState.True;
            colTitle.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colAuthor
            // 
            colAuthor.DataPropertyName = "BlogAuthor";
            colAuthor.HeaderText = "Author";
            colAuthor.MinimumWidth = 8;
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            colAuthor.Resizable = DataGridViewTriState.True;
            colAuthor.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colContent
            // 
            colContent.DataPropertyName = "BlogContent";
            colContent.HeaderText = "Content";
            colContent.MinimumWidth = 8;
            colContent.Name = "colContent";
            colContent.ReadOnly = true;
            colContent.Resizable = DataGridViewTriState.True;
            colContent.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvView);
            Name = "FrmBlogList";
            Text = "FrmBlogList";
            Load += FrmBlogList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvView;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colContent;
    }
}