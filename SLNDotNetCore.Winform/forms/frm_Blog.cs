using SLNDotNetCore.Shared;
using SLNDotNetCore.Winform.Classes;
using SLNDotNetCore.Winform.Models;
using SLNDotNetCore.Winform.Queries;

namespace SLNDotNetCore.Winform
{
    public partial class frm_Blog : Form
    {
        private readonly DapperService _dapperService;
        private int _blogId;

        public frm_Blog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
            InitializeValidation();
        }

        public frm_Blog(int blogId)
        {
            InitializeComponent();
            btnSave.Text = "Update";
            _blogId = blogId;
            _dapperService = new DapperService(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
            var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * from Tbl_Blog where BlogId=@BlogId", new { BlogId = _blogId });
            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;
            btnSave.Enabled = true;
            InitializeValidation();
        }

        private void InitializeValidation()
        {
            foreach (Control control in pnlControl.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += TextBox_TextChanged!;
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allHaveData = Validation.AllTextBoxesHaveData(pnlControl);
            btnCancel.Enabled = allHaveData;
            btnSave.Enabled = allHaveData;
        }

        private void ControlClear()
        {
            foreach (Control control in pnlControl.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isHaveValue = Validation.IsValueValid(pnlControl);
            if (!isHaveValue)
            {
                string message = "Please input data!";
                MessageBox.Show(message);
                return;
            }
            try
            {
                BlogModel model = new BlogModel()
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };
                SaveOrUpdate(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOrUpdate(BlogModel model)
        {
            int result = 0;
            string message = string.Empty;
            if(btnSave.Text == "&Save")
            {
                result = _dapperService.Execute(Queries.Queries.createQuery, model);
                message = result > 0 ? "Create Successful!" : "Create Failed!";
            }
            else if (btnSave.Text =="Update")
            {
                result = _dapperService.Execute(Queries.Queries.updateQuery, model);
                message = result > 0 ? "Update Successful!" : "Update Failed!"; 
            }
            var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, "Result", MessageBoxButtons.OK, messageBoxIcon);

            if (result > 0 && btnSave.Text == "Save")
            {
                ControlClear();
            }   
            else if(result>0 && btnSave.Text =="Update")
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClear();
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            Validation.MoveToNextControlOnEnter(sender, e);
        }
    }
}
