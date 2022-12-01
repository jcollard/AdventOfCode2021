public class EastMovingSeaCucumber : AbstractSeaCucumber
{
    public override char ToChar => '>';
    public override (int Row, int Col) Speed => (0, 1);
    public EastMovingSeaCucumber(SeaFloor seaFloor, int row, int col) : base(seaFloor, row, col)
    {
    }
}