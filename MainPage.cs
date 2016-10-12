using System;
using Core;
using Xamarin.Forms;

namespace Forms
{
	public class MainPage: ContentPage
	{
		Entry txtPhone;
		Button btnTranslate;
		Button btnCall;
		EventHandler OnTranslate;
		String translatedNumber;

		public MainPage()
		{
			double spacing = Device.OnPlatform<double>(
				40, // iOS
				20, // Android
				20  // Windows Phone
			);

			this.Padding = new Thickness(20, spacing, 20, 20);

			Initialize();
		}

		private void Initialize()
		{
			StackLayout panel = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Spacing = 15,
				Children = {
					new Label {
						HorizontalTextAlignment = TextAlignment.Center,
						Text = "Enter a Phoneword:"
					}
				}
			};

			panel.Children.Add(txtPhone = new Entry{
				Text = "1-855-XAMARIN",
			});
			panel.Children.Add(btnTranslate = new Button{
				Text = "Translate"
			});
			panel.Children.Add(btnCall = new Button{
				Text = "Call",
				IsEnabled = false
			});

			btnTranslate.Clicked += OnTranslate = (object sender, EventArgs e) =>
			{
				translatedNumber = PhonewordTranslator.ToNumber(txtPhone.Text);
				if (String.IsNullOrEmpty(translatedNumber))
				{
					btnCall.Text = "Call";
					btnCall.IsEnabled = false;
				}
				else
				{
					btnCall.Text = "Call " + translatedNumber;
					btnCall.IsEnabled = true;
				}
			};

			btnCall.Clicked += (object sender, EventArgs e) =>
			{
			};

			Content = panel;
		}
	}
}
