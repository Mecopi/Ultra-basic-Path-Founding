using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class Road
	{

		public static char Symbol = ' ';
		private int _Width { get; set; }
		public int _Position { get; private set; }
		public string _Road { get; private set; } = string.Empty;

		public Road(int Position, int Width)
		{
			_Position = Position;
			_Width = Width;
			Build();
			Show();
		}

		private void Build()
		{
			_Road += Wall.Symbol;
			for (int i = 1; i < _Width - 1; i++)
				_Road += Symbol;
			_Road += Wall.Symbol;
		}
		public void Show()
		{
			int i = 0;
			foreach(char c in _Road)
			{
				Console.SetCursorPosition(i, _Position);
				Console.Write(c);
				i++;
			}
			Console.SetCursorPosition(0, _Position + 1);
		}
		public void UpdatePlayerPosition(int CharPosition)
		{
			(int, int) PreviousCursorPosition = Console.GetCursorPosition();
			int i = 0;
			foreach (char c in _Road)
			{
				Console.SetCursorPosition(i, _Position);
				Console.Write(i == CharPosition ? Character.Symbol : this == Program._Map._Finish._Road ? i == Program._Map._Finish._FinishPosition ? Finish.Symbol : c : c);
				i++;
			}
			Console.SetCursorPosition(PreviousCursorPosition.Item1, PreviousCursorPosition.Item2);
		}
		public void UpdateFinishPosition(int FinishPosition)
		{
			(int, int) PreviousCursorPosition = Console.GetCursorPosition();
			int i = 0;
			foreach (char c in _Road)
			{
				Console.SetCursorPosition(i, _Position);
				Console.Write(i == FinishPosition ? Finish.Symbol : c);
				i++;
			}
			Console.SetCursorPosition(PreviousCursorPosition.Item1, PreviousCursorPosition.Item2);
		}
	}
}
