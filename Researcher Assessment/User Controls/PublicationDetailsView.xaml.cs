using System.Windows.Controls;

namespace Researcher_Assessment.User_Controls
{
    /// <summary>
    /// Interaction logic for PublicationDetailsView.xaml
    /// </summary>
    public partial class PublicationDetailsView : UserControl
    {
        public PublicationDetailsView(Research.Publication pub)
        {
            InitializeComponent();
            NameTB.Text = pub.Title;
            TitleTB.Text = pub.Title;
            DOITB.Text = pub.DOI;
            YesrTB.Text = pub.Year.ToString();
            AuthorsTB.Text = pub.Authors;
            TypeTB.Text = pub.Type.ToString();
            CiteTB.Text = pub.CiteAs;
            AvailablityTB.Text = pub.Available.Date.ToShortDateString();
        }

    }
}
