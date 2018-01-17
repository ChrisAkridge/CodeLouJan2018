using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
	class Game
	{
		static void Main(string[] args)
		{
			Map map = new Map(8, 5);
			Path path = new Path(
			new[] {
				new MapLocation(0, 2, map),
				new MapLocation(1, 2, map),
				new MapLocation(2, 2, map),
				new MapLocation(3, 2, map),
				new MapLocation(4, 2, map),
				new MapLocation(5, 2, map),
				new MapLocation(6, 2, map),
				new MapLocation(7, 2, map),
			});

			var invaders = new Invader[]
			{
				new Invader(path),
				new Invader(path),
				new Invader(path),
				new Invader(path)
			};

			var towers = new Tower[]
			{
				new Tower(new MapLocation(1, 3, map), path),
				new Tower(new MapLocation(3, 3, map), path),
				new Tower(new MapLocation(5, 3, map), path),
			};

			Level level = new Level(invaders)
			{
				Towers = towers
			};

			Console.WriteLine("Player " + (level.Play() ? "won" : "lost"));
			Console.ReadKey(intercept: true);
		}
	}
}
