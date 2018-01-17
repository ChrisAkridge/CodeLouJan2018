using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
	class Tower
	{
		private const int FiringRange = 1;
		private const int DamageAmount = 1;
		private const double Accuracy = 0.75d;

		private static Random random = new Random();

		private readonly MapLocation location;

		public Tower(MapLocation location, Path path)
		{
			for (int i = 0; i < path.Length; i++)
			{
				if (location.Equals(path[i]))
				{
					throw new ArgumentException($"A tower cannot be placed at {location.X}, {location.Y} as it is on the path.");
				}
			}
			this.location = location;
		}

		public void FireOnInaders(Invader[] invaders)
		{
			foreach (var invader in invaders)
			{
				if (random.NextDouble() < Accuracy)
				{
					if (location.InRangeOf(invader.Location, FiringRange) && invader.IsActive)
					{
						invader.DecreaseHealth(DamageAmount);
						Console.WriteLine("Shot hit");
						if (invader.IsDead) { Console.WriteLine("Invader killed"); }
						break;  // towers can only fire on one target at a time
					}
					Console.WriteLine("Shot missed");
				}
			}
		}
	}
}
