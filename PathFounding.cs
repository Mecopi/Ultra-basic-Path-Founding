using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class PathFounding
	{
		private List<Path> Paths = new List<Path>();
		private Map _Map { get; set; }
		private Character _Character { get; set; }
		public PathFounding(Map Map, Character Characteur)
		{
			_Map = Map;
			_Character = Characteur;
			while(!Program._IsFinish)
				Calculating();
		}
		private void Calculating()
		{
			Paths.Clear();
			Wall NextWall = _Map.Walls[_Map.Roads.IndexOf(_Character._Road)+1];
			int i = 0;
			foreach(char c in NextWall._Wall)
			{
				if(c == Road.Symbol)
					Paths.Add(new Path(_Character._CharacterPosition, i < 0 ? _Character._CharacterPosition - i : i - _Character._CharacterPosition));
				i++;
			}
			if (Paths.Count == 0)
				Paths.Add(new Path(_Character._CharacterPosition, _Map._Finish._FinishPosition - _Character._CharacterPosition));
			GetBestPath().Run();
		}
		private Path GetBestPath()
		{
			int Moves = 1000;
			int lessMovesPath = 0;
			int i = 0;
			foreach(Path p in Paths)
			{
				if(p._Moves.Count < Moves)
				{
					Moves = p._Moves.Count;
					lessMovesPath = i;
				}
				i++;
			}
			return Paths[lessMovesPath];
		}


		// WaysDistance.Add(i < 0 ? CharacterPosition - i : i - CharacterPosition); Pour avoir le déplacement fidele
	}
}
