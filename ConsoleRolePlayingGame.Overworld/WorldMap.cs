using ConsoleRolePlayingGame.Overworld.Generators;
using ConsoleRolePlayingGame.Overworld.Structure;

namespace ConsoleRolePlayingGame.Overworld;

public class WorldMap(MapGenerator map)
{
    private readonly List<IMapEntity> _entities = [];
    public IEnumerable<IMapEntity> Entities => _entities.AsReadOnly();
    
    public void AddEntity(IMapEntity entity) => _entities.Add(entity);
    public void RemoveEntity(IMapEntity entity) => _entities.Remove(entity);
    public MapCell[,] GetMapWindow(Pos topLeft, int width, int height)
    {
        MapCell[,] mapWindow = new MapCell[width, height];
        for (int y = topLeft.Y; y < topLeft.Y + height; y++)
        {
            for (int x = topLeft.X; x < topLeft.X + width; x++)
            {
                Pos pos = new Pos(x, y);
                TerrainType terrain = map.CalculateTerrain(pos);
                mapWindow[x - topLeft.X, y - topLeft.Y] =
                    new MapCell(terrain, pos);
            }
        }
        return mapWindow;
    }
}