namespace AngbandOS.Core.ConsoleElements
{
    /// <summary>
    /// Represents an abstract element that can be rendered on the screen.
    /// </summary>
    internal abstract class ConsoleElement
    {
        public abstract int Width { get; }

        public abstract int Height { get; }

        /// <summary>
        /// Returns the position within the parent window where the element should be placed or null, to inherit from the parent.
        /// </summary>
        public ConsoleAlignment? Alignment { get; set; } = null;

        public abstract void Render(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment);
    }
}
