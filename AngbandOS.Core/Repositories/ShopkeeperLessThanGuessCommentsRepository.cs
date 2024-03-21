// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class ShopkeeperLessThanGuessCommentsRepository : StringListRepository
{
    public ShopkeeperLessThanGuessCommentsRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns ShopkeeperLessThanGuessComments as the name of this string list repository.
    /// </summary>
    public override string Name => "ShopkeeperLessThanGuessComments";

    public override void Load()
    {
        if (Game.Configuration.ShopkeeperLessThanGuessComments == null)
        {
            Add("Damn!",
                "You bastard!",
                "The shopkeeper curses at you.",
                "The shopkeeper glares at you."
                );
        }
        else
        {
            Add(Game.Configuration.ShopkeeperLessThanGuessComments);
        }
    }
}