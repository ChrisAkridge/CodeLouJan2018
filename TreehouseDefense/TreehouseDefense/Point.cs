using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
	public class Point
	{
		public readonly int X;
		public readonly int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int DistanceTo(Point p)
		{
			int xDiff = X - p.X;
			int yDiff = Y - p.Y;

			return (int)Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
		}

		public override bool Equals(object obj)
		{
			if (obj is Point)
			{
				var other = (Point)obj;
				return other.X == X && other.Y == Y;
			}
			return false;
		}

		public override int GetHashCode() => X ^ Y;
		public override string ToString() => $"{X}, {Y}";
	}
}
