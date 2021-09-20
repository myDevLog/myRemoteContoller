﻿using System;
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


			if (amountColumns == 1) {

				CollectionView viewCollection = new CollectionView {
					SelectionMode = SelectionMode.Single,
					Margin = Values.GetPadMarg(),
					ItemsLayout = new GridItemsLayout(amountColumns, ItemsLayoutOrientation.Vertical)
				};

				/*
				viewCollection.SelectionChanged += async (object sender, SelectionChangedEventArgs eventArgs) => {
					//stop a crash because the deselection causes another event without selected item
					if(((CollectionView)sender).SelectedItem != null) { 
						string pageName = (eventArgs.CurrentSelection.FirstOrDefault() as ViewInfo)?.PageName;

						Type pageType = Type.GetType($"myRemoteController.{pageName}");
						Page newPage = Activator.CreateInstance(pageType) as Page;

						await Application.Current.MainPage.Navigation.PushAsync(newPage);

						//deselect Item
						((CollectionView)sender).SelectedItem = null;
					}
				};
				*/


				viewCollection.SetBinding(ItemsView.ItemsSourceProperty, "Info");
				viewCollection.ItemsSource = Info;

				viewCollection.ItemTemplate = new DataTemplate(() => {

					Label viewLabel = new Label {
						FontAttributes = FontAttributes.Bold,
						FontSize = Values.GetFontSize(),
						HorizontalTextAlignment = TextAlignment.Center,
						Margin = Values.GetPadMarg(),
						Padding = 0
					};
					viewLabel.SetBinding(Label.TextProperty, "Name");

					Image viewImage = new Image {
						Aspect = Aspect.AspectFill
					};
					viewImage.SetBinding(Image.SourceProperty, "ImageName");


					int imgDims = Values.GetImgDims();
					Frame viewFrame = new Frame {
						Content = viewImage,
						CornerRadius = Values.GetCornerRadius(),
						IsClippedToBounds = true,
						WidthRequest = imgDims,
						HeightRequest = imgDims,
						VerticalOptions = LayoutOptions.Center,
						HorizontalOptions = LayoutOptions.Center,
						Padding = 0,
						HasShadow = false
					};

					string pageName = "SpitfireControl";

					TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
					tapGestureRecognizer.Tapped += async (sender, EventArgs) => {
						Type pageType = Type.GetType($"myRemoteController.{pageName}");
						Page newPage = Activator.CreateInstance(pageType) as Page;

						await Application.Current.MainPage.Navigation.PushAsync(newPage);
					};
					
					StackLayout controlView = new StackLayout {
						Orientation = StackOrientation.Vertical,
						Padding = Values.GetPadMarg(),
						Children = { viewFrame, viewLabel },
						GestureRecognizers = { tapGestureRecognizer }
					};
					
					return controlView;
				});

				/*
				Grid viewGrid = new Grid ();

				for (int i = 0; i < amountColumns; i++) {
					viewGrid.ColumnDefinitions.Add(new ColumnDefinition());
				}


				for (int gridIndex = 0; gridIndex < Info.Count; gridIndex++) {
					viewGrid.Children.Add(
						GenerateCell( Info[gridIndex].ImageName, Info[gridIndex].Name, Info[gridIndex].PageName),
						gridIndex % amountColumns,
						(int)(gridIndex / amountColumns)
					);
				}*/

				/*
				TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
				tapGestureRecognizer.Tapped += async (sender, eventArgs) => {
					int infoIndex = Grid.GetColumn((Xamarin.Forms.BindableObject)sender) * amountColumns + Grid.GetRow((Xamarin.Forms.BindableObject)sender);
					string pageName = Info[infoIndex].PageName;

					Type pageType = Type.GetType($"myRemoteController.{pageName}");
					Page newPage = Activator.CreateInstance(pageType) as Page;

					await Application.Current.MainPage.Navigation.PushAsync(newPage);
				};
				
				viewGrid.GestureRecognizers.Add(tapGestureRecognizer);
				*/

				ScrollView scrollableGrid = new ScrollView {
					VerticalScrollBarVisibility = ScrollBarVisibility.Always,
					Content = viewCollection
				};

				//show the grid
				Content = scrollableGrid;

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


				ScrollView scrollableList = new ScrollView {
					VerticalScrollBarVisibility = ScrollBarVisibility.Always,
					Content = viewList
				};

				//show the list
				Content = scrollableList;
			}
		}


		


		private StackLayout GenerateCell(string ImageName, string ViewName, string PageName) {

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
				FontSize = Values.GetFontSize()
			};

			
			TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 1};
			tapGestureRecognizer.Tapped += async (object s, EventArgs e) => {
				Type pageType = Type.GetType($"myRemoteController.{PageName}");
				Page newPage = Activator.CreateInstance(pageType) as Page;

				await Application.Current.MainPage.Navigation.PushAsync(newPage);
			};
			
			
			StackLayout controlView = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = Values.GetPadMarg(),
				Children = { viewFrame, viewLabel },
				GestureRecognizers = { tapGestureRecognizer }
			};

			return controlView;
		}

		private int CalcAmountColumns() {
			int imgDims = Values.GetImgDims(), spacing = Values.GetSpacing();
			double viewWidth = Values.GetViewWidth(), viewDensity = Values.GetViewDensity();

			int columnWidth = (imgDims + spacing * 2);
			return (int)((viewWidth / columnWidth) / viewDensity);
		}
	}
}
