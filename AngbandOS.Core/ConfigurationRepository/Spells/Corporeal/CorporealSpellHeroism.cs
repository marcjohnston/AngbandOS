﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal;

[Serializable]
internal class CorporealSpellHeroism : Spell
{
    private CorporealSpellHeroism(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedHeroism.AddTimer(SaveGame.Rng.DieRoll(25) + 25);
        SaveGame.RestoreHealth(10);
        SaveGame.TimedFear.ResetTimer();
    }

    public override string Name => "Heroism";
    
    protected override string? Info()
    {
        return "dur 25+d25";
    }
}