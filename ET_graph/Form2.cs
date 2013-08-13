using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ET_graph
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			//time-light/gyroグラフのデフォルト設定
			textBox1.Text = Convert.ToString(x1_min);
			textBox2.Text = Convert.ToString(x1_max);
			textBox3.Text = Convert.ToString(y1_min);
			textBox4.Text = Convert.ToString(y1_max);

			//time-motorグラフのデフォルト設定
			textBox5.Text = Convert.ToString(x2_min);
			textBox6.Text = Convert.ToString(x2_max);
			textBox7.Text = Convert.ToString(y2_min);
			textBox8.Text = Convert.ToString(y2_max);

			//目盛のデフォルト設定
			textBox9.Text = Convert.ToString(x1_interval);
			textBox10.Text = Convert.ToString(y1_interval);
			textBox11.Text = Convert.ToString(x2_interval);
			textBox12.Text = Convert.ToString(y2_interval);

			//チェックボックスのデフォルト設定
			checkBox1.Checked = check;
		}
		static public int x1_min;
		static public int x1_max;
		static public int y1_min;
		static public int y1_max;

		static public int x2_min;
		static public int x2_max;
		static public int y2_min;
		static public int y2_max;

		static public int x2_interval;
		static public int x1_interval;
		static public int y1_interval;
		static public int y2_interval;

		static public bool check;

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
			{
				x1_min = Convert.ToInt32(textBox1.Text);
			}
			if (textBox2.Text != "")
			{
				x1_max = Convert.ToInt32(textBox2.Text);
			}
			if (textBox3.Text != "")
			{
				y1_min = Convert.ToInt32(textBox3.Text);
			}
			if (textBox4.Text != "")
			{
				y1_max = Convert.ToInt32(textBox4.Text);
			}
			if (textBox5.Text != "")
			{
				x2_min = Convert.ToInt32(textBox5.Text);
			}
			if (textBox6.Text != "")
			{
				x2_max = Convert.ToInt32(textBox6.Text);
			}
			if (textBox7.Text != "")
			{
				y2_min = Convert.ToInt32(textBox7.Text);
			}
			if (textBox8.Text != "")
			{
				y2_max = Convert.ToInt32(textBox8.Text);
			}
			if (textBox9.Text != "")
			{
				x1_interval = Convert.ToInt32(textBox9.Text);
			}
			if (textBox10.Text != "")
			{
				y1_interval = Convert.ToInt32(textBox10.Text);
			}
			if (textBox11.Text != "")
			{
				x2_interval = Convert.ToInt32(textBox11.Text);

			}
			if (textBox12.Text != "")
			{
				y2_interval = Convert.ToInt32(textBox12.Text);
			}
			check=checkBox1.Checked;
			this.Close();
		}
	}
}
