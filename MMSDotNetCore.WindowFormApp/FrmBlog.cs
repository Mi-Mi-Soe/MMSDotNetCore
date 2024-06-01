using MMSDotNetCore.Shared;
using MMSDotNetCore.WindowFormApp.Models;
using MMSDotNetCore.WindowFormApp.Querys;

namespace MMSDotNetCore.WindowFormApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogId;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            btnUpdate.Visible = false;
        }

        public FrmBlog(int blogId)
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            _blogId = blogId;

            var model = _dapperService.QueryFirstOrDefault<BlogModel>(BlogQuery.BlogEdit, new { BlogId = blogId });
            txtTitle.Text = model.BlogTitle;
            txtContent.Text = model.BlogContent;
            txtAuthor.Text = model.BlogAuthor;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txtTitle.Text.Trim(); // remove space front and back of text
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text.Trim();
                int result = _dapperService.Execute(BlogQuery.BlogCreate, blog);
                string message = result > 0 ? "Blog creation successful" : "Blog creation fail";
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (result > 0)
                    ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text,
                    BlogAuthor = txtAuthor.Text,
                    BlogContent = txtContent.Text,
                };
                int result = _dapperService.Execute(BlogQuery.BlogUpdate, blog);
                string message = result > 0 ? "Blog Update Successful." : "Blog Update Fail.";
                MessageBox.Show(message);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
