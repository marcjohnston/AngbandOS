﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class HerbalHealingNatureSpell : Spell
{
    private HerbalHealingNatureSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(HerbalHealingScript) };

    public override string Name => "Herbal Healing";

    protected override string LearnedDetails => "heal 1000";
}