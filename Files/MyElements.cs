using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace myRemoteController {
	class MyElements {

		private readonly MyValues Values = new MyValues();

		public Label CreateLabel() {
			Label viewLabel = new Label {
				FontAttributes = FontAttributes.Bold,
				FontSize = Values.GetFontSize(),
				HorizontalTextAlignment = TextAlignment.Center,
				Margin = Values.GetPadMarg(),
				Padding = 0
			};

			return viewLabel;
		}

		public Image CreateImage() {
			Image viewImage = new Image {
				Aspect = Aspect.AspectFill
			};

			return viewImage;
		}

		public Frame CreateListFrame() {
			Frame cellFrame = new Frame {
				CornerRadius = Values.GetCornerRadius(),
				IsClippedToBounds = true,
				WidthRequest = Values.GetImgDims() / Values.GetViewDensity(),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Padding = 0,
				HasShadow = false
			};

			return cellFrame;
		}

		public Frame CreateCollectionFrame() {
			int imgDims = Values.GetImgDims();
			
			Frame CollectionFrame = new Frame {
				CornerRadius = Values.GetCornerRadius(),
				IsClippedToBounds = true,
				WidthRequest = imgDims,
				HeightRequest = imgDims,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Padding = 0,
				HasShadow = false
			};

			return CollectionFrame;
		}

		public StackLayout CreateStackLayout(StackOrientation stackOrientation) {

			StackLayout controlView = new StackLayout {
				Orientation = stackOrientation,
				Padding = Values.GetPadMarg()
			};

			return controlView;
		}
	}
}
