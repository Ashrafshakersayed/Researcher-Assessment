using Researcher_Assessment.Controls;
using Researcher_Assessment.Research;
using System;
using System.Windows;

namespace Researcher_Assessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ResearcherController researcherController;
        public event Action<Researcher> DisResChanged;


        public MainWindow()
        {
            researcherController = new ResearcherController();
            researcherController.LoadReseachers();

            InitializeComponent();

            researcherList.DispList = researcherController.DisList;
            researcherList.SelectionChanged += handleSelectionChanged;
            researcherList.TextChanged += handleTextChanged;
            researcherList.comboBoxChanged += handleComboBoxChanged;

            DisResChanged += researcherDetails.handleDisResChanged;

        }

        private void handleComboBoxChanged(int level)
        {
            if (level == 0)
            {
                researcherController.DisList = researcherController.MainList;
            }

            else
            {
                researcherController.FilterBy((EmploymentLevel)(level - 1));
            }

            researcherList.ResListView.ItemsSource = researcherController.DisList;

        }

        private void handleTextChanged(string name)
        {
            researcherController.FilterByName(name);
            researcherList.ResListView.ItemsSource = researcherController.DisList;

        }

        private void handleSelectionChanged(int id)
        {
            researcherController.LoadResearcherDetails(id);
            DisResChanged(researcherController.disResearcher);
        }
    }
}
