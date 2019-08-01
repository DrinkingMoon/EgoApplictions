using Ego.Application;
using Ego.Domain.Model;
using Ego.Domain.Repositories.EFDbContextEgo;
using Ego.Domain.Repositories.EntityFramework;
using Microsoft.Reporting.WinForms;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ego.UIWpf.Report
{
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Ego.UIWpf.Report.Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Restaurant", 
                new RestaurantRepository(new ContextEntityFramework()).GetList()));
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
