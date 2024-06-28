// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemMatches;

[Serializable]
internal abstract class ItemMatch
{
    protected Game Game { get; }
    public string Title { get; }

    protected ItemMatch(Game game, string title)
    {
        Game = game;
    }

    public abstract bool Matches(Item item);
    public override string ToString()
    {
        return Title;
    }
}
