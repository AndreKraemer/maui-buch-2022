using Microsoft.Maui.Controls.Shapes;
namespace MauiDemo;
public class MainPageCsInitializer : ContentPage
{
    public MainPageCsInitializer()
    {
        Title = "Login via C#-Initializer";
        BackgroundColor = Color.FromArgb("#f0f1f7");
        Content = new StackLayout
        {
            Children =
            {
                new VerticalStackLayout
                {
                    Spacing = 25,
                    Padding = 30,
                    Children =
                    {
                        new Label
                        {
                            FontSize = 20,
                            Text="Herzlich Willkommen zur .NET-MAUI-Demo"
                        },
                        new Border
                        {
                            BackgroundColor = Colors.White,
                            Stroke = Colors.White,
                            StrokeShape = new RoundRectangle
                            {
                                CornerRadius = new CornerRadius(10,10,10,10)
                            },
                            Padding= 20,
                            Content = new VerticalStackLayout
                            {
                                Spacing = 15,
                                Children =
                                {
                                    new Label { Text= "Benutzername", TextColor = Color.FromArgb("#6d6d6d") },
                                    new Entry { Text = "Wilhelm.Brause" },
                                    new Label { Text= "Passwort", TextColor = Color.FromArgb("#6d6d6d") },
                                    new Entry { IsPassword = true },
                                    new Button { Text = "Absenden" }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}