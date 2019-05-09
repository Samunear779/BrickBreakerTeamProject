using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
	public class Score
	{
		public int score = 0;
		public string name = null;

		public Score(string _name, int _score)
		{
			name = _name;
			score = _score;
		}
	}
}
