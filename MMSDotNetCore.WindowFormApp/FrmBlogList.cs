using MMSDotNetCore.Shared;
using MMSDotNetCore.WindowFormApp.Querys;
using MMSDotNetCore.WindowFormApp.Models;
namespace MMSDotNetCore.WindowFormApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;

        public FrmBlogList()
        {
            InitializeComponent();
            dgvView.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvView.Rows[e.RowIndex].Cells["colID"].Value);

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frmBlog = new FrmBlog(id);
                frmBlog.ShowDialog();
                BlogList();
            }
            else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to delet!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No) return;
                DeleteBlog(id);
            }
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogRead);
            dgvView.DataSource = lst;
        }

        private void DeleteBlog(int id)
        {
            int result = _dapperService.Execute(BlogQuery.BlogDelete, new { BlogId = id });
            string message = result > 0 ? "Blog deletion successful." : "Blog deletion fail!";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
