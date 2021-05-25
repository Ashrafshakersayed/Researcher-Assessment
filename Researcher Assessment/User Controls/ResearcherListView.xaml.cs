using Researcher_Assessment.Research;
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

namespace Researcher_Assessment.User_Controls
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    public partial class ResearcherListView : UserControl
    {
        public List<Researcher> DispList { get; set; }
        public event Action<int> SelectionChanged;
        public event Action<string> TextChanged;
        public event Action<int> comboBoxChanged;




        public ResearcherListView()
        {
            
            InitializeComponent();


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxChanged != null)
            {
                comboBoxChanged(filterCB.SelectedIndex);

            }
        }

       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ResListView.ItemsSource = DispList;
        }

        private void ResListView_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ResListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(((ListView)sender).SelectedIndex);

            }

        }

        private void nameTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            if (TextChanged != null)
            {
                TextChanged(nameTB.Text);

            }
        }
    }
}
