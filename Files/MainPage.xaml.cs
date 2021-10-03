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
			Info.Add(new ViewInfo { Name = "Spitfire", ImageName = "Logo.jpg" , PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Penis", ImageName = "Icon.png", PageName = "NotThere" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });
			Info.Add(new ViewInfo { Name = "Test", ImageName = "Icon.png", PageName = "SpitfireControl" });


			amountColumns = CalcAmountColumns();


			ScrollView scrollableView = new ScrollView {
				VerticalScrollBarVisibility = ScrollBarVisibility.Always
			};

			if (amountColumns == 1) {

				CollectionView viewCollection = new CollectionView {
					SelectionMode = SelectionMode.Single,
					Margin = Values.GetPadMarg(),
					ItemsLayout = new GridItemsLayout(amountColumns, ItemsLayoutOrientation.Vertical)
				};


				viewCollection.SetBinding(ItemsView.ItemsSourceProperty, "Info");
				viewCollection.ItemsSource = Info;


				viewCollection.SelectionChanged += async (object sender, SelectionChangedEventArgs eventArgs) => {
					//stop a crash because the deselection causes another event without selected item
					CollectionView s = (CollectionView)sender;

					if (s.SelectedItem != null) {
						string pageName = (eventArgs.CurrentSelection.FirstOrDefault() as ViewInfo)?.PageName;

						Type pageType = Type.GetType($"myRemoteController.{pageName}");
						Page newPage = Activator.CreateInstance(pageType) as Page;

						await Application.Current.MainPage.Navigation.PushAsync(newPage);

						//deselect Item
						s.SelectedItem = null;
					}
				};


				viewCollection.ItemTemplate = new DataTemplate(() => {
					MyElements Elements = new MyElements();

					Label viewLabel = Elements.CreateLabel();
					viewLabel.SetBinding(Label.TextProperty, "Name");

					Image viewImage = Elements.CreateImage();
					viewImage.SetBinding(Image.SourceProperty, "ImageName");

					Frame viewFrame = Elements.CreateCollectionFrame();
					viewFrame.Content = viewImage;


					StackLayout controlView = Elements.CreateStackLayout(StackOrientation.Vertical);
					controlView.Children.Add(viewFrame);
					controlView.Children.Add(viewLabel);


					return controlView;
				});


				scrollableView.Content = viewCollection;

			} else {
				ListView viewList = new ListView {
					SelectionMode = ListViewSelectionMode.None,
					Margin = Values.GetPadMarg(),
					RowHeight = Values.GetImgDims() / 2
				};

				viewList.ItemTemplate = new DataTemplate(typeof(CustomCell));

				//set the data
				viewList.ItemsSource = Info;


				//create page when item gets tapped
				viewList.ItemTapped += async (sender, eventArgs) => {
					string pageName = Info[eventArgs.ItemIndex].PageName;
					Type pageType = Type.GetType($"myRemoteController.{pageName}");
					Page newPage = Activator.CreateInstance(pageType) as Page;

					await Application.Current.MainPage.Navigation.PushAsync(newPage);
				};


				scrollableView.Content = viewList;
			}

			Content = scrollableView;
		}


		private int CalcAmountColumns() {
			int imgDims = Values.GetImgDims(), spacing = Values.GetSpacing();
			double viewWidth = Values.GetViewWidth(), viewDensity = Values.GetViewDensity();

			int columnWidth = (imgDims + spacing * 2);
			return (int)((viewWidth / columnWidth) / viewDensity);
		}
	}
}
