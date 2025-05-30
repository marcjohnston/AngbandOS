﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class VampiricBrandingDeathSpell : Spell
{
    private VampiricBrandingDeathSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(BrandWeaponAsVampiricScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildDeathMagicScript) };

    public override string Name => "Vampiric Branding";
    
}