namespace BattleshipGame.Domain.Models;

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
        if (ship.Positions.Any(p => !ValidPosition(p) || Cells[p.Row, p.Column].Ship != null))
            return false;

        Ships.Add(ship);
        foreach (var pos in ship.Positions)
            Cells[pos.Row, pos.Column].Ship = ship;

        return true;
    }

    public (bool isHit, Ship? ship, bool isSunk) Shoot(Position pos)
    {
        if (!ValidPosition(pos))
            throw new ArgumentException("Invalid position");

        var cell = Cells[pos.Row, pos.Column];
        cell.IsHit = true;

        if (cell.Ship == null) return (false, null, false);

        bool hit = cell.Ship.RegisterHit(pos);
        return (hit, cell.Ship, cell.Ship.IsSunk);
    }

    private bool ValidPosition(Position p) =>
        p.Row >= 0 && p.Row < Size && p.Column >= 0 && p.Column < Size;
}
