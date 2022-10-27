using System.Drawing;

namespace Big6Search.ScriptingEngine
{

    // Public Module PointExtensions
    // <Extension()> _
    // Public Function IsWithin(point As Point, rectangle As Rectangle) As Boolean
    // Return (point.X >= rectangle.Left) AndAlso (point.X <= rectangle.Right) AndAlso (point.Y >= rectangle.Top) AndAlso (point.Y <= rectangle.Bottom)
    // End Function
    // End Module


    public static class PointLib
    {
        public static bool IsWithin(Point point, Rectangle rectangle)
        {
            return point.X >= rectangle.Left && point.X <= rectangle.Right && point.Y >= rectangle.Top && point.Y <= rectangle.Bottom;
        }
    }
}