using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;


namespace myRemoteController {
	class MyValues {
		private readonly double viewHeight, viewWidth, viewDensity;
		//spacing is half margin, half padding
		private readonly int spacing = 10, imgDims = 200, cornerRadius = 15;


		public MyValues() {
			//DeviceDisplay Only works on Android
			var temp = DeviceDisplay.MainDisplayInfo;
			viewHeight = temp.Height;
			viewWidth = temp.Width;
			viewDensity = temp.Density;
		}


		public double GetViewHeight() {
			return viewHeight;
		}

		public double GetViewWidth() {
			return viewWidth;
		}

		public double GetViewDensity() {
			return viewDensity;
		}

		public int GetSpacing() {
			return spacing;
		}

		public int GetImgDims() {
			return imgDims;
		}

		public int GetCornerRadius() {
			return cornerRadius;
		}

		public int GetPadMarg() {
			return (int)(spacing / 2);
		}
	}
}
