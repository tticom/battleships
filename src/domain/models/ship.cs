using BattleshipGame.Domain.Enums;

namespace BattleshipGame.Domain.Models;

public class Ship
{
    public ShipType Type { get; }
    public List<Position> Positions { get; }
    private readonly HashSet<Position> _hits = new();

    public Ship(ShipType type, List<Position> positions)
    {
        Type = type;
        Positions = positions;
    }

    public bool RegisterHit(Position pos)
    {
        if (!Positions.Contains(pos)) return false;
        _hits.Add(pos);
        return true;
    }

    public bool IsSunk => _hits.Count == Positions.Count;
}
