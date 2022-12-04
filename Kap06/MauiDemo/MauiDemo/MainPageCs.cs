using Microsoft.Maui.Controls.Shapes;
namespace MauiDemo;

public class MainPageCs : ContentPage
{
    public MainPageCs()
    {
        Title = "Login via C#";
        BackgroundColor = Color.FromArgb("#f0f1f7");

        var outerStackLayout = new VerticalStackLayout();
        outerStackLayout.Spacing = 25;
        outerStackLayout.Padding = 30;

        var headerLabel = new Label();
        headerLabel.FontSize = 20;
        headerLabel.Text = "Herzlich Willkommen zur .NET-MAUI-Demo";
        outerStackLayout.Children.Add(headerLabel);

        var border = new Border();
        border.BackgroundColor = Colors.White;
        border.Stroke = Colors.White;
        var roundRectangle = new RoundRectangle();
        roundRectangle.CornerRadius = new CornerRadius(10, 10, 10, 10);
        border.StrokeShape = roundRectangle;
        border.Padding = 20;

        var loginStackLayout = new VerticalStackLayout();
        loginStackLayout.Spacing = 15;
        var userLabel = new Label();
        userLabel.Text = "Benutzername";
        loginStackLayout.Children.Add(userLabel);

        var userEntry = new Entry();
        userEntry.Text = "Whilem.Brause";
        loginStackLayout.Children.Add(userEntry);

        var passwordLabel = new Label();
        passwordLabel.Text = "Passwort";
        loginStackLayout.Children.Add(passwordLabel);

        var passwordEntry = new Entry();
        passwordEntry.IsPassword = true;
        loginStackLayout.Children.Add(passwordEntry);

        var loginButton = new Button();
        loginButton.Text = "Absenden";
        loginStackLayout.Children.Add(loginButton);

        border.Content = loginStackLayout;
        outerStackLayout.Children.Add(border);
        Content = outerStackLayout;
    }
}