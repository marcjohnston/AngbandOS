﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class ShopkeeperWorthlessCommentsRepository : StringsRepository
{
    public ShopkeeperWorthlessCommentsRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns ShopkeeperWorthlessComments as the name of this string list repository.
    /// </summary>
    public override string Name => "ShopkeeperWorthlessComments";

    public override void Load(GameConfiguration configuration)
    {
        if (configuration.ShopkeeperWorthlessComments == null)
        {
            Add("Arrgghh!",
                "You bastard!",
                "You hear someone sobbing...",
                "The shopkeeper howls in agony!"
                );
        }
        else
        {
            Add(configuration.ShopkeeperWorthlessComments);
        }
    }
}