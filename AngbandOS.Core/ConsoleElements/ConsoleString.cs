using System.Collections;

namespace AngbandOS.Core.ConsoleElements
{
    /// <summary>
    /// Represents a string that can be rendered via the console.  Each character in the string can have a separate colour.
    /// </summary>
    internal class ConsoleString : ConsoleElement, IEnumerable<ConsoleChar>
    {
        private List<ConsoleChar> characters = new List<ConsoleChar>();

        public ConsoleString(Colour colour, string text)
        {
            foreach (char c in text)
            {
                Append(colour, c);
            }
        }

        public void Append(Colour colour, string text)
        {
            foreach (char c in text)
            {
                Append(colour, c);
            }
        }

        public void Append(Colour colour, char c)
        {
            characters.Add(new ConsoleChar(colour, c));
        }

        public IEnumerator<ConsoleChar> GetEnumerator()
        {
            return characters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return characters.GetEnumerator();
        }

        public override void Print(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
        {
            ConsoleAlignment alignment = Alignment ?? parentAlignment;
            ConsoleLocation location = alignment.ComputeTopLeftLocation(this, containerWindow);
            location.ToWindow(Width, Height).Clear(saveGame, Colour.Background);

            foreach (ConsoleChar consoleChar in characters)
            {
                consoleChar.Print(saveGame, location.ToWindow(consoleChar.Width, consoleChar.Height), alignment);
                location = location.Offset(1, 0);
            }
        }

        public int Length
        {
            get
            {
                return characters.Count;
            }
        }

        public override int Width => characters.Count;

        public override int Height => 1;

        public override string ToString()
        {
            return new string(characters.Select(_character => _character.Char).ToArray());
        }
    }
}
