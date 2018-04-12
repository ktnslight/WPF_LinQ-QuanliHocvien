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
using System.Windows.Shapes;

namespace QLHV
{
    /// <summary>
    /// Interaction logic for frm_Hocvien.xaml
    /// </summary>
    public partial class frm_Hocvien : Window
    {
        public frm_Hocvien()
        {
            InitializeComponent();
            GetData();
        }
        DataDataContext context = new DataDataContext();
        private void GetData()
        {
            
        }
    }
}
