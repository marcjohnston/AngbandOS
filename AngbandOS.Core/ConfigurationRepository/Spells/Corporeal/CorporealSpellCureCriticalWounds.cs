﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal;

[Serializable]
internal class CorporealSpellCureCriticalWounds : Spell
{
    private CorporealSpellCureCriticalWounds(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.RestoreHealth(SaveGame.Rng.DiceRoll(8, 10));
        SaveGame.TimedStun.ResetTimer();
        SaveGame.TimedBleeding.ResetTimer();
    }

    public override string Name => "Cure Critical Wounds";
    
    protected override string? Info()
    {
        return "heal 8d10";
    }
}