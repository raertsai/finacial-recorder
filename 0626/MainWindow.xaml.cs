using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開啟檔案
            string[] lines = System.IO.File.ReadAllLines(@"C:\data.txt");

            // 分析
            foreach (string line in lines)
            {
                // 用 | 符號隔開
                string[] parts = line.Split('|');

                // 建立事件
                price price = new price();

                //讀取不同部份
                price.date.Text = parts[0];
                price.TaskName.Text = parts[1];
                price.TaskPrice.Text = parts[2];

                // 放到清單
                TaskList.Children.Add(price);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //建立一個空數字
            int AddPrice = 0;

            //按ENTER時會計算總數
            if (e.Key == Key.Return)
            {
                // 計算每個項目
                foreach (price item in TaskList.Children)
                {
                    //價格相加
                    AddPrice += item.itemPriceValue;
                }

                //顯示總額
                totalPrice.Text = AddPrice.ToString();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // 新增串列裝每個項目的文字
            List<string> datas = new List<string>();

            // 轉換每個項目
            foreach (price price in TaskList.Children)
            {
                //設置一個空字串
                string data = "";

                //每一種資料以"|"區隔加入data字串
                data += price.date.Text + "|" + price.TaskName.Text + "|" + price.TaskPrice.Text;

                //加入Datas的陣列
                datas.Add(data);
            }

            System.IO.File.WriteAllLines(@"c:\data.txt", datas);
        }


        private void addTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生項目
            price price = new price();

            //放至清單中
            TaskList.Children.Add(price);
        }
    }
}