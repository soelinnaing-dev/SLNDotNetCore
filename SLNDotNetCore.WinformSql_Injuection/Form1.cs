using SLNDotNetCore.Shared;
using SLNDotNetCore.WinformSql_Injuection.Models;

namespace SLNDotNetCore.WinformSql_Injuection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperservice;
        public Form1()
        {
            InitializeComponent();
            _dapperservice = new DapperService(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //Sql Injection query
            //string query = $"select * from Tbl_User where Email = '{txt_Email.Text.Trim()}' and Password = '{txt_Password.Text.Trim()}'";

            //Non-Sql Injection query
            string query = "select * from Tbl_User where Email = @Email and Password = @Password";
            var model = _dapperservice.QueryFirstOrDefault<UserModel>(query, new {Email = txt_Email.Text.Trim(),
            Password = txt_Password.Text.Trim()});
            string message = model != null ? "Login Successful" : "Login Failed";
            MessageBox.Show(message);
        }
    }
}
