using ChallengeMAUI.Challenges.Jour_1.ViewModels;
using System.Globalization;

namespace ChallengeMAUI.Challenges.Jour_1.Views;

public partial class TaskManagementPage : ContentPage
{
    double activeday = 0;

    public TaskManagementPage()
    {
        InitializeComponent();
        ChargerCalendrier(DateTime.Now.Year, DateTime.Now.Month);
        BindingContext = new TaskManageViewModel();
    }
    public void ChargerCalendrier(int year, int month)
    {
        calendrier.Children.Clear();
        // Calculer le premier jour du mois et le nombre de jours dans ce mois
        var firstDayOfMonth = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);
        int dayOfWeek = (int)firstDayOfMonth.DayOfWeek;
        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime currentDate = new(year, month, day);
            Frame frame = new()
            {
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.Transparent,
                Margin = new Thickness(1),
                Padding = new Thickness(3)
            };
            var tapGestureRecognizer = new TapGestureRecognizer
            {
                CommandParameter = currentDate.ToString("dd/MM/yyyy")
            };

            StackLayout views = new()
            {
                Spacing = 5
            };
            var dayname = currentDate.ToString("ddd");
            Label label = new()
            {
                Text = dayname,
                TextColor = Colors.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                FontFamily = "PoppinsRegular",
                FontSize = 11
            };

            Button button = new()
            {
                Text = currentDate.Day.ToString().ToUpper(),
                TextColor = Colors.Black,
                BackgroundColor = Colors.White,
                FontSize = 12,
                Padding = new Thickness(5),
                CornerRadius = 100,
                WidthRequest = 35,
                HeightRequest = 32,
                FontFamily = "PoppinsRegular"
            };
            if (currentDate.Date == DateTime.Now.Date)
            {
                label.FontAttributes = FontAttributes.Bold;
                label.TextColor = Colors.Black;
                button.BackgroundColor = Colors.LightGray;
                button.FontAttributes = FontAttributes.Bold;
                button.TextColor = Colors.Black;
                activeday = button.Bounds.X;
            }
            views.Children.Add(label);
            views.Children.Add(button);
            frame.Content = views;

            calendrier.Children.Add(frame);
        }
    }
    private  void TapChange_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button button1 = (Button)sender;
            foreach (var child in selectmenu.Children)
            {
                if (child is Button button)
                {
                    // Réinitialiser les propriétés uniquement si actif
                    if (button.BackgroundColor == (Color)Application.Current.Resources["SelectColor"])
                    {
                        button1.BackgroundColor = Colors.Transparent;
                    }
                }
            }
            button1.BackgroundColor = Color.FromHex("#393939");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error occurred", ex.Message.ToString(), "Ok");
        }
    }
}