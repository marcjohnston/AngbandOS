// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class CharacterArmorTalent : Talent
{
    private CharacterArmorTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Character Armor";
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;

    public override void Use()
    {
        SaveGame.StoneskinTimer.AddTimer(SaveGame.ExperienceLevel.Value);
        if (SaveGame.ExperienceLevel.Value > 14)
        {
            SaveGame.AcidResistanceTimer.AddTimer(SaveGame.ExperienceLevel.Value);
        }
        if (SaveGame.ExperienceLevel.Value > 19)
        {
            SaveGame.FireResistanceTimer.AddTimer(SaveGame.ExperienceLevel.Value);
        }
        if (SaveGame.ExperienceLevel.Value > 24)
        {
            SaveGame.ColdResistanceTimer.AddTimer(SaveGame.ExperienceLevel.Value);
        }
        if (SaveGame.ExperienceLevel.Value > 29)
        {
            SaveGame.LightningResistanceTimer.AddTimer(SaveGame.ExperienceLevel.Value);
        }
        if (SaveGame.ExperienceLevel.Value > 34)
        {
            SaveGame.PoisonResistanceTimer.AddTimer(SaveGame.ExperienceLevel.Value);
        }
    }

    protected override string Comment()
    {
        return $"dur {SaveGame.ExperienceLevel.Value}";
    }
}