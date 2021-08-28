using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace myRemoteController{
	public partial class MainPage : ContentPage{
		public IList<ViewInfo> Info { get; private set; }

		private readonly MyValues Values = new MyValues();
		private readonly int amountColumns;


		public MainPage(){
			InitializeComponent();

			Info = new List<ViewInfo>();
			Info.Add(new ViewInfo { Name = "Spitfire", ImageName = "Logo.jpg" });
			Info.Add(new ViewInfo { Name = "Penis", ImageName = "Icon.png" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png" });


			amountColumns = CalcAmountColumns();



			if (amountColumns > 1) {
				ScrollView scrollableGrid = new ScrollView();
				Grid test = new Grid();

				for (int i = 0; i < amountColumns; i++) {
					test.ColumnDefinitions.Add(new ColumnDefinition());
				}

				for (int gridIndex = 0; gridIndex < Info.Count; gridIndex++) {
					test.Children.Add(GenerateCell(Info[gridIndex].ImageName, Info[gridIndex].Name), gridIndex % amountColumns, (int)(gridIndex / amountColumns) );
				}

				//set and show the grid
				scrollableGrid.Content = test;
				Content = scrollableGrid;

			} else {

				ListView viewList = new ListView { SelectionMode = ListViewSelectionMode.None, Margin = Values.GetPadMarg(), RowHeight = Values.GetImgDims() / 2 };
				viewList.ItemTemplate = new DataTemplate(typeof(CustomCell));

				viewList.ItemsSource = Info;
				Content = viewList;
			}
		}


		private StackLayout GenerateCell(string ImageName, string ViewName) {
			
			

			Image viewImage = new Image {
				Source = ImageName,
				Aspect = Aspect.AspectFill
			};

			int imgDims = Values.GetImgDims();
			Frame viewFrame = new Frame {
				Content = viewImage,
				CornerRadius = Values.GetCornerRadius(),
				IsClippedToBounds = true,
				HeightRequest = imgDims,
				WidthRequest = imgDims,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = false,
				Padding = 0
			};


			Label viewLabel = new Label {
				Text = ViewName,
				HorizontalTextAlignment = TextAlignment.Center,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};


			StackLayout controlView = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = Values.GetPadMarg(),
				Children = { viewFrame, viewLabel }
			};

			return controlView;
		}


		public async void ToSpitfire(object sender, EventArgs e) {
			await Navigation.PushAsync(new SpitfireControl());
		}


		private int CalcAmountColumns() {
			int imgDims = Values.GetImgDims(), spacing = Values.GetSpacing();
			double viewWidth = Values.GetViewWidth(), viewDensity = Values.GetViewDensity();

			int columnWidth = (imgDims + spacing * 2);
			return (int)((viewWidth / columnWidth) / viewDensity);
		}
	}
}
