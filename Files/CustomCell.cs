using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;


namespace myRemoteController {

	//the cell is meant for the listview
	class CustomCell : ViewCell{
		private readonly MyElements Elements = new MyElements();

		public CustomCell() {
			Label cellText = Elements.CreateLabel();

			Image cellImage = Elements.CreateImage();
			Frame cellFrame = Elements.CreateListFrame();
			cellFrame.Content = cellImage;

			StackLayout myCell = Elements.CreateStackLayout(StackOrientation.Horizontal);
			myCell.Children.Add(cellFrame);
			myCell.Children.Add(cellText);


			View = myCell;

			cellImage.SetBinding(Image.SourceProperty, "ImageName");
			cellText.SetBinding(Label.TextProperty, "Name");
		}
	}
}
