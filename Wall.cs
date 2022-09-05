using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class Wall
	{
		public static char Symbol = '■';
		private bool _isFull { get; set; }
		private int _Width { get; set; }
		public int _Position { get; private set; }
		public string _Wall { get; private set; } = string.Empty;

		private const int _MIN_SIZE = 1;
		private const int _MAX_SIZE = 5;
		private Random _Rand = new Random();

		public Wall(int Position, int Width, bool isFull = false)
		{
			_Position = Position;
			_Width = Width;
			_isFull = isFull;
			Build();
			Show();
		}
		private void Build()
		{
			if(_isFull)
				for (int i = 0; i < _Width; i++)
					_Wall += Symbol;
			else
			{
				while(_Wall.Length < _Width || !_Wall.Contains(' '))
				{
					_Wall = Symbol.ToString();
					string Buffer = _Wall;
					int i = 1;
					while (Buffer.Length <= _Width)
					{
						if (Buffer[i - 1] != Symbol)
						{
							int WallSize = _Rand.Next(_MIN_SIZE, _MAX_SIZE + 1);
							for (int j = 0; j <= WallSize; j++)
								Buffer += Symbol;
							break;
						}
						else
						{
							int Randomizer = _Rand.Next(0, 4);
							switch (Randomizer)
							{
								case 1:
									Buffer += Road.Symbol;
									break;
								default:
									int WallSize = _Rand.Next(_MIN_SIZE, _MAX_SIZE + 1);
									for (int j = 0; j <= WallSize; j++)
										Buffer += Symbol;
									break;
							}
						}
						i = Buffer.Length - 1;
					}
					Buffer = Buffer.Substring(0, Buffer.Length > _Width ? _Width - 1 : Buffer.Length - 1);
					_Wall = Buffer;
					_Wall += Symbol;
				}
			}
		}
		private void Show()
		{
			int i = 0;
			foreach(char c in _Wall)
			{
				Console.SetCursorPosition(i, _Position);
				Console.Write(c);
				i++;
			}
			Console.SetCursorPosition(0, _Position + 1);
		}
	}
}
