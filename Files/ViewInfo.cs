using System;
using System.Collections.Generic;
using System.Text;

namespace myRemoteController
{
	public class ViewInfo{
		public string Name { get; set; }
		public string ImageName { get; set; }

		public override string ToString() {
			return Name;
		}
	}
}
