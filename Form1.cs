using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Работа_17._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtX.Text))
            {
                MessageBox.Show("Введите корректное число для X");
                return;
            }
            if (string.IsNullOrEmpty(txtY.Text))
            {
                MessageBox.Show("Введите корректное число для Y");
                return;
            }
            if (string.IsNullOrEmpty(txtStep.Text))
            {
                MessageBox.Show("Введите корректное число шага");
                return;
            }
            double X = double.Parse(txtX.Text);
            if (!double.TryParse(txtX.Text, out X))
            { 
                MessageBox.Show("Введите корректное число для X");
            return;
            }
            double Y = double.Parse(txtY.Text);
            if (!double.TryParse(txtY.Text, out Y))
            {
                MessageBox.Show("Введите корректное число для Y");
                return;
            }
            double Step = double.Parse(txtStep.Text);
            if (!double.TryParse(txtStep.Text, out Step) || Step <= 0)
            {
                MessageBox.Show("Введите корректное число шага");
                return;
            }
            if (!Proverka(Y))
            {
                return;
            }

            chart1.Series.Clear();
            var series = new Series
            {
                ChartType = SeriesChartType.Line,
            };
            chart1.Series.Add(series);
            string formula = $"y = 2^x * sqrt(x) + |X|^(1/3) * sqrt(exp(x-1)) / sin(Y)";
            series.LegendText = formula;

            for (double x = 0.1; x <= 10; x += Step)
            {
                double a = Math.Pow(2, x) * Math.Sqrt(x) + Math.Pow(Math.Abs(X), 1.0 / 3.0) * Math.Sqrt(Math.Exp(x - 1)) / Math.Sin(Y);
                series.Points.AddXY(x, a);
            }
        }

        private bool Proverka(double y)
        {

            if (Math.Sin(y) == 0)
            {
                MessageBox.Show("Синус Y равен 0, что вызовет деление на ноль");
                return false;
            }
            return true;
        }
    }
}
