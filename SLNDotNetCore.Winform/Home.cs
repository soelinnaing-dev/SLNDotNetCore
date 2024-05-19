using SLNDotNetCore.Shared;
using SLNDotNetCore.Winform.Classes;
using SLNDotNetCore.Winform.Models;
using SLNDotNetCore.Winform.Queries;

namespace SLNDotNetCore.Winform
{
    public partial class Home : Form
    {
        private readonly DapperService _dapperService;

        public Home()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
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
            bool isHavevalue = Validation.IsValueValid(pnlControl);
            if (!isHavevalue)
            {
                string message = "Please input data!";
                MessageBox.Show(message);
                return;
            }
            try
            {
                BlogModel mode = new BlogModel()
                {
                    BlogTitle = txtTitle.Text,
                    BlogAuthor = txtAuthor.Text,
                    BlogContent = txtContent.Text
                };
                int result = _dapperService.Execute(Queries.Queries.createQuery, mode);
                string message = result > 0 ? "Create Successful!" : "Create Failed!";
                MessageBox.Show(message);
                ControlClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
