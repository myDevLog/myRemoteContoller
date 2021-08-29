# myRemoteContoller
One app to control my RC Vehicles

## Specifications:
- [ ] One screen which lists the different controlviews for different RC-vehicles
- [x] Listed views should contain a name and a image 
- [x] Controlviews should be listed automatically with name and image
- [x] Views should be flexably positioned across the screen
- [ ] List of views should be scrollable if to many for screensize
- [ ] Should work on IOS and Android
- [ ] Should remember the previously selected controlview
- [x] Mobile-First approach, then Tablet, no Desktop
- [ ] View should adjust with the rotation of the device

## Setup
### How to create the project?
1. Open Visual Studio
2. Create New Project
3. Select _"Mobile App (Xamarin.Forms)"_
4. Press Next
5. Configure New Project
6. Press Create
7. Select Empty
8. Make sure IOS and Android is selected, not Window
9. Press Create

### How to setup the project?
1. Open the project
2. Open the project explorer 
3. Expand the main folder (_segment with the project name_)
4. Replace MainPage.xaml and MainPage.xaml.cs with the one in files (___make sure that MainPage.xaml.cs is beneath MainPage.xaml___)
5. Drag and drop CustomCell.cs, Viewinfo.cs and MyValues.cs into the Main Folder
