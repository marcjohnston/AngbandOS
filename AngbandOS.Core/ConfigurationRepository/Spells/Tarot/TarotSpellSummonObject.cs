﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellSummonObject : Spell
{
    private TarotSpellSummonObject(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.SummonItem(dir, SaveGame.ExperienceLevel * 15, true);
    }

    public override string Name => "Summon Object";
    
    protected override string? Info()
    {
        return $"max wgt {SaveGame.ExperienceLevel * 15 / 10}";
    }
}