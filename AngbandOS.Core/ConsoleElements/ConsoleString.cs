// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;

namespace AngbandOS.Core.ConsoleElements;

/// <summary>
/// Represents a string that can be rendered via the console.  Each character in the string can have a separate color.
/// </summary>
internal class ConsoleString : ConsoleElement, IEnumerable<ConsoleChar>
{
    private List<ConsoleChar> characters = new List<ConsoleChar>();

    public ConsoleString(ColorEnum color, string text)
    {
        foreach (char c in text)
        {
            Append(color, c);
        }
    }

    public ConsoleString(string text) : this(ColorEnum.White, text) { }

    public void Append(ColorEnum color, string text)
    {
        foreach (char c in text)
        {
            Append(color, c);
        }
    }

    public void Append(ColorEnum color, char c)
    {
        characters.Add(new ConsoleChar(color, c));
    }

    public IEnumerator<ConsoleChar> GetEnumerator()
    {
        return characters.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return characters.GetEnumerator();
    }

    public override void Render(Game game, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
    {
        ConsoleAlignment alignment = Alignment ?? parentAlignment;
        ConsoleLocation location = alignment.ComputeTopLeftLocation(this, containerWindow);
        location.ToWindow(Width, Height).Clear(game, ColorEnum.Background);

        foreach (ConsoleChar consoleChar in characters)
        {
            consoleChar.Render(game, location.ToWindow(consoleChar.Width, consoleChar.Height), alignment);
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
