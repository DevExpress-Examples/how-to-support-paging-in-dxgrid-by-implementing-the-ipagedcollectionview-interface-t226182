using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DXGridDataPager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        PagedCollectionView source;
        public MainWindow() {
            InitializeComponent();

            InitSource();
            InitDataPager();
            DataContext = source;
        }
        void InitSource() {
            source = new PagedCollectionView(TestDataList.Create(20));
            source.PageSize = 5;
        }
        void InitDataPager() {
            DataPager.PageSize = source.PageSize;
            DataPager.Source = source;
        }
    }
    
    public class TestDataList : ObservableCollection<TestDataItem> {
        public static TestDataList Create(int cc) {
            TestDataList res = new TestDataList();
            for(int i = 0; i < 10; i++) {
                TestDataItem item = new TestDataItem();
                item.ID = i;
                item.Value = ((char)((int)'A' + cc)).ToString();
                res.Add(item);
            }
            for(int i = 0; i < 10; i++) {
                TestDataItem item = new TestDataItem();
                item.ID = i;
                item.Value = ((char)((int)'B' + cc)).ToString();
                res.Add(item);
            }
            return res;
        }
    }
    public class TestDataItem {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}
