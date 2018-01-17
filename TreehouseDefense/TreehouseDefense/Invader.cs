using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
	class Invader
	{
		private int pathStep = 0;
		private readonly Path path;

		public MapLocation Location => path[pathStep];
		public int Health { get; private set; } = 2;

		public bool HasScored => pathStep == path.Length;
		public bool IsDead => Health == 0;
		public bool IsActive => !(IsDead || HasScored);

		public Invader(Path path) => this.path = path;
		public void Move() => pathStep++;

		public void DecreaseHealth(int amount)
		{
			if (Health - amount < 0) { Health = 0; }
			else { Health -= amount; }
		}
	}
}
