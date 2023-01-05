namespace AngbandOS.Core.ConsoleElements
{
    internal abstract class ConsoleElement
    {
        public abstract int Width { get; }

        public abstract int Height { get; }

        /// <summary>
        /// Returns the position within the parent window where the element should be placed or null, to inherit from the parent.
        /// </summary>
        public ConsoleAlignment? Alignment { get; set; } = null;

        public abstract void Print(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment);

        public void Print(SaveGame saveGame, ConsoleWindow containerWindow)
        {
            Print(saveGame, containerWindow, new ConsoleTopLeftAlignment());
        }
    }
}
