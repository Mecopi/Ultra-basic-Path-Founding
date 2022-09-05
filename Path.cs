using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathF
{
	public class Path
	{
		public List<int> _Moves { get; private set; } = new List<int>();
		public int _StartPosition { get; private set; }
		public Path(int StartPosition, int Moves)
		{
			_StartPosition = StartPosition;
			for(int i = 0; i < int.Parse(("" + Moves).Replace("-", string.Empty)); i++)
				_Moves.Add(Moves < 0 ? (int)Character.Direction.Left : (int)Character.Direction.Right);
			_Moves.Add((int)Character.Direction.Down);
		}
		public void Run() => _Moves.ForEach(x => Program._Character.Move((Character.Direction)x));

	}
}
