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
            dataGridView1.DataSource  = lst;
        }
    }
}
