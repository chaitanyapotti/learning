using System;
using System.Configuration;
using System.Windows;
using PersonRepository.Interface;
using PersonRepository.CSV;
using PersonRepository.Service;
//using PersonRepository.SQL;

namespace ExtensibilityPeopleViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            SetRepo("Service");

        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
            SetRepo("CSV");

        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {
            SetRepo("SQL");
        }

        private void SetRepo(string repoType)
        {
            IPersonRepository repo = GetRepository(repoType);
            var people = repo.GetPeople();
            PersonListBox.ItemsSource = people;
            ShowRepositoryType(repo);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.ItemsSource = null;
        }

        private void ShowRepositoryType(IPersonRepository repository)
        {
            MessageBox.Show($"Repository Type:\n{repository.GetType().ToString()}");
        }

        private static IPersonRepository GetRepository(string repositoryType)
        {
            IPersonRepository repo = null;
            switch (repositoryType)
            {
                case "Service":
                    repo = new ServiceRepository();
                    break;
                case "CSV":
                    repo = new CSVRepository();
                    break;
                case "SQL":
                    //repo = new SQLRepository();
                    break;
                default:
                    break;
            }
            return repo;
        }

        //Dynamic Loading 
        private static IPersonRepository GetRepository()
        {
            //Need to add app.config - RepositoryType key
            IPersonRepository repo = null;
            var typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            repo = repoInstance as IPersonRepository;
            return repo;
            //Need to add post build command line to bring the files from other project to this project bin folder
            //xcopy "$(ProjectDir)..\RepositoriesForBinFolder\*.*" "$(SolutionDir)PeopleViewer.Layered\bin\$(ConfigurationName)" / Y
        }
    }
}
