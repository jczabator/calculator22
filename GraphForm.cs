using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class GraphForm : Form
    {
        public double _A, _B, _C;
        private double min, max;
        private int N, switch_on;
        

        public GraphForm()
        {
            InitializeComponent();
            
           // opener = parentForm;
            
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button1.Enabled = false;
            if (radioButton1.Checked)
            {
                textBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                label6.Visible = false;
                label5.Visible = true;
                label3.Visible = true;
               
                switch_on = 1;

            }

            if (radioButton2.Checked)
            {
                textBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label6.Visible = true;
                label5.Visible = true;
                label3.Visible = true;
                switch_on = 2;

            }

            if (radioButton3.Checked)
            {
                textBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                label6.Visible = false;
                label5.Visible = true;
                label3.Visible = true;
               
                switch_on = 3;

            }


        }

        private void Close(object sender, EventArgs e)
        {         
            this.Close();                                        
        }

        private double F1(double x, double a, double b)
        {
            return a * x + b;
            //return Math.Sin(a * x) * Math.Cos(b * x);
        }

        private double F2(double x, double a, double b,double c)
        {
            return a * x*x + b*x+c;
        }

        private double F3(double x, double a, double b)
        {

            double sin;
            sin = Math.Sin(a * x);
            return sin*b;
        }

        private void Plo(object sender, EventArgs e)
        {

            double dx, x,F;



           // chart1.Series.Clear();
            dx = 1.0*(max-min)/N;
            x = min;
            F = 0.0;
          //  chart1.Series["Series1"].Points.AddXY(min, max);
            chart1.ChartAreas["ChartArea1"].RecalculateAxesScale();
            chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(min, max);
            chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoom(-1, 1);
            chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;


            for (int i = 0; i < N; i++)
            {
                x = x + i * dx;

                F = 0.0;
                switch (switch_on)
                {
                    case 1:
                        F=F1(x, _A, _B);
                        break;
                    case 2:
                        F = F2(x, _A, _B, _C);
                        break;
                    case 3:
                        F = F3(x, _A, _B);
                        break;
                     
                }



                chart1.Series["Series1"].Points.AddXY(x, F);
                chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.ChartAreas["ChartArea1"].RecalculateAxesScale();

                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button1.Enabled = true;
            min = Convert.ToDouble( textBox1.Text);
            max = Convert.ToDouble(textBox2.Text);
            N = Convert.ToInt32(textBox4.Text);
            _A = Convert.ToDouble(textBox3.Text);
            _B= Convert.ToDouble(textBox5.Text);
            _C = Convert.ToDouble(textBox6.Text);
          

            if (radioButton1.Checked)
            {
                textBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                label6.Visible = false;
                label5.Visible = true;
                label3.Visible = true;
               
                switch_on = 1;

            }

            if (radioButton2.Checked)
            {
                textBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label6.Visible = true;
                label5.Visible = true;
                label3.Visible = true;
              
                switch_on=2;

            }

            if (radioButton3.Checked)
            {
                textBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                label6.Visible = false;
                label5.Visible = true;
                label3.Visible = true;


             
                switch_on = 3;

            }



           
        }



     

       
    }
}
