using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreehouseDefense;

namespace TreehouseDefenseTests
{
	[TestClass]
	public class PointTests
	{
		[TestMethod]
		public void PointCtorTest()
		{
			var point = new Point(5, 6);

			Assert.AreEqual(5, point.X);
			Assert.AreEqual(6, point.Y);
		}

		[TestMethod]
		public void DistanceToWithPythagoreanTriple()
		{
			var point = new Point(3, 4);
			var target = new Point(0, 0);

			var expected = 5d;
			var actual = target.DistanceTo(point);

			Assert.AreEqual(expected, actual, 2d);
		}

		[TestMethod]
		public void DistanceToPointAtSamePosition()
		{
			var point = new Point(0, 0);
			var target = new Point(0, 0);

			Assert.AreEqual(point.DistanceTo(target), 0d);
		}
	}
}
