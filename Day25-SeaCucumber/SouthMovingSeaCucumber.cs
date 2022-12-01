public class SouthMovingSeaCucumber : AbstractSeaCucumber
{
    public override char ToChar => 'v';
    public override (int Row, int Col) Speed => (1, 0);
    public SouthMovingSeaCucumber(SeaFloor seaFloor, int row, int col) : base(seaFloor, row, col)
    {
    }
}