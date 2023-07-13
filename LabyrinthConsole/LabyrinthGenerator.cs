namespace LabyrinthConsole;

public class LabyrinthGenerator
{
    public static LabyrinthMap GenerateMap(int width, int height)
    {
        LabyrinthMap map = LabyrinthMap.Create(width, height);
        return map;
    }
}