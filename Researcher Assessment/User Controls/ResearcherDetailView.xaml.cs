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
    /// Interaction logic for ResearcherDetailView.xaml
    /// </summary>
    public partial class ResearcherDetailView : UserControl
    {

        public ResearcherDetailView()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        
        }

        internal void handleDisResChanged(Researcher res)
        {
            nameTB.Text = res.GivenName;
            EmailTB.Text = res.Email.Trim();
            TitleTB.Text = res.Title;
            UnitTB.Text = res.Unit;
            CompusTB.Text = res.Campus;
            JobTB.Text = res.GetCurrentJob().Title.Trim();
            pubTB.Text = res.PublicationsCount().ToString();
            TenureTB.Text = res.Tenure().ToString() + " Years";
            try
            {
            img.Source = new BitmapImage(new Uri(res.Photo));

            }
            catch (Exception)
            {

                MessageBox.Show("can not load the Photo from the url");
            }
            currDateTB.Text = res.CurrentJobStart().Date.ToShortDateString();
            startDateTB.Text = res.EarliestStart().Date.ToShortDateString();

            pubListView.ItemsSource = res.publications;

            if (res is Staff)
            {
                AverageTB.Text = ((Staff)res).ThreeYearAverage().ToString();
                performanceTB.Text = ((Staff)res).Performance().ToString()+ " %";
                DegreeTB.Text = "";


            }
            else
            {
                DegreeTB.Text = ((Student)res).Degree;
                AverageTB.Text = "";
                performanceTB.Text = "";
            }

            PositonsContainer.Children.Clear();
            if (res.positions.Count ==0)
            {
                return;
            }
            foreach (Position pos in res.positions)
            {
                PositonsContainer.Children.Add(
                    new PositonView(pos));
            }
        }

        private void pubListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           var PublicationWin = new PublicationDetailWin((Publication)pubListView.SelectedItem);
            PublicationWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PublicationWin.ShowDialog();
        }
    }
}
