﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericSpell : Spell
{
    public GenericSpell(Game game, SpellGameConfiguration spellGameConfiguration) : base(game)
    {
        Key = spellGameConfiguration.Key ?? spellGameConfiguration.GetType().Name;
        Name = spellGameConfiguration.Name;
        CastScriptNames = spellGameConfiguration.CastScriptNames;
        CastFailedScriptNames = spellGameConfiguration.CastFailedScriptNames;
        LearnedDetails = spellGameConfiguration.LearnedDetails;
    }

    public override string Key { get; }

    /// <summary>
    /// Returns the name of the spell, as rendered to the Game.
    /// </summary>
    public override string Name { get; }

    protected override string[]? CastScriptNames { get; }
    protected override string[]? CastFailedScriptNames { get; }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    /// <returns></returns>
    protected override string LearnedDetails { get; }
}