using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GofroTar
{
    public partial class ResultsForm : MaterialForm
    {
        PlanResult pr;
        public ResultsForm(PlanResult pr)
        {
            InitializeComponent();
            this.pr = pr;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            Canvas canvas = new Canvas();
            foreach (Order order in DBConnection.orders)
            {

                for(int i = 0; i < pr.cuts.Count; i++)
                {
                    dataGridView2.Rows.Add(pr.cuts[i].number, pr.count[i], "machine1", canvas.width);
                }
                
            }
        }
    }
}
