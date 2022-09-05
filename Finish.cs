using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class Finish
	{
		public static char Symbol = '@';
		public int _FinishPosition { get; private set; }
		public Road _Road { get; private set; }
		public Map _Map { get; private set; }

		private Random _Rand = new Random();

		public Finish(Map Map, Road Road)
		{
			_Map = Map;
			_Road = Road;
			_FinishPosition = _Rand.Next(1, _Road._Road.Length-1);
			_Road.UpdateFinishPosition(_FinishPosition);
		}
	}
}
