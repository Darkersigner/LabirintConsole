// See https://aka.ms/new-console-template for more information

using LabyrinthConsole;

const int defaultWidth = 40, defaultHeight = 10, defaultRepeats = 10000;
int width = defaultWidth, height = defaultHeight, repeats = defaultRepeats;

SetupParams(args, ref width, ref height, ref repeats);

var map = LabyrinthGenerator.GenerateMap(width, height);
int index = 0;
Console.Clear();
var start = DateTime.Now;
map.WriteMap();
while (index++ < repeats)
{
    map.Hit();
    var countStars = map.GetCountStars();
    Console.SetCursorPosition(0, height);
    Console.WriteLine($"Hits is {index}\tStars : {countStars} Seconds: {(DateTime.Now - start).TotalSeconds}");
    if (countStars >= (width - 2) * (height - 2))
    {
        break;
    }
}

void SetupParams(IReadOnlyList<string> args, ref int width, ref int height, ref int repeats)
{
    if (args.Count > 0)
    {
        if (!int.TryParse(args[0], out width))
        {
            width = defaultWidth;
        }
    }

    if (args.Count > 1)
    {
        if (!int.TryParse(args[1], out height))
        {
            height = defaultHeight;
        }
    }

    if (args.Count > 2)
    {
        if (!int.TryParse(args[2], out repeats))
        {
            repeats = defaultRepeats;
        }
    }
}