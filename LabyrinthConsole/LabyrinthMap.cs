namespace LabyrinthConsole;

public class LabyrinthMap
{
    private readonly int _width;
    private readonly int _height;
    private List<string> _map = new();

    private char _wall = '#';
    private LabyrinthMap(int width, int height)
    {
        _width = width;
        _height = height;
        for (int i = 0; i < _height; i++)
        {
            string line;
            if (i == 0 || i == _height - 1)
            {
                line = new string(_wall, _width);
            }
            else
            {
                line = _wall +  new string(' ', _width-2) + _wall;
            }
            _map.Add(line);
        }
    }

    public static LabyrinthMap Create(int width, int height)
    {
        var map = new LabyrinthMap(width, height);
        return map;
    }

    public void WriteMap()
    {
        Console.SetCursorPosition(0,0);
        Console.CursorVisible = false;
        foreach (var line in _map)
        {
            Console.WriteLine(line);
        }

        // _map[replaceHeightIndex] = temp;
    }

    public int GetCountStars()
    {
        int count = 0;
        foreach (var line in _map)
        {
            count += line.Count(c => c == '*');
        }

        return count;
    }
    
    public void Hit()
    {
        var rnd = new Random();
        var replaceHeightIndex = rnd.Next(1, _height - 1);
        var replaceWidthIndex = rnd.Next(1, _width - 1);
        string temp = _map[replaceHeightIndex];
        char[] arr = _map[replaceHeightIndex].ToCharArray();
        var replaceChar = arr[replaceWidthIndex];
        if (replaceChar == ' ')
            arr[replaceWidthIndex] = '1';
        else if (char.IsDigit(replaceChar))
        {
            int number = replaceChar;
            if (number == 57)
            {
                arr[replaceWidthIndex] = '*';
            }
            else
            {
                arr[replaceWidthIndex] = (char)(number +1) ;   
            }
        }
        _map[replaceHeightIndex] = new string(arr);
        Console.SetCursorPosition(replaceWidthIndex,replaceHeightIndex);
        Console.Write(arr[replaceWidthIndex]);
        // WriteMap();
    }
}