// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class CharacterArmourTalent : Talent
{
    private CharacterArmourTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Character Armour";
    public override void Initialize(int characterClass)
    {
        Level = 13;
        ManaCost = 12;
        BaseFailure = 50;
    }

    public override void Use()
    {
        SaveGame.TimedStoneskin.AddTimer(SaveGame.ExperienceLevel);
        if (SaveGame.ExperienceLevel > 14)
        {
            SaveGame.TimedAcidResistance.AddTimer(SaveGame.ExperienceLevel);
        }
        if (SaveGame.ExperienceLevel > 19)
        {
            SaveGame.TimedFireResistance.AddTimer(SaveGame.ExperienceLevel);
        }
        if (SaveGame.ExperienceLevel > 24)
        {
            SaveGame.TimedColdResistance.AddTimer(SaveGame.ExperienceLevel);
        }
        if (SaveGame.ExperienceLevel > 29)
        {
            SaveGame.TimedLightningResistance.AddTimer(SaveGame.ExperienceLevel);
        }
        if (SaveGame.ExperienceLevel > 34)
        {
            SaveGame.TimedPoisonResistance.AddTimer(SaveGame.ExperienceLevel);
        }
    }

    protected override string Comment()
    {
        return $"dur {SaveGame.ExperienceLevel}";
    }
}