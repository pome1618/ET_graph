using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ET_graph
{

	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//[設定]のデフォルトを設定
			Form2.x1_min = 0;
			Form2.x1_max = 20000;
			Form2.y1_min = 600;
			Form2.y1_max = 800;

			Form2.x2_min = 0;
			Form2.x2_max = 20000;
			Form2.y2_min = 0;
			Form2.y2_max = 10000;

			Form2.x1_interval = 1000;
			Form2.x2_interval = 1000;
			Form2.y1_interval = 100;
			Form2.y2_interval = 100;

			Form2.check = false;
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			int find;
			Int32 time,light,gyro,motor_R,motor_L;
		
			//一時文字列格納
			string stBuffer2,file_name;
			file_name = textBox1.Text;
			
			//グラフの初期化
			chart1.Series[0].Points.Clear();
			chart1.Series[1].Points.Clear();
			chart2.Series[0].Points.Clear();
			chart2.Series[1].Points.Clear();
			
			//折れ線グラフ
			chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

			//グラフの線の設定
			chart1.Series[0].Color = Color.Red;
			chart1.Series[1].Color = Color.Green;
			chart2.Series[0].Color = Color.Blue;
			chart2.Series[1].Color = Color.Yellow;


			//グラフの最小,最大値の取得
			if (Form2.check == true)
			{
				chart1.ChartAreas[0].AxisX.Maximum = Form2.x1_max;
				chart1.ChartAreas[0].AxisX.Minimum = Form2.x1_min;
				chart1.ChartAreas[0].AxisY.Maximum = Form2.y1_max;
				chart1.ChartAreas[0].AxisY.Minimum = Form2.y1_min;
				chart2.ChartAreas[0].AxisX.Maximum = Form2.x2_max;
				chart2.ChartAreas[0].AxisX.Minimum = Form2.x2_min;
				chart2.ChartAreas[0].AxisY.Maximum = Form2.y2_max;
				chart2.ChartAreas[0].AxisY.Minimum = Form2.y2_min;
			}
			else
			{
				chart1.ChartAreas[0].AxisX.Maximum = 1;
				chart1.ChartAreas[0].AxisX.Minimum = 0;
				chart1.ChartAreas[0].AxisY.Maximum = 0;
				chart1.ChartAreas[0].AxisY.Minimum = 1000;
				chart2.ChartAreas[0].AxisX.Maximum = 1;
				chart2.ChartAreas[0].AxisX.Minimum = 0;
				chart2.ChartAreas[0].AxisY.Maximum = 1;
				chart2.ChartAreas[0].AxisY.Minimum = 0;

				chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
				chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
				chart2.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
				chart2.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

				chart1.ChartAreas[0].AxisX.Interval = 5000;
				chart1.ChartAreas[0].AxisY.Interval = 100;
				chart2.ChartAreas[0].AxisX.Interval = 5000;
				chart2.ChartAreas[0].AxisY.Interval = 1000;
			}

			//ファイルが開けた時の処理
			if (File.Exists(file_name))
			{
				// StreamReader の新しいインスタンスを生成する
				System.IO.StreamReader cReader = (
					new System.IO.StreamReader(file_name, System.Text.Encoding.Default)
				);

				// 読み込みできる文字がなくなるまで繰り返す
				while (cReader.Peek() >= 0)
				{
					// ファイルを 1 行ずつ読み込む
					string stBuffer = cReader.ReadLine();

					//文字列の長さで変な行の排除
					if (stBuffer.Length >= 35)
					{
						continue;
					}

					//timeの値取得
					find = stBuffer.IndexOf(',');
					if (find <= 0)
					{
						continue;
					}
					stBuffer2 = stBuffer.Substring(0, find);
					if (check_data(stBuffer2) == false)
					{
						continue;
					}
					time = Convert.ToInt32(stBuffer2);

					//lightの値取得
					stBuffer = stBuffer.Remove(0, find + 1);
					find = stBuffer.IndexOf(',');
					if (find <= 0)
					{
						continue;
					}
					stBuffer2 = stBuffer.Substring(0, find);
					if (check_data(stBuffer2) == false)
					{
						continue;
					}
					light = Convert.ToInt32(stBuffer2);

					//gyroの値取得
					stBuffer = stBuffer.Remove(0, find + 1);
					find = stBuffer.IndexOf(',');
					if (find <= 0)
					{
						continue;
					}
					stBuffer2 = stBuffer.Substring(0, find);
					if (check_data(stBuffer2) == false)
					{
						continue;
					}
					gyro = Convert.ToInt32(stBuffer2);

					//motor_Rの値取得
					stBuffer = stBuffer.Remove(0, find + 1);
					find = stBuffer.IndexOf(',');
					if (find <= 0)
					{
						continue;
					}
					stBuffer2 = stBuffer.Substring(0, find);
					if (check_data(stBuffer2) == false)
					{
						continue;
					}
					motor_R = Convert.ToInt32(stBuffer2);

					//motor_Lの値取得
					stBuffer = stBuffer.Remove(0, find + 1);
					stBuffer2 = stBuffer;
					if (check_data(stBuffer2) == false)
					{
						continue;
					}
					motor_L = Convert.ToInt32(stBuffer2);

					if (time < 0 || light < 0||gyro<0|| light > 1000||gyro>1000)
					{
						continue;
					}

					//軸調整
					if (time > chart1.ChartAreas[0].AxisX.Maximum)
					{
						chart1.ChartAreas[0].AxisX.Maximum = time;
						chart2.ChartAreas[0].AxisX.Maximum = time;
					}
					if (time < chart1.ChartAreas[0].AxisX.Minimum)
					{
						chart1.ChartAreas[0].AxisX.Minimum = time;
						chart2.ChartAreas[0].AxisX.Minimum = time;
					}

					if (light > chart1.ChartAreas[0].AxisY.Maximum)
					{
						chart1.ChartAreas[0].AxisY.Maximum = light;
					}
					if (light < chart1.ChartAreas[0].AxisY.Minimum)
					{
						chart1.ChartAreas[0].AxisY.Minimum = light;
					}

					if (gyro > chart1.ChartAreas[0].AxisY.Maximum)
					{
						chart1.ChartAreas[0].AxisY.Maximum = gyro;
					}
					if (gyro < chart1.ChartAreas[0].AxisY.Minimum)
					{
						chart1.ChartAreas[0].AxisY.Minimum = gyro;
					}

					if (motor_R > chart2.ChartAreas[0].AxisY.Maximum)
					{
						chart2.ChartAreas[0].AxisY.Maximum = motor_R;
					}
					if (motor_R < chart2.ChartAreas[0].AxisY.Minimum)
					{
						chart2.ChartAreas[0].AxisY.Minimum = motor_R;
					}

					if (motor_L > chart2.ChartAreas[0].AxisY.Maximum)
					{
						chart2.ChartAreas[0].AxisY.Maximum = motor_L;
					}
					if (motor_L < chart2.ChartAreas[0].AxisY.Minimum)
					{
						chart2.ChartAreas[0].AxisY.Minimum = motor_L;
					}

					//プロット
					chart1.Series[0].Points.AddXY(time, light);
					chart1.Series[1].Points.AddXY(time, gyro);
					chart2.Series[0].Points.AddXY(time, motor_R);
					chart2.Series[1].Points.AddXY(time, motor_L);

				}
				//目盛の調整
				chart1.ChartAreas[0].AxisY.Minimum -= chart1.ChartAreas[0].AxisY.Minimum % 100;
				chart2.ChartAreas[0].AxisY.Minimum -= chart2.ChartAreas[0].AxisY.Minimum % 100;
				chart1.ChartAreas[0].AxisY.Maximum += 100 - chart1.ChartAreas[0].AxisY.Maximum % 100;
				chart2.ChartAreas[0].AxisY.Maximum += 100 - chart2.ChartAreas[0].AxisY.Maximum % 100;

				chart1.ChartAreas[0].AxisX.Minimum = 0;
				chart2.ChartAreas[0].AxisX.Minimum = 0;

				//設定を使ったり、使わなかったり
				if (Form2.check == true)
				{
					chart1.ChartAreas[0].AxisX.Maximum = Form2.x1_max;
					chart1.ChartAreas[0].AxisX.Minimum = Form2.x1_min;
					chart1.ChartAreas[0].AxisY.Maximum = Form2.y1_max;
					chart1.ChartAreas[0].AxisY.Minimum = Form2.y1_min;
					chart2.ChartAreas[0].AxisX.Maximum = Form2.x2_max;
					chart2.ChartAreas[0].AxisX.Minimum = Form2.x2_min;
					chart2.ChartAreas[0].AxisY.Maximum = Form2.y2_max;
					chart2.ChartAreas[0].AxisY.Minimum = Form2.y2_min;

					chart1.ChartAreas[0].AxisX.Interval = Form2.x1_interval;
					chart1.ChartAreas[0].AxisY.Interval = Form2.y1_interval;
					chart2.ChartAreas[0].AxisX.Interval = Form2.x2_interval;
					chart2.ChartAreas[0].AxisY.Interval = Form2.y2_interval;
				}
				

				// cReader を閉じる (正しくは オブジェクトの破棄を保証する を参照)
				cReader.Close();
			}
			else
			{
				//ファイルが開けなかった時の処理
				//メッセージボックスを表示する
				MessageBox.Show("正しいパスを入力してください。",
				"エラー",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}
		//データをチェックする
		public bool check_data(String str)
		{
			bool flag = true;
			foreach (char c in str)
			{
			    //数字以外の文字が含まれているか調べる
			    if (c!='-'&&(c < '0' || '9' < c))
				{
				    flag = false;
				    break;
			    }
			}
			if(str.Length>=10){
				flag=false;
			}
			return flag;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				// ダイアログのタイトルを設定する
				openFileDialog1.Title = "データ選択";
				// 初期表示するディレクトリを設定する
				//Documents/J2_logがあったら常にそこを開く
				if (System.IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\J2_log"))
				{
					openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\J2_log";
				}
				else
				{
					openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				}
				textBox1.Text=openFileDialog1.FileName;
				System.IO.StreamReader sr = new
				System.IO.StreamReader(@openFileDialog1.FileName);
				
				sr.Close();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form2 Fm2 = new Form2();

			Fm2.StartPosition = FormStartPosition.CenterScreen;
			Fm2.ShowDialog();
		}
	}
}
