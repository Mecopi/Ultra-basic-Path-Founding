namespace PathF
{
	public class Program
	{
		public static Map _Map;
		public static Character _Character;
		public static PathFounding _PathFounding;
		public static bool _IsFinish = false;

		private static Random _Random = new Random();
		public static void Main()
		{
			Console.Clear();
			_IsFinish = false;
			Console.ForegroundColor = (ConsoleColor)_Random.Next(1, Enum.GetValues(typeof(ConsoleColor)).Length);
			Console.SetCursorPosition(0, 0);
			Console.CursorVisible = false;
			_Map = new Map(_Random.Next(40, 71), _Random.Next(20, 41));
			_Character = new Character(_Map, _Map.Roads.First());
			_PathFounding = new PathFounding(_Map, _Character);
		}
		public static void IsFinish()
		{
			_IsFinish = _Character._Road == _Map._Finish._Road ? _Character._CharacterPosition == _Map._Finish._FinishPosition : false;
			if(_IsFinish)
			{
				Thread.Sleep(10);
				Main();
			}
		}
	}
}