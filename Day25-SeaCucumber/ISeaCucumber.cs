public interface ISeaCucumber
{
    public char ToChar { get; }
    public (int Row, int Col) Position { get; set; }
    public (int Row, int Col) NextPosition { get; }
    public (int Row, int Col) Speed { get; }
    public bool CanMove { get; }
    public static ISeaCucumber? Make(char ch, SeaFloor seaFloor, int row, int col)
    {
        return ch switch {
            '>' => new EastMovingSeaCucumber(seaFloor, row, col),
            'v' => new SouthMovingSeaCucumber(seaFloor, row, col),
            _ => null
        };
    }
}