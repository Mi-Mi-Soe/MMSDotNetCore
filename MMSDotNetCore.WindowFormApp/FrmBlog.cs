using MMSDotNetCore.Shared;
using MMSDotNetCore.WindowFormApp.Models;
using MMSDotNetCore.WindowFormApp.Querys;

namespace MMSDotNetCore.WindowFormApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txtTitle.Text;
                blog.BlogAuthor = txtAuthor.Text;
                blog.BlogContent = txtContent.Text;
                int result = _dapperService.Execute(BlogQuery.BlogCreate, blog);
                string message = result>0?"Blog creation successful":"Blog creation fail";
                MessageBox.Show(message,"Blog",MessageBoxButtons.OK,result>0?MessageBoxIcon.Information:MessageBoxIcon.Error);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
