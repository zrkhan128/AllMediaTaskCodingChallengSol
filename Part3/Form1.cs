using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnPlotGraph_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtYValue.Text) && int.TryParse(txtXValue.Text,out int x))
            {
                double y = ScientificCalculator.EvaluateExpression(txtYValue.Text,txtXValue.Text.Trim());
                chart1.Series[0].Points.AddXY(x, 0);
                chart1.Series[0].Points.AddXY(0, y);
            }
            
        }
    }
}
