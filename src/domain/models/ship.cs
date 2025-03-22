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

    public HitResult RegisterHit(Position shot)
    {
        if (!Positions.Contains(shot))
            return HitResult.Miss;

        _hits.Add(shot);

        return IsSunk ? HitResult.Sunk : HitResult.Hit;
    }

    public bool IsSunk => _hits.Count == Positions.Count;
}
