﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class CharacterArmorTalent : Talent
{
    private CharacterArmorTalent(Game game) : base(game) { }
    public override string Name => "Character Armor";
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;

    public override void Use()
    {
        Game.StoneskinTimer.AddTimer(Game.ExperienceLevel.Value);
        if (Game.ExperienceLevel.Value > 14)
        {
            Game.AcidResistanceTimer.AddTimer(Game.ExperienceLevel.Value);
        }
        if (Game.ExperienceLevel.Value > 19)
        {
            Game.FireResistanceTimer.AddTimer(Game.ExperienceLevel.Value);
        }
        if (Game.ExperienceLevel.Value > 24)
        {
            Game.ColdResistanceTimer.AddTimer(Game.ExperienceLevel.Value);
        }
        if (Game.ExperienceLevel.Value > 29)
        {
            Game.LightningResistanceTimer.AddTimer(Game.ExperienceLevel.Value);
        }
        if (Game.ExperienceLevel.Value > 34)
        {
            Game.PoisonResistanceTimer.AddTimer(Game.ExperienceLevel.Value);
        }
    }

    protected override string Comment()
    {
        return $"dur {Game.ExperienceLevel.Value}";
    }
}