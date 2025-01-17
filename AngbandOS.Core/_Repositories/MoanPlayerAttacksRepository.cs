﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class MoanPlayerAttacksRepository : StringsRepository
{
    public MoanPlayerAttacksRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns MoanPlayerAttacks as the name of this string list repository.
    /// </summary>
    public override string Name => "MoanPlayerAttacks";

    public override void Load(GameConfiguration configuration)
    {
        if (configuration.MoanPlayerAttacks == null)
        {
            Add("seems sad about something.",
                "asks if you have seen his dogs.",
                "tells you to get off his land.",
                "mumbles something about mushrooms."
                );
        }
        else
        {
            Add(configuration.MoanPlayerAttacks);
        }
    }
}