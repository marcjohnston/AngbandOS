﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellVampiricBranding : Spell
{
    private DeathSpellVampiricBranding(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.BrandWeapon(3);
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(21, 2);
    }

    public override string Name => "Vampiric Branding";
    
}