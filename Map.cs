using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class Map
	{
		private int _Width { get; set; }
		private int _Height { get; set; }
		public Finish _Finish { get; private set; }
		public List<Road> Roads { get; private set; } = new List<Road>();
		public List<Wall> Walls { get; private set; } = new List<Wall>();

		private Random _Rand = new Random();

		public Map(int Width = 40, int Height = 20)
		{
			_Width = Width;
			_Height = Height;
			Build();
			_Finish = new Finish(this, Roads.Last());
		}
		private void Build()
		{
			Walls.Add(new Wall(Console.GetCursorPosition().Top, _Width, true));
			Roads.Add(new Road(Console.GetCursorPosition().Top, _Width));
			for (int i = 0; i < (int)Math.Round((decimal)_Height / 2)-1; i++)
			{
				Walls.Add(new Wall(Console.GetCursorPosition().Top, _Width, false));
				Roads.Add(new Road(Console.GetCursorPosition().Top, _Width));
			}
			Walls.Add(new Wall(Console.GetCursorPosition().Top, _Width, true));
		}
	}
}
