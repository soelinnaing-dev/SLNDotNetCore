using SLNDotNetCore.Shared;
using SLNDotNetCore.Winform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNDotNetCore.Winform.forms
{
    public partial class frm_BlogList : Form
    {
        private readonly DapperService _dapperservice;
        public frm_BlogList()
        {
            InitializeComponent();
            _dapperservice = new DapperService(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
        }


        private void frm_BlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperservice.Query<BlogModel>(Queries.Queries.readQuery);
            dataGridView1.DataSource = lst;
        }

        private void DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
            WHERE BlogId = @BlogId";
           int result = _dapperservice.Execute(query, new {BlogId = id});
            string message = result > 0 ? "Delete Successfully!" : "Delete Failed!";
            MessageBox.Show(message);
            frm_BlogList_Load(this,EventArgs.Empty);
        }

        private int blogId;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex ==(int)EnumControlType.Edit)
            {
                blogId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colid"].Value);
                frm_Blog blog = new frm_Blog(blogId);
                blog.ShowDialog();
                
            }
            else if(e.ColumnIndex ==(int)EnumControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(dialogResult != DialogResult.Yes)return;

                int blogId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colid"].Value);
                DeleteBlog(blogId);
            }
        }
    }
}
