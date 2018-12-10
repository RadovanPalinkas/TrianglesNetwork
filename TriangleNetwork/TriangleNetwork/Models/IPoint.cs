namespace TriangleNetwork.Models
{
    public interface IPoint
    {
        decimal X { get; set; }
        decimal Y { get; set; }

        void SetPoint(string souradniceX, string souradniceY);
        Point CreatePoint();
    }
}