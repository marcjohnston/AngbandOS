﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Folk;

[Serializable]
internal class ResistColdFolkSpell : Spell
{
    private ResistColdFolkSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(ResistCold1d20p20Script) };

    public override string Name => "Resist Cold";

    protected override string LearnedDetails => "dur 20+d20";
}