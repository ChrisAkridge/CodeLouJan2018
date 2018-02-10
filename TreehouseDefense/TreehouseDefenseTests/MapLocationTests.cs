using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreehouseDefense;

namespace TreehouseDefenseTests
{
	[TestClass]
	public class MapLocationTests
	{
		[TestMethod]
		public void ShouldThrowIfNotOnMap()
		{
			var map = new Map(3, 3);
			Assert.ThrowsException<OutOfBoundsException>(() => new MapLocation(3, 3, map));
		}

		[TestMethod]
		public void InRangeOfWithRange1()
		{
			var map = new Map(3, 3);
			var target = new MapLocation(0, 0, map);

			Assert.IsTrue(target.InRangeOf(new MapLocation(0, 1, map), 1));
		}
	}
}
