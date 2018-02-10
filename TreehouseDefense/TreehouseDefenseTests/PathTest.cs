using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreehouseDefense;

namespace TreehouseDefenseTests
{
	[TestClass]
	public class PathTest
	{
		private Path MakePath(out Map map)
		{
			var myMap = new Map(3, 3);
			var mapLocations = new MapLocation[]
			{
				new MapLocation(0, 1, myMap),
				new MapLocation(1, 1, myMap),
				new MapLocation(2, 1, myMap),
			};

			map = myMap;
			return new Path(mapLocations);
		}

		[TestMethod]
		public void MapLocationIsOnPath()
		{
			Map map = null;
			var target = MakePath(out map);

			Assert.IsTrue(target.IsOnPath(new MapLocation(0, 1, map)));
		}

		[TestMethod]
		public void MapLocationIsNotOnPath()
		{
			Map map = null;
			var target = MakePath(out map);

			Assert.IsFalse(target.IsOnPath(new MapLocation(0, 2, map)));
		}
	}
}
