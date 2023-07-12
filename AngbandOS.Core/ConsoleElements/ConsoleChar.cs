// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ConsoleElements;

/// <summary>
/// Represents a character that can be rendered via the console.  The character can have a separate colour.
/// </summary>
internal class ConsoleChar : ConsoleElement
{
    public char Char { get; set; }
    public ColourEnum Colour { get; set; }

    public override int Width => 1;

    public override int Height => 1;

    public override void Render(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
    {
        ConsoleAlignment alignment = Alignment ?? parentAlignment;
        ConsoleLocation location = alignment.ComputeTopLeftLocation(this, containerWindow);
        location.ToWindow(Width, Height).Clear(saveGame, ColourEnum.Background);
        saveGame.Screen.Print(Colour, Char, location.Y, location.X);
    }

    public ConsoleChar(ColourEnum colour, char c)
    {
        Colour = colour;
        Char = c;
    }

    public override string ToString()
    {
        return Char.ToString();
    }
}
