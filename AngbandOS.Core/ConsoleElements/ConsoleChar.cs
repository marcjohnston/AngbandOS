namespace AngbandOS.Core.ConsoleElements
{
    /// <summary>
    /// Represents a character that can be rendered via the console.  The character can have a separate colour.
    /// </summary>
    internal class ConsoleChar : ConsoleElement
    {
        public char Char { get; set; }
        public Colour Colour { get; set; }

        public override int Width => 1;

        public override int Height => 1;

        public override void Print(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
        {
            ConsoleAlignment alignment = Alignment ?? parentAlignment;
            ConsoleLocation location = alignment.ComputeTopLeftLocation(this, containerWindow);
            location.ToWindow(Width, Height).Clear(saveGame, Colour.Background);
            saveGame.Print(Colour, Char, location.Y, location.X);
        }

        public ConsoleChar(Colour colour, char c)
        {
            Colour = colour;
            Char = c;
        }

        public override string ToString()
        {
            return Char.ToString();
        }
    }
}
