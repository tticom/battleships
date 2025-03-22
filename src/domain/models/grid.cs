public class Grid
{
    public const int Size = 10;
    public Cell[,] Cells { get; } = new Cell[Size, Size];

    public List<Ship> Ships { get; } = new();

    public Grid()
    {
        for (int r = 0; r < Size; r++)
        for (int c = 0; c < Size; c++)
            Cells[r, c] = new Cell(r, c);
    }

    public bool AddShip(Ship ship)
    {
        if (ship.Positions.Any(p => !IsValid(p) || Cells[p.Row, p.Column].Ship != null))
            return false;

        Ships.Add(ship);
        foreach (var pos in ship.Positions)
            Cells[pos.Row, pos.Column].Ship = ship;

        return true;
    }

    public (HitResult result, Ship? ship) Shoot(Position pos)
    {
        if (!IsValid(pos))
            throw new ArgumentException("Invalid Position.");

        var cell = Cells[pos.Row, pos.Column];
        cell.IsHit = true;

        if (cell.Ship == null)
            return (HitResult.Miss, null);

        var result = cell.Ship.RegisterHit(pos);
        return (result, cell.Ship);
    }

    private bool IsValid(Position p) => p.Row >= 0 && p.Row < Size && p.Column >= 0 && p.Column < Size;
}
