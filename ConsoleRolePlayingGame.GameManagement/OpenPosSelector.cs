using ConsoleRolePlayingGame.Overworld;
using ConsoleRolePlayingGame.Overworld.Structure;

namespace ConsoleRolePlayingGame.GameManagement;

public class OpenPosSelector(WorldMap map)
{
    public Pos GetOpenPositionNear(Pos source, int min, int max)
    {
        HashSet<Pos> occupied = [..map.Entities.Select(e => e.MapPos)];
        Random rand = Random.Shared;
        Pos pos;
        do
        {
            int offset = rand.Next(min, max + 1);
            int xOffset = (int)Math.Round(rand.NextDouble() * offset);
            int yOffset = offset - xOffset;

            if (rand.NextDouble() < 0.5)
            {
                xOffset *= -1;
            }

            if (rand.NextDouble() < 0.5)
            {
                yOffset *= -1;
            }
            pos = new Pos(source.X + xOffset, source.Y + yOffset);   
        } while (occupied.Contains(pos));
        return pos;
    }
}