﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellDaylight : Spell
{
    private NatureSpellDaylight(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.LightArea(SaveGame.Rng.DiceRoll(2, SaveGame.ExperienceLevel / 2), (SaveGame.ExperienceLevel / 10) + 1);
        if (!SaveGame.Race.IsBurnedBySunlight || SaveGame.HasLightResistance)
        {
            return;
        }
        SaveGame.MsgPrint("The daylight scorches your flesh!");
        SaveGame.TakeHit(SaveGame.Rng.DiceRoll(2, 2), "daylight");
    }

    public override string Name => "Daylight";
    
    protected override string? Info()
    {
        return $"dam 2d{SaveGame.ExperienceLevel / 2}";
    }
}