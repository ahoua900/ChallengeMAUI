using ChallengeMAUI.Challenges.Jour_1.Views;

namespace ChallengeMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TaskManagementPage());
        }
    }
}
