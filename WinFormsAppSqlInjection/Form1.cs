using MMSDotNetCore.Shared;

namespace WinFormsAppSqlInjection
{
    public partial class LoginForm : Form
    {
        private readonly DapperService _dapperService;
        public LoginForm()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //string query = $"select * from Tbl_User where Email='{txtEmail.Text.Trim()}' and Password='{txtPassword.Text.Trim()}'"; //23424' or 1=1 + '
                string query = $"select * from Tbl_User where Email=@Email and Password=@Password";
                var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
                {
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                });
                if (model is null)
                {
                    MessageBox.Show("User doesn't exist.");
                    return;
                }

                MessageBox.Show("Is Admin : " + model.Email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
