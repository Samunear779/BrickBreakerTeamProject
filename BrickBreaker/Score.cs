﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
	public class Score
	{
		public string score = null;
		public string name = null;

		public Score(string _name, string _score)
		{
			name = _name;
			score = _score;
		}
	}
}
