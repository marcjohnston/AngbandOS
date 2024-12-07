// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents an object that compares an item with some matching criteria.  The <see cref="ItemFilter"/> objects bind using these <see cref="ItemMatch"/> objects to perform run-time item
/// matching without needing to compare all of the properties of a complete <see cref="ItemFilter"/> object.
/// </summary>
[Serializable]
internal abstract class ItemMatch : IDebugDescription
{
    protected Game Game { get; }
    public string Title { get; }

    public string DebugDescription { get; set; }

    protected ItemMatch(Game game, string debugDescription)
    {
        Game = game;
        DebugDescription = debugDescription;
    }

    public abstract bool Matches(Item item);
    public override string ToString()
    {
        return DebugDescription;
    }
}