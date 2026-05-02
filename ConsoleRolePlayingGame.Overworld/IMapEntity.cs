using ConsoleRolePlayingGame.Overworld.Structure;

namespace ConsoleRolePlayingGame.Overworld;

public interface IMapEntity
{
    EntityType EntityType { get; }
    Pos MapPos { get; set; }
}