﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal;

[Serializable]
internal class CureLightWoundsCorporealSpell : Spell
{
    private CureLightWoundsCorporealSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(CureLightWounds2d10Script) };

    public override string Name => "Cure Light Wounds";

    protected override string LearnedDetails => "heal 2d10";
}