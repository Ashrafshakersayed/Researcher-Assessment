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
    /// Interaction logic for PositonView.xaml
    /// </summary>
    public partial class PositonView : UserControl
    {
        public PositonView( Position pos)
        {
            InitializeComponent();
            startTB.Text = pos.Start.Date.ToShortDateString();
            endTB.Text = pos.End.Date.ToShortDateString();
            TitleTB.Text = pos.Title.Trim();

        }
    }
}
