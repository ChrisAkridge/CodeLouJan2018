using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
	class Level
	{
		private readonly Invader[] invaders;

		public Tower[] Towers { get; set; }

		public Level(Invader[] invaders)
		{
			this.invaders = invaders;
		}

		/// <summary>
		/// Plays the game.
		/// </summary>
		/// <returns>Returns true if the player wins, or false if they do not.</returns>
		public bool Play()
		{
			int remainingInvaders = invaders.Length;

			while (remainingInvaders > 0)
			{
				foreach (Tower tower in Towers)
				{
					tower.FireOnInvaders(invaders);
				}

				remainingInvaders = 0;
				foreach (Invader invader in invaders)
				{
					if (invader.IsActive)
					{
						remainingInvaders++;
						invader.Move();
						if (invader.HasScored) { return false; }
					}
				}
			}

			return true;
		}
	}
}
