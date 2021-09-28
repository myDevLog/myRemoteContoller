using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;


namespace myRemoteController {
	class CustomCell : ViewCell{

		private readonly MyValues Values = new MyValues();

		public CustomCell() {
			Label cellText = new Label {
				FontAttributes = FontAttributes.Bold,
				FontSize = Values.GetFontSize(),
				VerticalTextAlignment = TextAlignment.Center,
				Margin = Values.GetPadMarg(),
				Padding = 0
			};


			Image cellImage = new Image {
				Aspect = Aspect.AspectFill
			};

			int imgDims = Values.GetImgDims();
			Frame cellFrame = new Frame {
				Content = cellImage,
				CornerRadius = Values.GetCornerRadius(),
				IsClippedToBounds = true,
				WidthRequest = imgDims / Values.GetViewDensity(),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Padding = 0,
				HasShadow = false
			};


			StackLayout myCell = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = { cellFrame, cellText },
				Margin = Values.GetPadMarg()
			};

			View = myCell;

			cellImage.SetBinding(Image.SourceProperty, "ImageName");
			cellText.SetBinding(Label.TextProperty, "Name");
		}
	}
}
