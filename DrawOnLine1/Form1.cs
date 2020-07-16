using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DrawOnLine1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.SetStyle(ControlStyles.ResizeRedraw |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;
            InitializeComponent();
           

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Series series = chart1.Series[0];
            Series series2 = chart1.Series[1];
            series.ToolTip = "#VALX,#VALY";
            chart1.ChartAreas[0].AxisY.Title = @"ml";
            chart1.ChartAreas[0].AxisX.Title = @"Time";
            series.ChartType = SeriesChartType.SplineRange;//图表类型
            series2.ChartType = SeriesChartType.SplineRange;

            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].BackSecondaryColor = Color.AliceBlue;
            chart1.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;

            //series.Markerstyle = markerstyle.circle;
            //series.markercolor = color.white;
            //series.markerstyle = markerstyle.circle;
            //series.markercolor = color.white;
            series.BorderWidth = 1;
            //series.MarkerBorderColor = Color.Blue;
            series.Color = Color.FromArgb(100,Color.Blue);
            series2.Color = Color.FromArgb(100,Color.Orange);

            series.XValueType = ChartValueType.Auto;

            chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            chart1.ChartAreas[0].CursorX.SelectionColor = Color.SkyBlue;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = false;
            chart1.ChartAreas[0].CursorY.AutoScroll =false;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
            chart1.ChartAreas[0].CursorY.SelectionColor = Color.SkyBlue;


            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;


            chart1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;        //show the last label
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Auto;
            chart1.ChartAreas[0].AxisX.LineWidth = 2;
            chart1.ChartAreas[0].AxisX.LineColor = Color.Black;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;

            chart1.ChartAreas[0].AxisX.Crossing = 0;




            if (CheckNumberException(textBox1.Text.ToString()) && CheckNumberException(textBox2.Text.ToString()))
            {
                DrawLine(series, textBox1.Text.ToString(), textBox2.Text.ToString());
            }
            else
            {
                MessageBox.Show("请输入数字");
                return;
            }

        }

        //画线函数
        public void DrawLine(Series series, string left, string right)
        {
            int start = Convert.ToInt32(left);
            int end = Convert.ToInt32(right);
            string sql, sql2;
            if (end >= 100000000)
            {
                MessageBox.Show("区间长度不能超过10");
                return;
            }
            int DBno = start / 5000000;
            int DBno2 = (start + end) / 5000000;
            
            if (DBno != DBno2)
            {
                switch (DBno)
                {
                    case 0:
                        sql = "select * from number5000000 inner " +
                           "join(select DateTime from number5000000 limit " + left + ", " + Convert.ToInt32(5000000 - start) + ") b using (Datetime) ";
                        sql2 = "select * from number10000000 inner " +
                           "join(select DateTime from number10000000 limit " + 0 + ", " + Convert.ToInt32(end - 5000000 + start) + ") b using (Datetime) ";
                        ReaderDB(sql, sql2, series);
                        break;
                    case 1:
                        int leftreal = start - 5000000;
                        sql = "select * from number10000000 inner " +
                           "join(select DateTime from number10000000 limit " + leftreal + ", " + Convert.ToInt32(10000000 - start) + ") b using (Datetime) ";
                        sql2 = "select * from number15000000 inner " +
                            "join(select DateTime from number15000000 limit " + 0 + ", " + Convert.ToInt32(end - 10000000 + start) + ") b using (Datetime) ";
                        ReaderDB(sql, sql2, series);
                        break;
                    case 2:
                        int leftreal2 = start - 10000000;
                        sql = "select * from number15000000 inner " +
                            "join(select DateTime from number15000000 limit " + leftreal2 + ", " + Convert.ToInt32(15000000 - start) + ") b using (Datetime) ";
                        sql2 = "select * from number20000000 inner " +
                            "join(select DateTime from number20000000 limit " + 0 + ", " + Convert.ToInt32(end - 15000000 + start) + ") b using (Datetime) ";
                        ReaderDB(sql, sql2, series);
                        break;
                    case 3:
                        int leftreal3 = start - 15000000;
                        sql = "select * from number20000000 inner " +
                            "join(select DateTime from number20000000 limit " + leftreal3 + ", " + end + ") b using (Datetime) ";
                        ReaderDB(sql, series);
                        break;
                }
            }
            else
            {
                switch (DBno)
                {
                    case 0:
                        sql = "select * from number3000000 inner " +
                           "join(select DateTime from number3000000 limit " + left + ", " + end + ") b using (Datetime) ";
                        ReaderDB(sql, series);
                        break;
                    case 1:
                        int leftreal = start - 5000000;
                        sql = "select * from number10000000 inner " +
                           "join(select DateTime from number10000000 limit " + leftreal + ", " + end + ") b using (Datetime) ";
                        ReaderDB(sql, series);
                        break;
                    case 2:
                        int leftreal2 = start - 10000000;
                        sql = "select * from number15000000 inner " +
                            "join(select DateTime from number15000000 limit " + leftreal2 + ", " + end + ") b using (Datetime) ";
                        ReaderDB(sql, series);
                        break;
                    case 3:
                        int leftreal3 = start - 15000000;
                        sql = "select * from number20000000 inner " +
                            "join(select DateTime from number20000000 limit " + leftreal3 + ", " + end + ") b using (Datetime) ";
                        ReaderDB(sql, series);
                        break;
                }
            }

        }
        //分表后跨表查询
        public void ReaderDB(string sql, string sql2, Series series)
        {
            float[] DN = new float[100];//DN的向北偏移量          
            float[] DateTime = new float[100];//时间
            float[] DN2 = new float[100];//DN的向北偏移量          
            float[] DateTime2 = new float[100];//时间         

            MySQLConn con = new MySQLConn();//
            DataSet ds = new DataSet(sql);
            DN = con.GetResult(sql, "DN");
            DateTime = con.GetResult(sql, "DateTime");
            DN2 = con.GetResult(sql2, "DN");
            DateTime2 = con.GetResult(sql2, "DateTime");
            float[] DN3 = new float[DN.Length+DN2.Length];//DN的向北偏移量          
            float[] DateTime3 = new float[100];//时间         
            DN.CopyTo(DN3, 0);
            DN2.CopyTo(DN3, DN.Length);
            DateTime.CopyTo(DateTime3,0);
            DateTime2.CopyTo(DateTime3, DateTime.Length);

            for (int z = 0; z < DN3.Length; z++)
            {
                series.Points.AddXY(DateTime3[z], DN3[z]);
            }
        }
        //在单个表内查询
        public void ReaderDB(string sql,Series series2)
        {
            float[] DN = new float[300000];//DN的向北偏移量          
            DateTime[] DateTime = new DateTime[300000];//时间

            var ListDN = new List<float>();
            var ListDateTime = new List<DateTime>();

            MySQLConn con = new MySQLConn();//
            DataSet ds = new DataSet(sql);
            DN = con.GetResult(sql, "DN");

            DateTime = con.GetResult2(sql, "DateTime");
            //for (int j = 0; j < DN.Length; j++)
            //{
            //    ListDN.Add(DN[j]);
            //    ListDateTime.Add(DateTime[j]);
            //    if ((j + 1) >= DN.Length)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        if (Math.Abs(DN[j] - DN[j + 1]) <= 2)
            //        {
            //            j = j + 1;
            //        }
            //    }
            //}
            DataFilter(DN, DateTime);
            Console.WriteLine(ListDN.Count);
            Console.WriteLine(ListDateTime.Count);
            //for (int i = 0; i < ListDN.Count; i++)
            //{
            //    chart1.Series[0].Points.AddXY(ListDateTime[i], ListDN[i]);
            //}

            //for (int i = 0; i < DN.Length; i++)
            //{
            //    chart1.Series[1].Points.AddXY(DateTime[i],DN[i]);
            //}

        }

        public void DataFilter(float[] DN,DateTime[] dataTime)
        {
            var DNFilter = new List<float>();
            var DataTimeFilter = new List<DateTime?>();
            float sum=0;//y值的总数
            float ave = 0;//y值的平均值
            DateTime? aveid = new DateTime(2000,01,01,0,0,1);//x值的平均值
            float max = 0;//y最大值
            DateTime? maxid = new DateTime(2000, 01, 01, 0, 0, 1);//y最大值对应x值
            DateTime? minid = new DateTime(2000, 01, 01, 0, 0, 1);//y最小值对应的x值
            float min = 999999;//y最小值
            List<SortClass> sorts = new List<SortClass>();
            for (int i = 0; i < DN.Length; i++)
            {
                if (i % 5 == 4)
                {
                    ave = sum / 5;
                    aveid = dataTime[i];
                    sorts.Add(new SortClass(aveid, ave));
                    if (Math.Abs(min - ave) > 0)
                    {
                        sorts.Add(new SortClass(minid, min));
                    }
                    if (Math.Abs(max - ave) > 0)
                    {
                        sorts.Add(new SortClass(maxid, max));
                    }
                    List<SortClass> sort2 = sort(sorts);
                    for (int j = 0; j < sort2.Count; j++)
                    {
                        DNFilter.Add(sort2[j].Value);
                        DataTimeFilter.Add(sort2[j].Id);
                    }
                    sort2.Clear();
                    min = 999999; minid = new DateTime(2099, 01, 01, 0, 0, 1);
                    max = 0; maxid = new DateTime(2000, 01, 01, 0, 0, 1);
                    sum = 0;
                }
                else
                {
                    sum = sum + DN[i];                   
                    if (min > DN[i])
                    {
                        min = DN[i];
                        minid = dataTime[i];
                    }
                    if (max < DN[i])
                    {
                        max = DN[i];
                        maxid = dataTime[i];
                    }
                }
                //ave = 0;
                //aveid = 0;
                //min = 9999999;minid = 0;
                //max = 0;maxid = 0;

            }
            Console.WriteLine(DNFilter.Count);
            Console.WriteLine(DataTimeFilter.Count);
            for (int i = 0; i < DNFilter.Count; i++)
            {
                chart1.Series[0].XValueType = ChartValueType.DateTime;
                chart1.Series[0].Points.AddXY(DataTimeFilter[i], DNFilter[i]);
            }
            for (int i = 0; i < DN.Length; i++)
            {
                chart1.Series[1].Points.AddXY(dataTime[i], DN[i]);
            }
        }

        //检查输入是否为数字和是否为空
        public Boolean CheckNumberException(string number)
        {
            Boolean flag = false;
            //String reg = "^[-\\+]?([0-9]+\\.?)?[0-9]+$";
            float f1;
            if (number.Length == 0)
            {
                MessageBox.Show("输入不许为空");
                return flag;
            }
            else if (!float.TryParse(number, out f1))
            {
                MessageBox.Show("输入必须为数字");
                return flag;
            }

            else
            {
                return true;
            }
        }

        public Boolean CheckXLength(float start, float end)
        {

            if (end < start)
            {
                MessageBox.Show("起点不能大于终点");
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<SortClass> sort(List<SortClass> sorts)
        {
            SortClass[] sort=new SortClass[3];
            DateTime? temp;
            for(int i = 0; i < sorts.Count-1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if (sorts[j].Id < sorts[j - 1].Id)
                    {
                        temp = sorts[j - 1].Id;
                        sorts[j - 1].Id = sorts[j].Id;
                        sorts[j].Id = temp;
                    }
                }
            }
            return sorts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (chart1.Series[0].Points.Count == 0)
            //    return;
            string s = textBox1.Text.ToString();
            string en = textBox2.Text.ToString();
            DateTime dateTime = Convert.ToDateTime("2020-06-05 03:11:13");
            float start = Convert.ToSingle(s);
            float end = Convert.ToSingle(en);
            float myInterval = 0;
            if (CheckXLength(start, start + end))
            {
                myInterval = Math.Abs(end);
                if (myInterval == 0.0)
                    return;
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss"; //X轴显示的时间格式，HH为大写时是24小时制，hh小写时是12小时制
                //chart1.ChartAreas[0].AxisX.Minimum = DateTime.Parse(sDate.ToString("HH:mm:ss")).ToOADate();
                //chart1.ChartAreas[0].AxisX.Maximum = DateTime.Parse(sDate.AddSeconds(xValue).ToString("HH:mm:ss")).ToOADate();
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;//如果是时间类型的数据，间隔方式可以是秒、分、时
                chart1.ChartAreas[0].AxisX.Interval = DateTime.Parse("00:01:00").Millisecond;//间隔为5分钟
                //X轴视图起点
                //chart1.ChartAreas[0].AxisX.ScaleView.Position =Convert.ToDouble(dateTime);
                //X轴视图长度
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 1;
                //X轴间隔
                //if (myInterval < 11.0)
                //{
                //    chart1.ChartAreas[0].AxisX.Interval = 1;
                //}
                //else
                //{
                //    chart1.ChartAreas[0].AxisX.Interval = Math.Floor(myInterval / 10);
                //}
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
