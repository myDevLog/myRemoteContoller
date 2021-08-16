using System;
using System.Collections.Generic;
using System.Text;


namespace myRemoteController
{
	public class ControlView{
		protected string Name { get { return Name; } set{ Name = value; } }
		protected string ImageName { get { return ImageName; } set { ImageName = value; } }

		
		public ControlView(string Viewname = "", string Picname = ""){
			this.Name = Viewname;
			this.ImageName = Picname;
		}
	}
}
