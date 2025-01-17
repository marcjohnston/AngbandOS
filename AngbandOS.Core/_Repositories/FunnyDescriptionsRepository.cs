﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class FunnyDescriptionsRepository : StringsRepository
{
    public FunnyDescriptionsRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns FunnyDescriptions as the name of this string list repository.
    /// </summary>
    public override string Name => "FunnyDescriptions";

    public override void Load(GameConfiguration configuration)
    {
        if (configuration.FunnyDescriptions == null)
        {
            Add("silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
                "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
                "amazing", "incredible", "chaotic", "wild", "preposterous");
        }
        else
        {
            Add(configuration.FunnyDescriptions);
        }
    }
}