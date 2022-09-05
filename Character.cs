using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class Character
	{
		public enum Direction
		{
			Left = 0,
			Right = 1,
			Down = 2
		}
		
		public static char Symbol = '♥';
		public int _CharacterPosition { get; private set; }
		public Road _Road { get; private set; }
		public Map _Map { get; private set; }

		private Random _Rand = new Random();

		private const int MOVING_SPEED = 20;

		public Character(Map Map, Road Road)
		{
			_Map = Map;
			_Road = Road;
			_CharacterPosition = _Rand.Next(1, _Road._Road.Length-1);
			_Road.UpdatePlayerPosition(_CharacterPosition);
		}
		public void Move(Direction Direction)
		{
			switch (Direction)
			{
				case Direction.Left:
					if(_Road._Road[_CharacterPosition-1] != Wall.Symbol)
					{
						_CharacterPosition--;
						_Road.UpdatePlayerPosition(_CharacterPosition);
						Thread.Sleep(MOVING_SPEED);
					}
					Program.IsFinish();
				break;
				case Direction.Right:
					if (_Road._Road[_CharacterPosition + 1] != Wall.Symbol)
					{
						_CharacterPosition++;
						_Road.UpdatePlayerPosition(_CharacterPosition);
						Thread.Sleep(MOVING_SPEED);
					}
					Program.IsFinish();
					break;
				case Direction.Down:
					if(_Map.Walls[_Map.Roads.IndexOf(_Road)+1]._Wall[_CharacterPosition] == Road.Symbol)
					{
						_Road.Show();
						_Road = _Map.Roads[_Map.Roads.IndexOf(_Road)+1];
						_Road.UpdatePlayerPosition(_CharacterPosition);
						Thread.Sleep(MOVING_SPEED);
					}
					Program.IsFinish();
				break;
			}
		}
	}
}
