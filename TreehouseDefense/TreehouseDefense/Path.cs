using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
	class Path
	{
		private MapLocation[] path;

		public MapLocation this[int index]
		{
			get => (index >= 0 && index < path.Length) ? path[index] : null;
		}

		public int Length => path.Length;

		public Path(MapLocation[] path)
		{
			this.path = path;
		}
	}
}
