﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellHorrify : Spell
{
    private DeathSpellHorrify(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FearMonster(dir, SaveGame.ExperienceLevel);
        SaveGame.StunMonster(dir, SaveGame.ExperienceLevel);
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(6, 0);
    }

    public override string Name => "Horrify";
    
}