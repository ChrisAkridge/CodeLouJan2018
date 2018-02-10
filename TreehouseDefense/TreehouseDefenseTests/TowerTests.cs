using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreehouseDefense;

namespace TreehouseDefenseTests
{
	[TestClass]
	public class TowerTests
	{
		[TestMethod]
		public void FireOnInvadersDecreasesInvadersHealth()
		{
			var map = new Map(3, 3);
			var path = new Path(new[] { new MapLocation(0, 1, map), new MapLocation(1, 1, map), new MapLocation(2, 1, map) });
			var target = new Tower(new MapLocation(0, 0, map), path);
			var invaders = new Invader[] { new Invader(path), new Invader(path) };

			target.FireOnInvaders(invaders);

			Assert.IsTrue(invaders.All(i => i.Health == 1));
		}
	}
}
