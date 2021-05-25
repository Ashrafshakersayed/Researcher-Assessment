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
using System.Windows.Shapes;

namespace Researcher_Assessment.User_Controls
{
    /// <summary>
    /// Interaction logic for PublicationDetailWin.xaml
    /// </summary>
    public partial class PublicationDetailWin : Window
    {
        public PublicationDetailWin(Publication Pub)
        {
            InitializeComponent();
            pubDetails.Children.Add(
            new PublicationDetailsView(Pub)
            );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
